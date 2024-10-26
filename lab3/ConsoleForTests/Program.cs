
using DynamicStructuresEntities;

namespace ConsoleForTests
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Проверки");
            CustomStack<int> cs = new CustomStack<int>(1, 2, 3);
            cs.Print();
            cs.Push(4);
            cs.Print();
            cs.Pop();
            cs.Print();
            Console.WriteLine(cs.Peek());
            cs.Print();
            Console.ReadLine();
        }
    }
}
