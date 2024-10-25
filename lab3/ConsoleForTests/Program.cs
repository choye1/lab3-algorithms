using StackEntities;

namespace ConsoleForTests
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Проверки");
            CustomStack<int> cs = new CustomStack<int>(1, 2, 3);
            Console.ReadLine();
        }
    }
}
