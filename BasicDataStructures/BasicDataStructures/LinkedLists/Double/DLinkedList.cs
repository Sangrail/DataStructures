﻿using System;
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

        public void RemoveHead()
        {
            if (Count != 0)
            {

            }
        }

        public void RemoveTail()
        {
            if (Count != 0)
            {
                var node = Tail;

                Tail = Tail.Prev;

                node.Prev = null;
                node.Next = null;

                Count--;
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

        public bool IsEmpty()
        {
            return (Count == 0);
        }

        public DNode<T> Find(T item)
        {
            var iter = GetIterator();

            while (iter.IsValid())
            {
                DNode<T> curr = iter.GetNode();

                if (EqualityComparer<T>.Default.Equals(curr.Data, item))
                    return curr;

                iter.MoveNext();
            }
            return null;
        }

        /// <summary>
        /// Removes the first instance of item in the list
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public DNode<T> Remove(T item)
        {
            DNode<T> two = Find(item);

            if (two != null)
            {
                var one = two.Prev;
                var three = two.Next;

                if(three!=null)
                    three.Prev = one;

                if(one!=null)
                 one.Next = three;

                Count--;
            }

            return two;
        }

        public void RemoveAll(T item)
        {
            while (Remove(item) != null) { }
        }
    }
}
