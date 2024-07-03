using MilitaryElite.Enums;

namespace MilitaryElite
{
    public class Mission
    {
        public Mission(string name, MissionState state)
        {
            Name = name;
            State = state;
        }

        public string Name { get; }

        public MissionState State { get; }

        public override string ToString()
        {
            return $"Code Name: {Name} State: {State}";
        }
    }
}
