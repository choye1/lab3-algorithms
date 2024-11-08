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
        CustomStack<T> stack = new CustomStack<T>();
        int count = 0;

        public List<T> GetResult(List<T> list)
        {
            foreach (var item in list)
            {
                stack.Push(item);

                if (!stack.UniqueValue(item))
                {
                    stack.Pop();
                }
            }

            return stack.GetStack();
        }
    }
}
