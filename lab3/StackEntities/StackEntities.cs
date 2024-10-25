using System.Linq;

namespace StackEntities
{
    public class CustomStack <T>
    {
        private List<T> values = new List<T>();
        
        public CustomStack (params T[] items)
        {
            this.values.AddRange(items);
        }

        public CustomStack ()
        {
        }

        public void Push(T item)
        {
            values.Add(item);
        }

        public T? Pop()
        {
            if (!IsEmpty())
            {
                T top = values[values.Count - 1];
                values.RemoveAt(values.Count - 1);
                return top;
            }

            return default;
        }

        public T? Top()
        {
            return ! IsEmpty() ? values[values.Count - 1] : default;
        }
        public T? Peek() //Peek и Top это один и тот же метод но в лабе николаева он хочет Top а в шарпе используется конструкция Peek
        {
            return !IsEmpty() ? values[values.Count - 1] : default;
        }

        public bool IsEmpty()
        {
            return (values.Count == 0);
        }

        public void Print()
        {
            if (!IsEmpty())
            {
                foreach (var item in values)
                {
                    Console.Write($"{item}, ");
                }
                Console.WriteLine();

            }

        }

    }

}
