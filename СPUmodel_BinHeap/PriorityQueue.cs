using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Contracts;

namespace BinHeap
{

    /// <summary>
    /// Абстрактный класс PriorityQueue{T} задает контейнер с доступом FIFO:
    /// Операции:
    /// создание Create: -> PriorityQueue{T}
    /// запросы:
    /// Item: PriorityQueue{T} -> T
    /// Empty: PriorityQueue{T} -> bool
    /// Count: PriorityQueue{T} -> int
    /// команды:
    /// Put: PriorityQueue{T} * T -> PriorityQueue{T}
    /// Remove: PriorityQueue{T} -> PriorityQueue{T}
    /// Clear: PriorityQueue{T} -> PriorityQueue{T}
    /// Аксиомы:
    /// Empty(Create)= true
    /// Далее q: PriorityQueue{T}, t: T
    /// Empty(Put(q, t)) = false
    /// Item(Put(q, t)) = t, если Empty(q) = true, и Item(q), если Empty(q) = false
    /// Remove(Put(q,t)) = Create, если Empty(q) = true, и Put(Remove(q), t), если Empty(q) = false
    /// Empty(Clear) = true    
    /// </summary>
    public abstract class PriorityQueue<T>
        where T : IComparable
    {
        private List<T> list = new List<T>();

        [Pure]
        public virtual T Item()
        {
            Contract.Requires<QueueException>(!Empty(), "Нарушение контракта: попытка чтения из пустой очереди");

            return default(T);
        }

        public virtual void Remove()
        {
            Contract.Requires<QueueException>(!Empty(), "Нарушение контракта: попытка удаления из  пустой очереди");
            Contract.Ensures(this.Count() == Contract.OldValue<int>(this.Count()) - 1);
        }
        public virtual void Put(T t)
        {
            Contract.Ensures(this.Count() == Contract.OldValue<int>(this.Count()) + 1);
        }
        [Pure]
        public bool Empty()
        {
            return Count() == 0;
        }
        [Pure]
        public virtual int Count()
        {
            Contract.Ensures(0 <= Contract.Result<System.Int32>());
            return default(System.Int32);
        }
        public virtual void Clear()
        {
            Contract.Ensures(Empty());
        }
        public virtual T get(int i)
        {
            return default(T);
        }
        public virtual void heapify(int i)
        {

        }
        public virtual int goRound(int i)
        {
            return default(int);
        }

    }

    public class QueueException : Exception
    {
        public QueueException() : base()
        {
        }


        public QueueException(String msg) : base(msg)
        {
        }
    }

}
