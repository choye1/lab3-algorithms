using DynamicStructuresEntities;
using ListDynamicStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace part4
{
    public class Task4<T> 
    {
        LinkedListStack<T> stack = new LinkedListStack<T>();
        int count = 0;

        public DynamicStructuresEntities.LinkedList<T> GetResult(DynamicStructuresEntities.LinkedList<T> list)
        {
            LinkedListQueue<T> queue = new LinkedListQueue<T>();
            HashSet<T> uniqueElements = new HashSet<T>(); // Хранение уникальных элементов

            var current = list.head;
            while (current != null)
            {
                uniqueElements.Add(current.Data);
                current = current.Next;
            }
            
            foreach (var item in uniqueElements)
            {
                queue.Enqueue(item);
            }

            return queue.LLGetQueue();
        }
    }
}
