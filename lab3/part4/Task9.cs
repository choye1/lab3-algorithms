using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using DynamicStructuresEntities;
using ListDynamicStructures;

namespace part4
{
    public class Task9<T> 
    {
        LinkedListQueue<T> queue = new LinkedListQueue<T>();

        public DynamicStructuresEntities.LinkedList<T> GetResult(DynamicStructuresEntities.LinkedList<T> list1, DynamicStructuresEntities.LinkedList<T> list2)
        {
            for (int i = 0; i < list1.Count(); i++)
            {
                queue.Enqueue(list1[i]);
            }
            for (int i = 0; i < list2.Count(); i++)
            {
                queue.Enqueue(list2[i]);
            }
            return queue.LLGetQueue();
        }
    }
}
