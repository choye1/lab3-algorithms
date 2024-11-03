using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicStructuresEntities;

namespace part4
{
    public class Task12<T> 
    {
        CustomQueue<T> queue = new CustomQueue<T>();

        public List<T> Change (List<T> list, T x, T y)
        {
            foreach (var item in list)
            {
                if (item.Equals(x))
                {
                    queue.Enqueue(y);
                }
                else if (item.Equals(y))
                {
                    queue.Enqueue(x);
                }
                else
                {
                    queue.Enqueue(item);
                }
            }
            return queue.GetQueue();
        }
    }
}
