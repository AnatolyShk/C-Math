using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinHeap
{
    class MeEnumerator<T>:IEnumerator<T>
          where T : IComparable
    {
        int index = -1;
        public  PriorityQueueBinHeap<T> stheList;
        public MeEnumerator(PriorityQueueBinHeap<T> theList)
        {
            stheList = theList;
        }
        public T Current
        {
            get
            {
                if (index < 0 || stheList.Count() <= index)
                    return default(T);
                return stheList.get(index);
            }
        }
        public void Dispose()
        {
          
        }
        object System.Collections.IEnumerator.Current
        {
            get { return Current; }
        }
        public bool MoveNext()
        {
            return ++index < stheList.Count();
        }
        public void Reset()
        {
            index = -1;
        }
    }
}
