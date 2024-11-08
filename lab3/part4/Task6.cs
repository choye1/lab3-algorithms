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
        CustomQueue<T> queue = new CustomQueue<T>();

        public List<T> AddVal (T val, List<T> list)
        {
            for (int i = 0; i < list.Count(); i++)
            {
                if (list[i].CompareTo(val) < 0)    
                {
                    queue.Enqueue(val);
                    val = list[i+1];
                }
                queue.Enqueue(list[i]);
            }
            return queue.GetQueue();
        }
    }
}
