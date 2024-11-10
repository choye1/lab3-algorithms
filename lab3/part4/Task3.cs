using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicStructuresEntities;
using ListDynamicStructures;

namespace part4
{
    public class Task3<T> 
    {
        LinkedListStack<T> stack = new LinkedListStack<T>();
        int count = 0;

        public int GetResult(DynamicStructuresEntities.LinkedList<T> list)
        {
            HashSet<T> uniqueElements = new HashSet<T>(); // Хранение уникальных элементов

            var current = list.head;
            while (current != null)
            {
                uniqueElements.Add(current.Data); 
                current = current.Next;
            }

            return uniqueElements.Count;
        }
    }
}
