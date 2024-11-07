using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Collections.Generic;
using QuickGraph;

namespace OrganizationApp
{
    public partial class MainWindow : Window
    {
        private EmployeeGraph employeeGraph;

        public MainWindow()
        {
            InitializeComponent();
            employeeGraph = new EmployeeGraph();
        }

        private void AddEmployeeButton_Click(object sender, RoutedEventArgs e)
        {
            string name = NameTextBox.Text;
            string position = PositionTextBox.Text;
            string managerName = ManagerTextBox.Text;

            if (double.TryParse(SalaryTextBox.Text, out double salary))
            {
                var employee = new Employee(name, position, salary);
                employeeGraph.AddEmployee(employee);

                if (!string.IsNullOrEmpty(managerName))
                {
                    var manager = employeeGraph.FindEmployee(managerName);
                    if (manager != null)
                    {
                        employeeGraph.AddSubordinate(manager, employee);
                    }
                    else
                    {
                        MessageBox.Show("Менеджер не найден!");
                    }
                }

                DrawGraph();
            }
        }

        private void ClearGraphButton_Click(object sender, RoutedEventArgs e)
        {
            employeeGraph = new EmployeeGraph();
            GraphCanvas.Children.Clear();
        }

        private void SearchEmployeeButton_Click(object sender, RoutedEventArgs e)
        {
            string name = SearchTextBox.Text;
            var employee = employeeGraph.FindEmployee(name);

            if (employee != null)
            {
                HighlightEmployeeNode(employee);
                double totalSalary = employeeGraph.CalculateTotalSalary(employee);
                SalaryOutputTextBox.Text = totalSalary.ToString("C");
            }
            else
            {
                MessageBox.Show("Сотрудник не найден!");
                SalaryOutputTextBox.Clear();
            }
        }

        private void DrawGraph()
        {
            GraphCanvas.Children.Clear();

            double centerX = GraphCanvas.ActualWidth / 2;
            double startY = 50;
            double yStep = 100;

            var rootNodes = employeeGraph.Graph.Vertices
                .Where(v => !employeeGraph.Graph.Edges.Any(e => e.Target.Equals(v))).ToList();

            int level = 0;
            foreach (var rootNode in rootNodes)
            {
                DrawSubtree(rootNode, centerX, startY + level * yStep, 300, 100);
                level++;
            }
        }

        private void DrawSubtree(Employee node, double x, double y, double xStep, double yStep)
        {
            var position = new Point(x, y);
            DrawEmployeeNode(node, position);

            var edges = employeeGraph.Graph.OutEdges(node);
            int childCount = edges.Count();
            double childXOffset = -((childCount - 1) / 2.0) * xStep;

            foreach (var edge in edges)
            {
                var childPosition = new Point(x + childXOffset, y + yStep);
                DrawEmployeeNode(edge.Target, childPosition);
                DrawEdge(position, childPosition);
                childXOffset += xStep;
                DrawSubtree(edge.Target, childPosition.X, childPosition.Y, xStep / 2, yStep);
            }
        }

        private void DrawEmployeeNode(Employee employee, Point position)
        {
            Ellipse node = new Ellipse
            {
                Width = 100,
                Height = 50,
                Fill = Brushes.LightBlue,
                Stroke = Brushes.Black,
                StrokeThickness = 2
            };

            Canvas.SetLeft(node, position.X - node.Width / 2);
            Canvas.SetTop(node, position.Y);
            GraphCanvas.Children.Add(node);

            TextBlock text = new TextBlock
            {
                Text = employee.ToString(),
                FontSize = 12,
                TextAlignment = TextAlignment.Center
            };
            Canvas.SetLeft(text, position.X - node.Width / 2 + 5);
            Canvas.SetTop(text, position.Y + 15);
            GraphCanvas.Children.Add(text);
        }

        private void DrawEdge(Point from, Point to)
        {
            Line line = new Line
            {
                X1 = from.X,
                Y1 = from.Y + 25,
                X2 = to.X,
                Y2 = to.Y - 25,
                Stroke = Brushes.Black,
                StrokeThickness = 1
            };
            GraphCanvas.Children.Add(line);
        }

        private void HighlightEmployeeNode(Employee employee)
        {
            DrawGraph();  // Перерисовываем граф
            foreach (var element in GraphCanvas.Children.OfType<Ellipse>())
            {
                TextBlock text = (TextBlock)GraphCanvas.Children
                    .OfType<TextBlock>()
                    .FirstOrDefault(tb => tb.Text.Contains(employee.Name));

                if (text != null && Canvas.GetLeft(element) == Canvas.GetLeft(text) - 5 &&
                    Canvas.GetTop(element) == Canvas.GetTop(text) - 15)
                {
                    element.Stroke = Brushes.Red;
                    element.StrokeThickness = 3;
                }
            }
        }
    }
}
