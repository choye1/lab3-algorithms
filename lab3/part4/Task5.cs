using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicStructuresEntities;

namespace part4
{
    public class Task5<T> 
    {
        CustomQueue<T> queue = new CustomQueue<T>();
        int count = 0;

        public List<T> Insert2 (List<T> list, T val)
        {
            foreach (T item in list)
            {
                queue.Enqueue(item);
                if (item.Equals(val))
                {
                    foreach( T item2 in list) 
                    {
                       queue.Enqueue((T)item2);
                    }
                }
            }
            return queue.GetQueue();
        }
    }
}
