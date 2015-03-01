using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicDataStructures.LinkedLists.Single
{
    public class SListIterator<T>
    {
        SNode<T> _current;

        public SListIterator(SLinkedList<T> list)
        {
            _current = list.Head;
        }

        public void MoveNext()
        {
            _current = _current.Next;
        }

        public bool IsValid()
        {
            return (_current != null);
        }

        public T GetData()
        {
            return _current.Data;
        }

        public SNode<T> GetNode()
        {
            return _current;
        }
    }
}
