using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicStructuresEntities
{
    public class LinkedList<T>
    {
        private Node<T> head;

        public LinkedList()
        {
            head = null;
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
