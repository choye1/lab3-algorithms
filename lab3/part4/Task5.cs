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

        //public List<T> Insert2 (List<T> list, T val)
        //{
        //    foreach (var item in list)
        //    {
        //        count++;
        //        queue.Enqueue(item);
        //        if (item.Equals(val))
        //        {
        //            for (int i = count; i < list.Count; i++)
        //            {

        //            }
        //        }
        //    }
        //}
    }
}
