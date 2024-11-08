using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicStructuresEntities;
using ListDynamicStructures;

namespace part4
{
    public class Task3<T> 
    {
        LinkedListStack<T> stack = new LinkedListStack<T>();
        int count = 0;

        public int GetResult(DynamicStructuresEntities.LinkedList<T> list)
        {
            for (int i = 0; i < list.Count(); i++)
            {
                stack.Push(list[i]);
                if (stack.UniqueValue(list[i]))
                {
                    count++;
                }
            }

            return count;
        }
    }
}
