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

            private void Enqueue(T item)
            {
                values.Add(item);
            }

            private T? Dequeue()
            {
                if (!IsEmpty())
                {
                    T top = values[0];
                    values.RemoveAt(0);
                    return top;
                }

                return default;
            }

            private T? Peek()
            {
                return !IsEmpty() ? values[0] : default;
            }
            private T? Top() // Top и Peek имеют одинаковую логику, выбирайте на свой вкус
            {
                return !IsEmpty() ? values[0] : default;
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

}
