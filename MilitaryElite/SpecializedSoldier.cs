using MilitaryElite.Enums;
using MilitaryElite.Interfaces;

namespace MilitaryElite
{
    public class SpecializedSoldier : Private, ISpecializedSoldier
    {
        public SpecializedSoldier(string id, string firstName, string lastName, decimal salary, Corps corps) 
            : base(id, firstName, lastName, salary)
        {
            Corps = corps;
        }

        public Corps Corps { get; }
    }
}
