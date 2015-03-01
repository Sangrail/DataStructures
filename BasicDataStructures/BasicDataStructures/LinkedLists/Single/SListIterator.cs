using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicDataStructures.LinkedLists.Single
{
    public class SListIterator<T>
    {
        public SNode<T> Current { get; private set; }

        public SListIterator(SLinkedList<T> list)
        {
            Current = list.Head;
        }

        public void MoveNext()
        {
            Current = Current.Next;
        }

        public bool IsValid()
        {
            return (Current != null);
        }

        public T GetData()
        {
            return Current.Data;
        }

        public SNode<T> GetNode()
        {
            return Current;
        }
    }
}
