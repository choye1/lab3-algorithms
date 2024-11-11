
namespace PersonСontactsApp
{
    public class Person
    {
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public long PhoneNumber { get; private set; }

        public Person(string name, string surname, long phoneNumber)
        {
            Name = name;
            Surname = surname;
            PhoneNumber = phoneNumber;
        }

        public Person(string name, int phoneNumber)
        {
            Name = name;
            PhoneNumber = phoneNumber;
        }
    }
}
