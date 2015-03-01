using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicDataStructures.LinkedLists.Double
{
    public class DLinkedList<T>
    {
        public DNode<T> Head { get; private set; }
        public DNode<T> Tail { get; private set; }

        public int Count
        {
            get;
            private set;
        }

        public DLinkedList()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }

        public void Append(T item)
        {
            if (Count == 0)
            {
                Head = Tail = new DNode<T>(item);
            }
            else
            {
                Tail = Tail.InsertAfter(item);
            }

            Count++;
        }

        public void Prepend(T item)
        {
            if (Count == 0)
            {
                Head = Tail = new DNode<T>(item);
            }
            else
            {
                Head = Head.InsertBefore(item);
            }

            Count++;
        }

        #region Enumerables
        /// <summary>
        /// This is a throw back to how the STL works for c++ - not suitable for c#
        /// Use IEnumerable/IEnumerator yield/return pattern
        /// </summary>
        /// <returns></returns>
        public DListIterator<T> GetIterator()
        {
            return new DListIterator<T>(this);
        }
        #endregion
    }
}
