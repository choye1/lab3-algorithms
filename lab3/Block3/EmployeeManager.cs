using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizationApp
{
    public class EmployeeManager
    {
        public Employee CEO { get; private set; }

        public void SetCEO(Employee ceo)
        {
            if (CEO == null)
            {
                CEO = ceo;
            }
            else
            {
                throw new InvalidOperationException("CEO уже установлен.");
            }
        }

        public bool AddEmployee(string managerName, Employee newEmployee)
        {
            var manager = FindEmployee(managerName);
            if (manager != null)
            {
                manager.AddSubordinate(newEmployee);
                return true;
            }
            return false;
        }

        public bool RemoveEmployee(string employeeName)
        {
            var employee = FindEmployee(employeeName);
            if (employee != null && employee.Manager != null)
            {
                employee.Manager.RemoveSubordinate(employee);
                return true;
            }
            return false;
        }

        public Employee FindEmployee(string name)
        {
            return FindEmployeeRecursive(CEO, name);
        }

        private Employee FindEmployeeRecursive(Employee employee, string name)
        {
            if (employee == null) return null;
            if (employee.Name == name)
                return employee;

            foreach (var subordinate in employee.Subordinates)
            {
                var found = FindEmployeeRecursive(subordinate, name);
                if (found != null)
                    return found;
            }
            return null;
        }

        public List<Employee> SearchEmployees(string name, double? salary, string position)
        {
            List<Employee> results = new List<Employee>();
            SearchEmployeesRecursive(CEO, name, salary, position, results);
            return results;
        }

        private void SearchEmployeesRecursive(Employee employee, string name, double? salary, string position, List<Employee> results)
        {
            if (employee == null) return;

            if ((string.IsNullOrEmpty(name) || employee.Name.Contains(name, StringComparison.OrdinalIgnoreCase)) &&
                (!salary.HasValue || employee.Salary == salary.Value) &&
                (string.IsNullOrEmpty(position) || employee.Position.Equals(position, StringComparison.OrdinalIgnoreCase)))
            {
                results.Add(employee);
            }

            foreach (var subordinate in employee.Subordinates)
            {
                SearchEmployeesRecursive(subordinate, name, salary, position, results);
            }
        }
    }

}
