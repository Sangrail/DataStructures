using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicDataStructures.LinkedLists.Double
{
    public class DListIterator<T>
    {
        public DNode<T> Current { get; private set; }

        public DListIterator(DLinkedList<T> list)
        {
            Current = list.Head;
        }

        public void MoveNext()
        {
            Current = Current.Next;
        }

        public void MovePrev()
        {
            Current = Current.Prev;
        }

        public bool IsValid()
        {
            return (Current != null);
        }

        public T GetData()
        {
            return Current.Data;
        }

        public DNode<T> GetNode()
        {
            return Current;
        }
    }
}
