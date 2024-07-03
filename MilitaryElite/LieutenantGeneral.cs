using MilitaryElite.Interfaces;
using System.Text;

namespace MilitaryElite
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        private List<ISoldier> soldiers;
        public LieutenantGeneral(string id, string firstName, string lastName, decimal salary,List<ISoldier> soldiers)
            : base(id, firstName, lastName, salary)
        {
            this.soldiers = new List<ISoldier>();
            this.soldiers = soldiers;
        }

        public List<ISoldier> Soldiers
            => this.soldiers;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Name: {FirstName} {LastName} Id: {Id} Salary: {Salary:f2}");
            sb.AppendLine($"Privates:");

            foreach(var soldier in soldiers)
            {
                sb.AppendLine($"  {soldier.ToString()}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
