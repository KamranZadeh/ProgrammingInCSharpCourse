namespace toDo1
{
    public class User
    {
        public User(string name, string surname, int age, string country)
        {
            Name = name;
            Surname = surname;
            Age = age;
            Country = country;
        }

        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string Country { get; set; }

        public override string ToString()
        {
            return $"{Name} {Surname} {Age} {Country}";
        }
    }
}
