using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicStructuresEntities;

namespace part4
{
    public class Task10<T>
    {
        CustomQueue<T> queue1 = new CustomQueue<T>();
        CustomQueue<T> queue2 = new CustomQueue<T>();
        int count = 0;

        public List<T> GetNewList(List<T> list, T val) 
        {
            foreach (T item in list)
            {
                count++;
                if (!item.Equals(val))
                {
                    queue1.Enqueue(item);
                }
                else
                {
                    // проходим по оставшемуся списку и записываем элем-ты во вторую очередь
                    for (int i = count; i < list.Count; i++)
                    {
                        queue2.Enqueue(list[i]);
                    }
                    // проходим заново по оставшимся элем-там и удаляем их, чтобы они не записывались в первую очередь
                    for (int i = count; i < list.Count; i++)
                    {
                        list.RemoveAt(i);
                    }
                }
            }
            return queue1.GetQueue(); // тут надо как-то получить два списка
        }
    }
}
