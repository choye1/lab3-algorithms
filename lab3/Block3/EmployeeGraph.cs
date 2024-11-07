using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuickGraph;
using QuickGraph.Algorithms;
using System.Collections.Generic;

namespace OrganizationApp
{

    public class EmployeeGraph
    {
        public AdjacencyGraph<Employee, Edge<Employee>> Graph { get; private set; }

        public EmployeeGraph()
        {
            Graph = new AdjacencyGraph<Employee, Edge<Employee>>();
        }

        public void AddEmployee(Employee employee)
        {
            Graph.AddVertex(employee);
        }

        public void AddSubordinate(Employee manager, Employee subordinate)
        {
            if (!Graph.ContainsVertex(manager))
                Graph.AddVertex(manager);

            if (!Graph.ContainsVertex(subordinate))
                Graph.AddVertex(subordinate);

            var edge = new Edge<Employee>(manager, subordinate);
            Graph.AddEdge(edge);
        }

        public void RemoveEmployee(Employee employee)
        {
            Graph.RemoveVertex(employee);
        }

        public Employee FindEmployee(string name)
        {
            return Graph.Vertices.FirstOrDefault(e => e.Name == name);
        }

        public double CalculateTotalSalary(Employee manager)
        {
            double totalSalary = manager.Salary;

            foreach (var edge in Graph.OutEdges(manager))
            {
                totalSalary += CalculateTotalSalary(edge.Target);
            }

            return totalSalary;
        }
    }

}
