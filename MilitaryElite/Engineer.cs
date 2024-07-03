using MilitaryElite.Enums;
using MilitaryElite.Interfaces;
using System.Text;

namespace MilitaryElite
{
    public class Engineer : SpecializedSoldier, IEngineer
    {
        private List<Repair> repairs;
        public Engineer(string id, string firstName, string lastName, decimal salary, Corps corps, List<Repair> repairs) 
            : base(id, firstName, lastName, salary, corps)
        {
            this.repairs = new List<Repair>();
            this.repairs = repairs;
        }

        public List<Repair> Repairs
            => this.repairs;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Name: {FirstName} {LastName} Id: {Id} Salary: {Salary:f2}");
            sb.AppendLine($"Corps: {Corps}");
            sb.AppendLine("Repairs:");

            foreach ( var repair in this.repairs )
            {
                sb.AppendLine($"  {repair.ToString()}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
