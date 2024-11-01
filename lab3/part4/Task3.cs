using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicStructuresEntities;

namespace part4
{
    public class Task3<T>
    {
        CustomStack<T> stack = new CustomStack<T>();
        int count = 0;

        public int Counter(List<T> list)
        {
            foreach (var item in list)
            {
                stack.Push(item);
                if (stack.UniqueValue(item))
                {
                    count++;
                }
            }

            return count;
        }
    }
}
