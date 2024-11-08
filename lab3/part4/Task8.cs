using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicStructuresEntities;
using ListDynamicStructures;

namespace part4
{
    public class Task8<T> 
    {
        LinkedListQueue<T> queue = new LinkedListQueue<T>();
        int eCount = 0;
        public DynamicStructuresEntities.LinkedList<T> GetResult(DynamicStructuresEntities.LinkedList<T> list, T f, T e)
        {
            for (int i = 0; i < list.Count(); i++) 
            {
                if (list[i+1].Equals(e) && eCount == 0)
                {
                    queue.Enqueue(list[i]);
                    queue.Enqueue(f);
                    // надо придумать как удалить е
                    eCount++; // придумал
                }
                queue.Enqueue(list[i]);
            }
            return queue.LLGetQueue();
        }
    }
}
