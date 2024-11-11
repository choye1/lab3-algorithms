using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicStructuresEntities
{
    public class LinkedList<T>
    {
        public Node<T> head;

        public LinkedList()
        {
            head = null;
        }
        // Индексация для получения элемента по индексу
        public T this[int index]
        {
            get { return GetAt(index); }
        }

        public List<T> ToList
        {
            get
            {
                List<T> list = new List<T>();
                var current = head;
                while (current != null)
                {
                    list.Add(current.Data);
                    current = current.Next;
                }

                return list;
            }
        }

        // Метод для получения элемента по индексу
        public T GetAt(int index)
        {
            if (index < 0)
                throw new ArgumentOutOfRangeException(nameof(index), "Index cannot be negative.");

            var current = head;
            int currentIndex = 0;

            while (current != null)
            {
                if (currentIndex == index)
                    return current.Data;

                current = current.Next;
                currentIndex++;
            }

            throw new ArgumentOutOfRangeException(nameof(index), "Index was out of range.");
        }

        public void RemoveAt(int index)
        {
            if (index < 0)
                throw new ArgumentOutOfRangeException(nameof(index), "Index cannot be negative.");

            if (head == null)
                throw new InvalidOperationException("The list is empty.");

            if (index == 0) // Удаляем первый элемент (голову)
            {
                head = head.Next;
                return;
            }

            // Находим предыдущий элемент
            var current = head;
            int currentIndex = 0;

            while (current != null && currentIndex < index - 1)
            {
                current = current.Next;
                currentIndex++;
            }

            if (current == null || current.Next == null)
                throw new ArgumentOutOfRangeException(nameof(index), "Index was out of range.");

            // Переподключаем ссылки, исключая элемент с заданным индексом
            current.Next = current.Next.Next;
        }

        // Добавление элемента в начало списка (для стека)
        public void AddFirst(T data)
        {
            var newNode = new Node<T>(data)
            {
                Next = head
            };
            head = newNode;
        }

        // Добавление элемента в конец списка (для очереди)
        public void AddLast(T data)
        {
            var newNode = new Node<T>(data);

            if (head == null)
            {
                head = newNode;
            }
            else
            {
                var current = head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode;
            }
        }

        // Удаление первого элемента (используется как в стеке, так и в очереди)
        public T RemoveFirst()
        {
            if (head == null) throw new InvalidOperationException("The list is empty.");

            var removedData = head.Data;
            head = head.Next;
            return removedData;
        }

        // Проверка на пустоту
        public bool IsEmpty()
        {
            return head == null;
        }

        // Получение первого элемента (например, для стека Peek или очереди Peek)
        public T Peek()
        {
            if (head == null) throw new InvalidOperationException("The list is empty.");

            return head.Data;
        }
        public int Count()
        {
            int count = 0;
            var current = head;
            while (current != null)
            {
                count++;
                current = current.Next;
            }
            return count;
        }
       
    }


}
