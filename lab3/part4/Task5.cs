using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicStructuresEntities;
using ListDynamicStructures;

namespace part4
{
    public class Task5<T> 
    {
        LinkedListQueue<T> queue = new LinkedListQueue<T>();
        int count = 0;

        public DynamicStructuresEntities.LinkedList<T> GetResult (DynamicStructuresEntities.LinkedList<T> list, T val)
        {
            for (int i = 0; i < list.Count(); i++)
            {
                queue.Enqueue(list[i]);
                if (list[i].Equals(val))
                {
                    for (int j = 0; j < list.Count(); j++)
                    {
                        queue.Enqueue((T)list[j]);
                    }
                }
            }
            return queue.LLGetQueue();
        }
    }
}
