using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicDataStructures.LinkedLists.Double
{
    public sealed class DListIterator<T>
    {
        public DNode<T> Current { get; private set; }
        public DNode<T> Head { get; private set; }
        public DNode<T> Tail { get; private set; }

        public DListIterator(DLinkedList<T> list)
        {
            Current = list.Head;
            Head = list.Head;
            Tail = list.Tail;
        }

        public void Start()
        {
            Current = Head;
        }

        public void End()
        {
            Current = Tail;
        }

        public void MoveNext()
        {
            if(IsValid())
                Current = Current.Next;
        }

        public void MovePrev()
        {
            if (IsValid())
                Current = Current.Prev;
        }

        public bool IsValid()
        {
            return (Current != null);
        }

        public T GetData()
        {
            if (IsValid())
                return Current.Data;
            else
                throw new Exception("Data not available: node is null");
        }

        public DNode<T> GetNode()
        {
            return Current;
        }
    }
}
