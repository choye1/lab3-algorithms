using DynamicStructuresEntities;
using ListDynamicStructures;

namespace part4
{
    public class Task1<T> 
    {
        LinkedListStack<T> stack = new LinkedListStack<T>();
        DynamicStructuresEntities.LinkedList<T> newList = new DynamicStructuresEntities.LinkedList<T>();
         
        public DynamicStructuresEntities.LinkedList<T> GetResult (DynamicStructuresEntities.LinkedList<T> list)
        {
            for (int i = 0; i < list.Count(); i++)
            {
                stack.Push(list[i]);
            }
            for (int i = 0; i < list.Count(); i++)
            {
                newList.AddLast(stack.Pop());
            }
            
            return newList;
        }
    }
}
