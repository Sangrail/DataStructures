using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicDataStructures.LinkedLists.Single
{
    public class SLinkedList<T>
    {
        SNode<T> _head;
        SNode<T> _tail;

        int _count;

        public SLinkedList()
        {
            _head = null;
            _tail = null;
            _count = 0;
        }

        public SNode<T> Head
        {
            get { return _head; }
        }

        public SNode<T> Tail
        {
            get { return _tail; }
        }

        public void Append(T item)
        {
            if (_count == 0)
            {
               _head = new SNode<T>(item);
               _tail = _head;
            }
            else
                _tail = _tail.InsertAfter(item);

            Count++;
        }

        public void Prepend(T item)
        {
            SNode<T> newNode = new SNode<T>(item);

            newNode.Next = _head;
            _head = newNode;

            Count++;
        }

        public SNode<T> Find(T item)
        {
            var iter = GetIterator();

            while (iter.IsValid())
            {
                SNode<T> curr = iter.Get();

                if (EqualityComparer<T>.Default.Equals(curr.Data, item))
                    return curr;

                iter.MoveNext();
            }

            return null;
        }

        private SNode<T> FindPrevious(T item)
        {
            var iter = GetIterator();

            while (iter.IsValid())
            {
                SNode<T> curr = iter.Get();

                if (curr.Next != null && EqualityComparer<T>.Default.Equals(curr.Next.Data, item))
                    return curr;

                iter.MoveNext();
            }

            return null;
        }

        public void Remove(T item)
        {
            SNode<T> found = FindPrevious(item);

            if(found != null)
            {
                found.Next = found.Next.Next;
            }

            Count--;
        }

        public void RemoveHead()
        {
            SNode<T> temp = _head;

            _head = _head.Next;

            temp = null;

            Count--;
        }

        public void RemoveTail()
        {
            SNode<T> currNode = _head;

            while (currNode != null)
            {
                if (currNode.Next != null && (currNode.Next == _tail))
                    break;

                currNode = currNode.Next;
            }

            _tail = currNode;

            if(_tail != null)
                _tail.Next = null;
            {
                _head = null;
            }

            Count--;
        }

        public SListIterator<T> GetIterator()
        {
            return new SListIterator<T>(this);
        }

        public void Clear()
        {
            while(_count != 0)
            {
                RemoveTail();
            }
        }


        public void Reverse(SNode<T> node)
        {
            if (node == null)
                return;

            Reverse(node.Next);

            RemoveHead();
            Append(node.Data);
        }

        public void Reverse()
        {
            Reverse(Head);
        }

        public int Count
        {
            get { return _count; }
            private set { _count = value; }
        }
    }
}
