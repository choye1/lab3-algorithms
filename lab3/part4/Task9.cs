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
        CustomQueue<T> queue = new CustomQueue<T>();

        public List<T> Unification(List<T> list1, List<T> list2)
        {
            foreach (T item in list1)
            {
                queue.Enqueue(item);
            }
            foreach (T item in list2)
            {
                queue.Enqueue(item);
            }
            return queue.GetQueue();
        }
    }
}
