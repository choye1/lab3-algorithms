using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Сontacts
{
    internal class ContactList
    {
        private List<Person> persons;

        public ContactList() { }

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
        public List<Person> Search (string name)
        {
            List<Person> list = new List<Person>();

            foreach (Person person in persons)
            {
                if (person.GetName().Equals(name) || person.GetSurname().Equals(name))
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
                if (person.GetName().Equals(name) && person.GetSurname().Equals(surname))
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
                if (person.GetPhoneNumber().Equals(phoneNumber))
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
                if (person.GetName().Equals(name) &&
                    person.GetSurname().Equals(surname) &&
                    person.GetPhoneNumber().Equals(phoneNumber))
                {
                    return person;
                }
            }
            throw new Exception("Нет такого контакта");
        }

        public List<Person> SortByName()
        {
            persons.Sort((p1, p2) => p1.GetName().CompareTo(p2.GetName()));
            return persons;
        }
        public List<Person> SortBySurName()
        {
            persons.Sort((p1, p2) => p1.GetSurname().CompareTo(p2.GetSurname()));
            return persons;
        }
        public List<Person> SortByNameAndSurname()
        {
            persons.Sort((p1, p2) =>
            {
                int surnameComparison = p1.GetSurname().CompareTo(p2.GetSurname());
                if (surnameComparison != 0)
                {
                    return surnameComparison;
                }
                return p1.GetName().CompareTo(p2.GetName());
            });
            return persons;
        }
    }
}
