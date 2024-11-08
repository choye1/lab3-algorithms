using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicStructuresEntities;
using ListDynamicStructures;

namespace part4
{
    public class Task2<T> 
    {
        LinkedListQueue<T> queue = new LinkedListQueue<T>();
        LinkedListStack<T> stack = new LinkedListStack<T>();

        public DynamicStructuresEntities.LinkedList<T> GetResult(DynamicStructuresEntities.LinkedList<T> list)
        {
            DynamicStructuresEntities.LinkedList<T> result = new DynamicStructuresEntities.LinkedList<T>();
            
            for (int i = 0; i < list.Count(); i++)
            {
                queue.Enqueue(list[i]);
            }

            T buffer = queue.Dequeue();

            foreach (var item in queue.GetQueue())
            {
                result.AddLast(item);
            }
            result.AddLast(buffer);
            
            return result;
        }
    }
}
