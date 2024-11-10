using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicStructuresEntities;
using ListDynamicStructures;

namespace part4
{
    public class Task6<T>  where T : IComparable<T>
    {
        LinkedListQueue<T> queue = new LinkedListQueue<T>();

        public DynamicStructuresEntities.LinkedList<T> GetResult (DynamicStructuresEntities.LinkedList<T> list, T val)
        {
            for (int i = 0; i < list.Count(); i++)
            {
                if (list[i].CompareTo(val) > 0)    
                {
                    queue.Enqueue(val);
                    if (i + 1 != list.Count())
                    {
                        val = list[i + 1];
                    }
                    
                }
                queue.Enqueue(list[i]);
            }
            return queue.LLGetQueue();
        }
    }
}
