using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager.Models
{
    public class SeniorManager : Manager
    {
        private const double SeniorRanking = 30;
        public SeniorManager(string name) : base(name, SeniorRanking)
        {
        }

        public override void RankingUpdate(double updateValue)
        {
            this.Ranking += updateValue;

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
