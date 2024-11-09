
namespace Сontacts
{
    public class Person
    {
        private string name;
        private string surname;
        private int phoneNumber;

        public Person(string name, string surname, int phoneNumber)
        {
            this.name = name;
            this.surname = surname;
            this.phoneNumber = phoneNumber;
        }
        public Person(string name, int phoneNumber)
        {
            this.phoneNumber = phoneNumber;
            this.name = name;
        }
        public string GetName()
        {
            return name;
        }
        public string GetSurname()
        {
            return surname;
        }
        public int GetPhoneNumber()
        {
            return phoneNumber;
        }
    }
}
