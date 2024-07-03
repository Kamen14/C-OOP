using MilitaryElite.Enums;
using MilitaryElite.Interfaces;
using System.Text;

namespace MilitaryElite
{
    public class Commando : SpecializedSoldier, ICommando
    {
        private List<Mission> missions;
        public Commando(string id, string firstName, string lastName, decimal salary, Corps corps,List<Mission> missions) 
            : base(id, firstName, lastName, salary, corps)
        {
            this.missions = new List<Mission>();
            this.missions = missions;
        }

        public List<Mission> Missions
            => this.missions;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Name: {FirstName} {LastName} Id: {Id} Salary: {Salary:f2}");
            sb.AppendLine($"Corps: {Corps}");
            sb.AppendLine("Missions:");

            foreach(Mission mission in this.missions)
            {
                sb.AppendLine($"  {mission.ToString()}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
