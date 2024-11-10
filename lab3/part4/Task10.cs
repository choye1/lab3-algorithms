using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicStructuresEntities;
using ListDynamicStructures;

namespace part4
{
    public class Task10<T>
    {
        LinkedListQueue<T> queue1 = new LinkedListQueue<T>();
        LinkedListQueue<T> queue2 = new LinkedListQueue<T>();
        DynamicStructuresEntities.LinkedList<T>[] result = new DynamicStructuresEntities.LinkedList<T>[2];
        int count = 0;

        public DynamicStructuresEntities.LinkedList<T>[] GetResult(DynamicStructuresEntities.LinkedList<T> list, T val) 
        {
            int indexVal = -1;
            for(int i = 0; i < list.Count(); i++)
            {
                if (list[i].Equals(val))
                {
                    indexVal = i; break;
                }
            }

            if (indexVal == -1)
            {
                DynamicStructuresEntities.LinkedList<T> l = new DynamicStructuresEntities.LinkedList<T>();
                result[0] = list;
                result[1] = l;
                return result;
            }

            for (int i = 0; i <= indexVal; i++)
            {
                queue1.Enqueue(list[i]);
            }
            
            for (int i = indexVal + 1; i < list.Count(); i++)
            {
                queue2.Enqueue(list[i]);
            }
            result[0] = queue1.LLGetQueue();
            result[1] = queue2.LLGetQueue();

            return result; 
        }
    }
}
