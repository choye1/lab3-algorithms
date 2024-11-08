using DynamicStructuresEntities;
using ListDynamicStructures;

namespace part4
{
    public class Task1<T> 
    {
        LinkedListStack<T> stack = new LinkedListStack<T>();
        System.Collections.Generic.LinkedList<T> newList;
         
        public System.Collections.Generic.LinkedList<T> GetResult (System.Collections.Generic.LinkedList<T> list)
        {
            foreach (var item in list)
            {   
                stack.Push(item);
            }
            for (int i = 0; i < list.Count; i++)
            {
                newList.AddLast(stack.Pop());
            }
            
            return newList;
        }
    }
}
