namespace PersonInfo
{
    public class Citizen : IPerson, IIdentifiable, IBirthable
    {
        public Citizen(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public Citizen(string name, int age, string id, string birthDate) : this(name, age)
        {
            Id = id;
            Birthdate = birthDate;
        }

        public string Name { get; }

        public int Age { get; }

        public string Id { get; }

        public string Birthdate {  get; }
    }
}
