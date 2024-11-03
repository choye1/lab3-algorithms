using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicStructuresEntities;

namespace part4
{
    public class Task2<T> 
    {
        CustomQueue<T> queue = new CustomQueue<T>();
        CustomStack<T> stack = new CustomStack<T>();

        public List<T> getNewList(List<T> list)
        {
            List<T> result = new List<T>();
            
            foreach (var item in list)
            {
                queue.Enqueue(item);
            }

            T buffer = queue.Dequeue();
            while (!queue.IsEmpty())
            {
                result.Add(queue.Top());
            }
            result.Add(buffer);
            
            return result;
        }
    }
}
