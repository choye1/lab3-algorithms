using Loggers;

namespace ListDynamicStructures
{
    public class CustomStack<T>
    {
        Logger logger = new Logger();

        private List<T> values = new List<T>();

        public CustomStack(params T[] items)
        {
            this.values.AddRange(items);
        }

        public CustomStack()
        {
        }

        public void Push(T item)
        {
            values.Add(item);
        }

        public T? Pop()
        {
            if (!IsEmpty1())
            {
                T top = values[values.Count - 1];
                values.RemoveAt(values.Count - 1);
                return top;
            }

            return default;
        }

        public T? Top()
        {
            return !IsEmpty1() ? values[values.Count - 1] : default;
        }
        public T? Peek() //Peek и Top это один и тот же метод но в лабе николаева он хочет Top а в шарпе используется конструкция Peek
        {
            return !IsEmpty1() ? values[values.Count - 1] : default;
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
        public bool UniqueValue(T value)
        {
            foreach(var item in values)
            {
                if (item.Equals(value))
                {
                    return false;
                }
            }
            return true;
        }
        public List<T> GetStack()
        {
            return values;
        }

        public int Count()
        {
            return values.Count;
        }

    }

}
