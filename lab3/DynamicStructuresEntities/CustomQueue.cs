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
            logger.Write((values.Count == 0).ToString());
            return (values.Count == 0);
        }

        public bool IsEmpty1()
        {
            return (values.Count == 0);
        }

        public void Print()
        {
            if (!IsEmpty1())
            {
                for (int i = 0; i < values.Count; i++)
                {
                    logger.Write($"{values[i]}");
                    if (i != values.Count - 1)
                    {
                        logger.Write(", ");
                    }
                    else
                    {
                        logger.Write(".");
                    }

                }
                logger.Write("\n");
            }
        }
        public List<T> GetQueue()
        {
            return values;
        }
    }
}


