using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinHeap
{
    class PriorityQueueBinHeap<T> : PriorityQueue<T>
        where T : IComparable

    {
        private BinaryHeap<T> binaryheap;
        public PriorityQueueBinHeap()
            {
            binaryheap = new BinaryHeap<T>();
            }
        public override T Item()
        {
            return (binaryheap.getmax());
        }
        public T [] ToArray()
        {
            return binaryheap.ToArray();
        }
        public override void Remove()
        {
            binaryheap.Remove();
        }
        public override void Put(T element)
        {
            binaryheap.Put(element);
        }
        public bool Empty()
        {
            return Count()==0;
        }
        public override int Count()
        {
            
            return binaryheap.Count();
        }
        public override void Clear()
        {
            binaryheap.clear();
        }
        public override T get(int i)
        {


            return (binaryheap.View(i));

        }
        public override void heapify(int i)
        {
            binaryheap.heapify(i);
        }
        public override int goRound(int i)
        {
            return binaryheap.goRound(i);
        }
        public IEnumerator<T> GetEnumerator()
        {
            return new MeEnumerator<T>(this);
        }






        }
}

