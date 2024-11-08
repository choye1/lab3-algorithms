using DynamicStructuresEntities;
using ListDynamicStructures;

namespace part4
{
    public class Task1<T> 
    {
        CustomStack<T> stack = new CustomStack<T>();
        List<T> newList;
        public List<T> getNewList (List<T> list)
        {
            foreach (var item in list)
            {   
                stack.Push(item);
            }
            for (int i = 0; i < list.Count; i++)
            {
                newList.Add(stack.Pop());
            }
            
            return newList;
        }
    }
}
