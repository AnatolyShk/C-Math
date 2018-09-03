using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinHeap
{
    public class BinaryHeap<T>
           where T : IComparable
    {

        private List<T> list = new List<T>();

        public int HeapSize
        {
            get
            {
                return this.list.Count();
            }   
        }
        public void Put(T part)
        {
            list.Add(part);
            int i = HeapSize - 1;
            int parent = (i - 1) / 2;

            while (i > 0 && list[parent].CompareTo(list[i]) < 0)
            {
                T temp = list[i];
                list[i] = list[parent];
                list[parent] = temp;

                i = parent;
                parent = (i - 1) / 2;
            }

        }
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < list.Count(); i++)
            
               yield return list[i];
            
        }
        public T[] ToArray()
        {
            return list.ToArray();
        }

        public void heapify(int i)
        {
            int right;
            int left;
            int larg;


            left = 2 * i + 1;
            right = 2 * i + 2;
            larg = i;

            if (left < HeapSize && list[left].CompareTo(list[larg]) < 0)
            {
                larg = left;

            }
            if (right < HeapSize && list[right].CompareTo(list[larg]) < 0)
            {
                larg = right;

            }

            T buf = list[i];
            list[i] = list[larg];
            list[larg] = buf;
            i = larg;


        }

        public int goRound(int i)
        {
            int right;
            int left;
            int larg;

            for (;;)
            {

                left = 2 * i + 1;
                right = 2 * i + 2;
                larg = i;


                if (list[left] != null && left < HeapSize - 1)
                {
                    goRound(left);

                }
                if (list[right] != null && right < HeapSize - 1)
                {
                    goRound(right);

                }

                return larg;



            }
        }
        public T getmax()
        {

            T result = list[0];
         
            
            return result;
        }
        public void clear()
        {
            list.Clear();
        }
        public void Remove()
        {
            T result = list[0];
            list.RemoveAt(0); 
        }
        public int Count()
        {
            return (list.Count());
        }
        public T View(int i)
        {
            return list[i];

        }
    }
}