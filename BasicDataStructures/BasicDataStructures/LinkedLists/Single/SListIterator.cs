using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicDataStructures.LinkedLists.Single
{
    public sealed class SListIterator<T>
    {
        public SNode<T> Current { get; private set; }

        public SNode<T> Head { get; private set; }

        public SListIterator(SLinkedList<T> list)
        {
            Current = list.Head;
            Head = list.Head;
        }

        public void Start()
        {
            Current = Head;
        }

        public void MoveNext()
        {
            if (IsValid())
                Current = Current.Next;
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

        public SNode<T> GetNode()
        {
            return Current;
        }
    }
}
