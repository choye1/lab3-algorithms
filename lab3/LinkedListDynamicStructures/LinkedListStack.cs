﻿using Loggers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicStructuresEntities
{
    public class LinkedListStack<T>
    {
        private LinkedList<T> list = new LinkedList<T>();
        Logger logger = new Logger();

        // Добавление элемента в стек
        public void Push(T data)
        {
            list.AddLast(data);
        }

        // Удаление элемента из стека
        public T Pop()
        {
            if (!IsEmpty())
            {
                T top = list[list.Count() - 1];
                list.RemoveAt(list.Count() - 1); 
                return top;
            }

            return default;
        }

        // Получение верхнего элемента
        public T Peek()
        {
            return list.Peek();
        }

        // Проверка на пустоту
        public bool IsEmpty()
        {
            return list.IsEmpty();
        }
        public void Print()
        {
            if (IsEmpty())
            {
                logger.WriteLine("Stack is empty.");
                return;
            }

            var current = list.Peek();
            while (current != null)
            {
                logger.Write($"{current} ");
                current = list.RemoveFirst();
            }
        }

        public List<T> GetStack()
        {
            List<T> values = new List<T>();
            var current = list.Peek();
            while (current != null)
            {
                values.Add(current);
                current = list.RemoveFirst();
            }
            return values;
        }

        public LinkedList<T> LLGetStack()
        {
            return list;
        }

        public int Count()
        {
            int count = 0;
            var current = list.Peek();
            while (current != null)
            {
                count++;
                current = list.RemoveFirst();
            }
            return count;
        }
        
    }

}
