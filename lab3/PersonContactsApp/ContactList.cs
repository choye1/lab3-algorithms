using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonСontactsApp
{
    internal class ContactList
    {
        private List<Person> persons;

        public ContactList()
        {
            persons = new List<Person>();
        }

        public void AddPerson(Person person)
        {
            persons.Add(person);
        }

        public List<Person> GetPersons()
        {
            return persons;
        }

        public void RemovePerson(Person person)
        {
            persons.Remove(person);
        }

        public List<Person> Search(string name)
        {
            List<Person> list = new List<Person>();

            foreach (Person person in persons)
            {
                if (person.Name.Equals(name) || person.Surname.Equals(name))
                {
                    list.Add(person);
                }
            }
            if (list.Count > 0)
            {
                return list;
            }
            throw new Exception("Нет такого контакта");
        }

        public List<Person> Search(string name, string surname)
        {
            List<Person> list = new List<Person>();

            foreach (Person person in persons)
            {
                if (person.Name.Equals(name) && person.Surname.Equals(surname))
                {
                    list.Add(person);
                }
            }
            if (list.Count > 0)
            {
                return list;
            }
            throw new Exception("Нет такого контакта");
        }

        public Person Search(int phoneNumber)
        {
            foreach (Person person in persons)
            {
                if (person.PhoneNumber.Equals(phoneNumber))
                {
                    return person;
                }
            }

            throw new Exception("Нет такого контакта");
        }

        public Person Search(string name, string surname, int phoneNumber)
        {
            foreach (Person person in persons)
            {
                if (person.Name.Equals(name) &&
                    person.Surname.Equals(surname) &&
                    person.PhoneNumber.Equals(phoneNumber))
                {
                    return person;
                }
            }
            throw new Exception("Нет такого контакта");
        }

        public List<Person> SortByName()
        {
            persons.Sort((p1, p2) => p1.Name.CompareTo(p2.Name));
            return persons;
        }

        public List<Person> SortBySurName()
        {
            persons.Sort((p1, p2) => p1.Surname.CompareTo(p2.Surname));
            return persons;
        }

        public List<Person> SortByNameAndSurname()
        {
            persons.Sort((p1, p2) =>
            {
                int surnameComparison = p1.Surname.CompareTo(p2.Surname);
                if (surnameComparison != 0)
                {
                    return surnameComparison;
                }
                return p1.Name.CompareTo(p2.Name);
            });
            return persons;
        }
    }
}
