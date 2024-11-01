﻿using Loggers;

namespace DynamicStructuresEntities
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
            return !IsEmpty() ? values[values.Count - 1] : default;
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
                    logger.Write($"{item}, ");
                }
                logger.Write(" ");

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
