using System;
using System.Collections.Generic;
using System.Collections;

namespace toDo1
{
    class Program
    {
        static void Main()
        {
            MyList<int> myList = new();

            myList.Add(15);
            myList.Add(50);
            myList.Add(27);

            int sum = 0;

            foreach (int number in myList)
            {
                sum += number;
            }

            Console.WriteLine(sum);
        }

        public class MyList<T> : IEnumerator, IEnumerable
        {
            private List<T> _item;

            public int Count { get 
                {
                    return _item.Count;
                } 
            }


            public MyList()
            {
                _item = new List<T>();
            }

            public void Add(T item)
            {
                _item.Add(item);
            }

            public void Remove(T item)
            {
                _item.Remove(item);
            }

            public void Clear(T item)
            {
                _item.Clear();
            }

            public bool Contains(T item)
            {
                return _item.Contains(item);
            }


            int position = -1;

            public bool MoveNext()
            {
                position++;
                return (position < _item.Count);
            }

            public void Reset()
            {
                position = -1;
            }

            public object Current
            {
                get
                {
                    try
                    {
                        return _item[position];
                    }
                    catch (IndexOutOfRangeException)
                    {
                        throw new InvalidOperationException();
                    }
                }

            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return this;
            }
        }
    }
}
