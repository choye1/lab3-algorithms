using System;
using System.Windows;
using System.Windows.Controls;

namespace OrganizationApp
{
    public partial class MainWindow : Window
    {
        private EmployeeManager employeeManager;

        public MainWindow()
        {
            InitializeComponent();
            employeeManager = new EmployeeManager();
        }

        private void DisplayTree()
        {
            EmployeeTreeView.Items.Clear();
            if (employeeManager.CEO != null)
            {
                EmployeeTreeView.Items.Add(CreateTreeItem(employeeManager.CEO));
            }
        }

        private TreeViewItem CreateTreeItem(Employee employee)
        {
            var item = new TreeViewItem { Header = employee.ToString() };
            foreach (var subordinate in employee.Subordinates)
            {
                item.Items.Add(CreateTreeItem(subordinate));
            }
            return item;
        }

        private void AddEmployeeButton_Click(object sender, RoutedEventArgs e)
        {
            string name = NameTextBox.Text;
            string managerName = ManagerTextBox.Text;
            string position = PositionTextBox.Text;

            if (!double.TryParse(SalaryTextBox.Text, out double salary))
            {
                MessageBox.Show("Введите корректную зарплату.");
                return;
            }

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(position))
            {
                MessageBox.Show("Имя и должность сотрудника обязательны.");
                return;
            }

            var newEmployee = new Employee(name, salary, position);
            if (string.IsNullOrEmpty(managerName))
            {
                try
                {
                    employeeManager.SetCEO(newEmployee);
                    DisplayTree();
                }
                catch (InvalidOperationException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (employeeManager.AddEmployee(managerName, newEmployee))
            {
                DisplayTree();
            }
            else
            {
                MessageBox.Show("Менеджер не найден!");
            }
        }

        private void RemoveEmployeeButton_Click(object sender, RoutedEventArgs e)
        {
            string name = NameTextBox.Text;
            if (employeeManager.RemoveEmployee(name))
            {
                DisplayTree();
            }
            else
            {
                MessageBox.Show("Сотрудник не найден или не может быть удален.");
            }
        }

        private void CalculateSalaryButton_Click(object sender, RoutedEventArgs e)
        {
            string name = NameTextBox.Text;
            var employee = employeeManager.FindEmployee(name);
            if (employee != null)
            {
                double totalSalary = employee.CalculateTotalSalary();
                MessageBox.Show($"Общая зарплата {employee.Name}: ${totalSalary}");
            }
            else
            {
                MessageBox.Show("Сотрудник не найден!");
            }
        }

        //private void SearchButton_Click(object sender, RoutedEventArgs e)
        //{
        //    string name = SearchNameTextBox.Text;
        //    string position = SearchPositionTextBox.Text;

        //    double? salary = null;
        //    if (double.TryParse(SearchSalaryTextBox.Text, out double parsedSalary))
        //    {
        //        salary = parsedSalary;
        //    }

        //    var results = employeeManager.SearchEmployees(name, salary, position);
        //    DisplaySearchResults(results);
        }

        //private void DisplaySearchResults(List<Employee> employees)
        //{
        //    SearchResultsListBox.Items.Clear();
        //    foreach (var employee in employees)
        //    {
        //        SearchResultsListBox.Items.Add(employee.ToString());
        //    }
        //    if (employees.Count == 0)
        //    {
        //        SearchResultsListBox.Items.Add("Сотрудники не найдены.");
        //    }
        //}
    }

