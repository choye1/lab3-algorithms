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
       
        public DynamicStructuresEntities.LinkedList<T> GetResult(DynamicStructuresEntities.LinkedList<T> list, T f, T e)
        {
            int index = -1;
            int eCount = 0;
            for (int i = 0; i < list.Count(); i++)
            {
                if (list[i].Equals(e))
                {
                    index = i; break;
                }
            }
            if (index == -1)
            {
                return list;
            }
            for (int i = 0; i < list.Count(); i++)
            {
                queue.Enqueue(list[i]);
                if (i == index && eCount == 0)
                {
                    queue.Enqueue(f);
                    eCount++;
                }
            }
            return queue.LLGetQueue();
        }
    }
}
