    using Loggers;
namespace DynamicStructuresEntities
{
    public class CustomQueue<T>
    {
        Logger logger = new Logger();
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
                    logger.Write($"{item}");

                    if (values.IndexOf(item) == values.Count-1)
                    {
                        logger.WriteLine(". ");
                    }

                    else
                    {
                        logger.Write(", ");
                    }
                }
            }
        }
        public List<T> GetQueue() 
        {
            return values;
        }
    }
}


