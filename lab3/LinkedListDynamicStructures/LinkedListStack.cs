using Loggers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicStructuresEntities
{
    public class LinkedListStack<T>
    {
        private LinkedList<T> list = new LinkedList<T>();
        Logger logger = new Logger();

        // Добавление элемента в стек
        public void Push(T data)
        {
            list.AddFirst(data);
        }

        // Удаление элемента из стека
        public T Pop()
        {
            return list.RemoveFirst();
        }

        // Получение верхнего элемента
        public T Peek()
        {
            return list.Peek();
        }

        // Проверка на пустоту
        public bool IsEmpty()
        {
            return list.IsEmpty();
        }
        public void Print()
        {
            if (IsEmpty())
            {
                logger.WriteLine("Stack is empty.");
                return;
            }

            var current = list.Peek();
            while (current != null)
            {
                logger.Write($"{current} ");
                current = list.RemoveFirst();
            }
        }

        public bool UniqueValue(T value)
        {
            var current = list.Peek();
            while (current != null)
            {
                if (current.Equals(value))
                {
                    return false;
                }
                current = list.RemoveFirst();
            }
            return true;
        }

        public List<T> GetStack()
        {
            List<T> values = new List<T>();
            var current = list.Peek();
            while (current != null)
            {
                values.Add(current);
                current = list.RemoveFirst();
            }
            return values;
        }

        public int Count()
        {
            int count = 0;
            var current = list.Peek();
            while (current != null)
            {
                count++;
                current = list.RemoveFirst();
            }
            return count;
        }
    }

}
