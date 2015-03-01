using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicDataStructures.LinkedLists.Double
{
    public class DListIterator<T>
    {
        DNode<T> _current;

        public DListIterator(DLinkedList<T> list)
        {
            _current = list.Head;
        }

        public void MoveNext()
        {
            _current = _current.Next;
        }

        public void MovePrev()
        {
            _current = _current.Prev;
        }

        public bool IsValid()
        {
            return (_current != null);
        }

        public T GetData()
        {
            return _current.Data;
        }

        public DNode<T> GetNode()
        {
            return _current;
        }
    }
}
