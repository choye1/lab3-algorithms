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
            for(int i = 0; i < list.Count(); i++)
            {
                count++;
                if (!list[i].Equals(val))
                {
                    queue1.Enqueue(list[i]);
                }
                else
                {
                    // проходим по оставшемуся списку и записываем элем-ты во вторую очередь
                    for (int j = count; j < list.Count(); j++)
                    {
                        queue2.Enqueue(list[j]);
                    }
                    // проходим заново по оставшимся элем-там и удаляем их, чтобы они не записывались в первую очередь
                    for (int j = count; j < list.Count(); j++)
                    {
                        list.RemoveAt(j);
                    }
                }
            }
            result[0] = queue1.LLGetQueue();
            result[1] = queue2.LLGetQueue();

            return result; 
        }
    }
}
