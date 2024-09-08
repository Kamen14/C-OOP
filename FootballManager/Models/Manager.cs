using FootballManager.Models.Contracts;
using FootballManager.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager.Models
{
    public abstract class Manager : IManager
    {
        protected Manager(string name, double ranking)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException(ExceptionMessages.ManagerNameNull);
            }

            Name = name;
            Ranking = ranking;
        }

        public string Name { get; }

        public double Ranking { get; protected set; }

        public abstract void RankingUpdate(double updateValue);

        public override string ToString()
        {
            return $"{this.Name} - {this.GetType().Name} (Ranking: {this.Ranking:F2})";
        }
    }
}
