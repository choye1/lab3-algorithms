using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace OrganizationApp
{
    public class Employee
    {
        public string Name { get; set; }
        public double Salary { get; set; }
        public string Position { get; set; }
        public Employee Manager { get; set; }
        public List<Employee> Subordinates { get; private set; }

        public Employee(string name, double salary, string position)
        {
            Name = name;
            Salary = salary;
            Position = position;
            Subordinates = new List<Employee>();
        }

        public Employee(string name)
        {
            Name = name;
            Subordinates = new List<Employee>();
        }

        public void AddSubordinate(Employee employee)
        {
            employee.Manager = this;
            Subordinates.Add(employee);
        }

        public void RemoveSubordinate(Employee employee)
        {
            employee.Manager = null;
            Subordinates.Remove(employee);
        }

        public double CalculateTotalSalary()
        {
            double totalSalary = Salary;
            foreach (var subordinate in Subordinates)
            {
                totalSalary += subordinate.CalculateTotalSalary();
            }
            return totalSalary;
        }

        public override string ToString()
        {
            return $"{Name} - {Position} - ${Salary}";
        }
    }

}
