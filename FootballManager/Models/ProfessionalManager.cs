using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager.Models
{
    public class ProfessionalManager : Manager
    {
        private const double ProRanking = 60;
        private const double ProFactor = 1.5;
        public ProfessionalManager(string name) : base(name, ProRanking)
        {
        }

        public override void RankingUpdate(double updateValue)
        {
            this.Ranking += (updateValue * ProFactor);

            if (this.Ranking < 0)
            {
                this.Ranking = 0;
            }
            else if (this.Ranking > 100)
            {
                this.Ranking = 100;
            }
        }
    }
}
