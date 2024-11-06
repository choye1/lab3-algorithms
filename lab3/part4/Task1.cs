using DynamicStructuresEntities;
using ListDynamicStructures;

namespace part4
{
    public class Task1<T> 
    {
        CustomStack<T> stack = new CustomStack<T>();
        public List<T> getNewList (List<T> list)
        {
            foreach (var item in list)
            {   
                stack.Push(item);
            }
            List<T> newList = stack.GetStack();
            return newList;
        }
    }
}
