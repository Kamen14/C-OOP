using FootballManager.Models.Contracts;
using FootballManager.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FootballManager.Repositories
{

    public class TeamRepository : IRepository<ITeam>
    {
        private readonly List<ITeam> teams = new List<ITeam>();
        public IReadOnlyCollection<ITeam> Models 
            => this.teams.AsReadOnly();

        public int Capacity { get; } = 10;

        public void Add(ITeam model)
        {
            if(Models.Count < Capacity)
            {
                this.teams.Add(model);
            }
        }

        public bool Exists(string name)
        {
            ITeam team = teams.FirstOrDefault(t => t.Name == name);

            if (team is null)
            {
                return false;
            }

            return true;
        }

        public ITeam Get(string name)
        {
            ITeam team = teams.FirstOrDefault(t => t.Name == name);

            if (team is null)
            {
                return null;
            }

            return team;
        }

        public bool Remove(string name)
        {
            ITeam team = teams.FirstOrDefault(t => t.Name == name);

            if (team is null)
            {
                return false;
            }
            
            return this.teams.Remove(team);
        }
    }
}
