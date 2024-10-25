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

        private void Push(T item)
        {
            values.Add(item);
        }

        private T? Pop()
        {
            if (!IsEmpty())
            {
                T top = values[values.Count - 1];
                values.RemoveAt(values.Count - 1);
                return top;
            }

            return default;
        }

        private T? Top()
        {
            return ! IsEmpty() ? values[values.Count - 1] : default;
        }
        private T? Peek() //Peek и Top это один и тот же метод но в лабе николаева он хочет Top а в шарпе используется конструкция Peek
        {
            return !IsEmpty() ? values[values.Count - 1] : default;
        }

        private bool IsEmpty()
        {
            return (values.Count == 0);
        }

        private void Print()
        {
            if (!IsEmpty())
            {
                foreach (var item in values)
                {
                    Console.Write($"{item}, ");
                }

            }

        }

    }

}
