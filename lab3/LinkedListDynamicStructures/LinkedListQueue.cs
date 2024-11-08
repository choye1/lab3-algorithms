using Loggers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicStructuresEntities
{
    public class Queue<T>
    {
        private LinkedList<T> list = new LinkedList<T>();
        Logger logger = new Logger();

        // Добавление элемента в очередь
        public void Enqueue(T data)
        {
            list.AddLast(data);
        }

        // Удаление элемента из очереди
        public T Dequeue()
        {
            return list.RemoveFirst();
        }

        // Получение элемента из начала очереди
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
                logger.WriteLine("Queue is empty.");
                return;
            }

            LinkedList<T> tempList = new LinkedList<T>();
            while (!list.IsEmpty())
            {
                T item = list.RemoveFirst();
                logger.Write($"{item} ");
                tempList.AddLast(item);
            }
            while (!tempList.IsEmpty())
            {
                list.AddLast(tempList.RemoveFirst());
            }
        }

        public List<T> GetQueue()
        {
            List<T> values = new List<T>();
            LinkedList<T> tempList = new LinkedList<T>();
            while (!list.IsEmpty())
            {
                T item = list.RemoveFirst();
                values.Add(item);
                tempList.AddLast(item);
            }
            while (!tempList.IsEmpty())
            {
                list.AddLast(tempList.RemoveFirst());
            }
            return values;
        }
    }
}
