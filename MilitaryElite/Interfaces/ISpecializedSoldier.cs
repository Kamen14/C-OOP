using MilitaryElite.Enums;

namespace MilitaryElite.Interfaces
{
    public interface ISpecializedSoldier : IPrivate
    {
        public Corps Corps { get; }
    }
}
