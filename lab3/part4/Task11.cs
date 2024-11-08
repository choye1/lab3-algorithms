using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicStructuresEntities;
using ListDynamicStructures;

namespace part4
{
    public class Task11<T>
    {
        LinkedListQueue<T> queue = new LinkedListQueue<T>();

        public DynamicStructuresEntities.LinkedList<T> GetResult(DynamicStructuresEntities.LinkedList<T> list)
        {
            for (int i = 0; i < list.Count(); i++)
            {
                queue.Enqueue(list[i]);
            }
            for (int i = 0; i < list.Count(); i++)
            {
                queue.Enqueue(list[i]);
            }
            return queue.LLGetQueue();     
        }
    }
}
