namespace MilitaryElite.Interfaces
{
    public interface ILieutenantGeneral : IPrivate
    {
        public List<ISoldier> Soldiers { get; }
    }
}
