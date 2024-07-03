namespace MilitaryElite.Interfaces
{
    public interface ICommando : ISpecializedSoldier
    {
        public List<Mission> Missions { get; }
    }
}
