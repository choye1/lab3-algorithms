using System.Linq;

namespace QueueEntities
{
    public class QueueEntities
    {
        public class CustomQueue<T>
        {
            private List<T> values = new List<T>();

            public CustomQueue(params T[] items)
            {
                this.values.AddRange(items);
            }

            public CustomQueue()
            {
            }

            public void Enqueue(T item)
            {
                values.Add(item);
            }

            public T? Dequeue()
            {
                if (!IsEmpty())
                {
                    T top = values[0];
                    values.RemoveAt(0);
                    return top;
                }

                return default;
            }

            public T? Peek()
            {
                return !IsEmpty() ? values[0] : default;
            }
            public T? Top() // Top и Peek имеют одинаковую логику, выбирайте на свой вкус
            {
                return !IsEmpty() ? values[0] : default;
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

}
