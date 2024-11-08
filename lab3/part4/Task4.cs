using DynamicStructuresEntities;
using ListDynamicStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace part4
{
    public class Task4<T> 
    {
        LinkedListStack<T> stack = new LinkedListStack<T>();
        int count = 0;

        public DynamicStructuresEntities.LinkedList<T> GetResult(DynamicStructuresEntities.LinkedList<T> list)
        {
            for (int i = 0; i < list.Count(); i++)
            {
                stack.Push(list[i]);

                if (!stack.UniqueValue(list[i]))
                {
                    stack.Pop();
                }
            }

            return stack.LLGetStack();
        }
    }
}
