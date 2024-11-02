using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicStructuresEntities;

namespace part4
{
    public class Task11<T>
    {
        CustomQueue<T> queue = new CustomQueue<T>();

        public List<T> Doubling(List<T> list)
        {
            foreach (T item in list)
            {
                queue.Enqueue(item);
            }
            foreach (T item in list)
            {
                queue.Enqueue(item);
            }
            return queue.GetQueue();     
        }
    }
}
