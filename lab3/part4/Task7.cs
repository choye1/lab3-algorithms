using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicStructuresEntities;
using ListDynamicStructures;

namespace part4
{
    public class Task7<T> 
    {
        CustomQueue<T> queue = new CustomQueue<T>();

        public List<T> Deleter (List<T> list, T val)
        {
            foreach (T item in list)
            {
                if (!item.Equals(val))
                {
                    queue.Enqueue(item);
                }
            }   
            return queue.GetQueue();
        }
    }
}
