using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager.Models
{
    public class AmateurManager : Manager
    {
        private const double AmateurRanking = 15.00;
        private const double AmateurFactor = 0.75;
        public AmateurManager(string name) : base(name, AmateurRanking)
        {
        }

        public override void RankingUpdate(double updateValue)
        {
            this.Ranking += (updateValue * AmateurFactor);

            if (this.Ranking < 0)
            {
                this.Ranking = 0;
            }
            else if(this.Ranking > 100)
            {
                this.Ranking = 100;
            }
        }
    }
}
