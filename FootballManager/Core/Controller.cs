using FootballManager.Core.Contracts;
using FootballManager.Models;
using FootballManager.Models.Contracts;
using FootballManager.Repositories;
using FootballManager.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager.Core
{
    public class Controller : IController
    {
        private TeamRepository championship = new TeamRepository();
        public string ChampionshipRankings()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("***Ranking Table***");

            List<ITeam> teams = championship.Models
                .OrderByDescending(t=>t.ChampionshipPoints)
                .ThenByDescending(t=>t.PresentCondition)
                .ToList();

            int count = 1;
            foreach(ITeam team in teams)
            {
                sb.AppendLine($"{count}. {team.ToString()}/{team.TeamManager.ToString()}");
                count++;
            }

            return sb.ToString().Trim();
        }

        public string JoinChampionship(string teamName)
        {
            ITeam team = new Team(teamName); 

            if(championship.Models.Count == championship.Capacity)
            {
                return OutputMessages.ChampionshipFull;
            }

            if(championship.Models.Any(t=>t.Name == teamName))
            {
                return string.Format(OutputMessages.TeamWithSameNameExisting, teamName);
            }

            championship.Add(team);

            return string.Format(OutputMessages.TeamSuccessfullyJoined, teamName);
        }

        public string MatchBetween(string teamOneName, string teamTwoName)
        {
            if(!championship.Models.Any(t=>t.Name == teamOneName) || 
                !championship.Models.Any(t=>t.Name == teamTwoName))
            {
                return string.Format(OutputMessages.OneOfTheTeamDoesNotExist);
            }

            ITeam teamOne = championship.Models.FirstOrDefault(t=>t.Name == teamOneName);
            ITeam teamTwo = championship.Models.FirstOrDefault(t=>t.Name  == teamTwoName);

            if(teamOne.PresentCondition > teamTwo.PresentCondition)
            {
                teamOne.GainPoints(3);

                if(teamOne.TeamManager is not null)
                {
                    teamOne.TeamManager.RankingUpdate(5);
                }

                //loser
                if(teamTwo.TeamManager is not null)
                {
                    teamTwo.TeamManager.RankingUpdate(-5);
                }

                return string.Format(OutputMessages.TeamWinsMatch, teamOneName, teamTwoName);
            }
            else if(teamTwo.PresentCondition > teamOne.PresentCondition)
            {
                teamTwo.GainPoints(3);

                if (teamTwo.TeamManager is not null)
                {
                    teamTwo.TeamManager.RankingUpdate(5);
                }

                //loser
                if (teamOne.TeamManager is not null)
                {
                    teamOne.TeamManager.RankingUpdate(-5);
                }

                return string.Format(OutputMessages.TeamWinsMatch, teamTwoName, teamOneName);
            }

            teamOne.GainPoints(1);
            teamTwo.GainPoints(1);

            return string.Format(OutputMessages.MatchIsDraw, teamOneName, teamTwoName);
        }

        public string PromoteTeam(string droppingTeamName, string promotingTeamName, string managerTypeName, string managerName)
        {
            if(!championship.Models.Any(t=>t.Name == droppingTeamName))
            {
                return string.Format(OutputMessages.DroppingTeamDoesNotExist, droppingTeamName);
            }

            if(championship.Models.Any(t=>t.Name == promotingTeamName))
            {
                return string.Format(OutputMessages.TeamWithSameNameExisting, promotingTeamName);
            }

            ITeam promotingTeam = new Team(promotingTeamName);

            List<ITeam> squads = championship.Models.ToList();

            bool alreadySigned = false;
            foreach(ITeam squad in squads)
            {
                if(squad.TeamManager is not null && squad.TeamManager.Name == managerName)
                {
                    alreadySigned = true;
                    break;
                }
            }

            IManager manager;
            if (managerTypeName == nameof(AmateurManager))
            {
                manager = new AmateurManager(managerName);
            }
            else if (managerTypeName == nameof(SeniorManager))
            {
                manager = new SeniorManager(managerName);
            }
            else if (managerTypeName == nameof(ProfessionalManager))
            {
                manager = new ProfessionalManager(managerName);
            }
            else
            {
                manager = null;
            }

            if (manager is not null && !alreadySigned)
            {
                promotingTeam.SignWith(manager);
            }

            foreach(ITeam squad in championship.Models)
            {
                squad.ResetPoints();
            }

            championship.Remove(droppingTeamName);
            championship.Add(promotingTeam);

            return string.Format(OutputMessages.TeamHasBeenPromoted, promotingTeamName);
        }

        public string SignManager(string teamName, string managerTypeName, string managerName)
        {
            if(!championship.Models.Any(t=>t.Name == teamName))
            {
                return string.Format(OutputMessages.TeamDoesNotTakePart, teamName);
            }

            ITeam team = championship.Models.FirstOrDefault(t => t.Name == teamName);
            IManager manager;

            if(managerTypeName == nameof(AmateurManager))
            {
                manager = new AmateurManager(managerName);
            }
            else if(managerTypeName == nameof(SeniorManager))
            {
                manager = new SeniorManager(managerName);
            }
            else if(managerTypeName == nameof(ProfessionalManager))
            {
                manager = new ProfessionalManager(managerName);
            }
            else
            {
                return string.Format(OutputMessages.ManagerTypeNotPresented, managerTypeName);
            }

            if(team.TeamManager is not null)
            {
                return string.Format(OutputMessages.TeamSignedWithAnotherManager, teamName, team.TeamManager.Name);
            }

            List<ITeam> squads = championship.Models.Where(t => t.TeamManager is not null).ToList();
            foreach(ITeam squad in squads)
            {
                if(squad.TeamManager.Name == managerName)
                {
                    return string.Format(OutputMessages.ManagerAssignedToAnotherTeam, managerName);
                }
            }

            team.SignWith(manager);

            return string.Format(OutputMessages.TeamSuccessfullySignedWithManager, managerName, teamName);
        }
    }
}
