﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicDataStructures.LinkedLists.Single
{
    public sealed class SLinkedList<T> : 
        IEnumerable<T>
    {
        public SNode<T> Head { get; private set; }
        public SNode<T> Tail { get; private set; }

        public int Count
        {
            get;
            private set;
        }

        public SLinkedList()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }

        public void Append(T item)
        {
            if (Count == 0)
            {
               Head = new SNode<T>(item);
               Tail = Head;
            }
            else
                Tail = Tail.InsertAfter(item);

            Count++;
        }

        public void Prepend(T item)
        {
            SNode<T> newNode = new SNode<T>(item);

            newNode.Next = Head;
            Head = newNode;
           
            if (Count == 0)
            {
                Tail = Head;
            }

            Count++;
        }

        public SNode<T> Find(T item)
        {
            var iter = GetIterator();

            while (iter.IsValid())
            {
                SNode<T> curr = iter.GetNode();

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
                SNode<T> curr = iter.GetNode();

                if (curr.Next != null && EqualityComparer<T>.Default.Equals(curr.Next.Data, item))
                    return curr;

                iter.MoveNext();
            }

            return null;
        }

        public SNode<T> Remove(T item)
        {
            SNode<T> found = FindPrevious(item);

            if(found != null)
            {
                found.Next = found.Next.Next;
                Count--;
            }

            return found;
        }

        public void RemoveAll(T item)
        {
            while (Remove(item) != null) { }
        }

        public void RemoveHead()
        {
            if (Count != 0)
            {
                Head = Head.Next;
                Count--;

                if(Count == 0)
                {
                    Tail = null;
                }
            }
        }

        public void RemoveTail()
        {
            SNode<T> currNode = Head;

            if (Count != 0)
            {
                if (Count == 1)
                {
                    Head = null;
                    Tail = null;

                    Count = 0;
                }
                else
                {
                    while (currNode.Next != Tail)
                    {
                         currNode = currNode.Next;
                    }

                    currNode.Next = null;
                    Tail = currNode;
                    
                    Count--;
                }
            }
        }

        public void Clear()
        {
            while (Count != 0)
            {
                RemoveTail();
            }

            Head = null;
            Tail = null;
        }

        private void Reverse(SNode<T> node)
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

        public bool IsEmpty()
        {
            return (Count == 0);
        }

        #region Enumerables
        /// <summary>
        /// This is a throw back to how the STL works for c++ - not suitable for c#
        /// Use IEnumerable/IEnumerator yield/return pattern
        /// </summary>
        /// <returns></returns>
        public SListIterator<T> GetIterator()
        {
            return new SListIterator<T>(this);
        }

        /// <summary>
        /// NOt sure what to do with this yet.
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This is the C# way to iterate (enumerate) elements
        /// </summary>
        /// <returns></returns>
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            SNode<T> current = Head;

            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
        #endregion
    }
}
