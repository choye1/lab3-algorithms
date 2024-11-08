using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizationApp
{
    public class EmployeeManager
    {
        private Employee root;

        public EmployeeManager(Employee ceo)
        {
            root = ceo;
        }

        // Поиск сотрудника по имени
        public Employee FindEmployee(string name)
        {
            return FindEmployeeRecursive(root, name);
        }

        private Employee FindEmployeeRecursive(Employee employee, string name)
        {
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

        // Добавление сотрудника к менеджеру
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

        // Удаление сотрудника
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
    }
}
