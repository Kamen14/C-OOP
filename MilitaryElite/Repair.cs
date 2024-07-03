using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryElite
{
    public class Repair
    {
        public Repair(string name, int hoursWorked)
        {
            Name = name;
            HoursWorked = hoursWorked;
        }

        public string Name { get; }

        public int HoursWorked { get; }

        public override string ToString()
        {
            return $"Part Name: {Name} Hours Worked: {HoursWorked}";
        }
    }
}
