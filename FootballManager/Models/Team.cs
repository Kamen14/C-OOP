using FootballManager.Models.Contracts;
using FootballManager.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager.Models
{
    public class Team : ITeam
    {
        private IManager manager;
        public Team(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException(ExceptionMessages.TeamNameNull);
            }
            Name = name;
        }

        public string Name { get; }

        public int ChampionshipPoints { get; private set; }

        public IManager TeamManager
            => this.manager;

        public int PresentCondition
            => CalculaePresentCondition();

        private int CalculaePresentCondition()
        {
            if(TeamManager is null)
            {
                return 0;   
            }

            if(ChampionshipPoints == 0)
            {
                return (int)Math.Floor(TeamManager.Ranking);
            }

            return (int)Math.Floor(ChampionshipPoints * this.TeamManager.Ranking);
        }
        public void GainPoints(int points)
        {
            ChampionshipPoints += points;
        }

        public void ResetPoints()
        {
            ChampionshipPoints = 0;
        }

        public void SignWith(IManager manager)
        {
            this.manager = manager;
        }

        public override string ToString()
        {
            return $"Team: {this.Name} Points: {this.ChampionshipPoints}";
        }
    }
}
