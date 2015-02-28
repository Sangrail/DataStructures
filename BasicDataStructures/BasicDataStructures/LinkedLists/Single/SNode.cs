using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicDataStructures.LinkedLists.Single
{
    public class SNode<T>
    {
        public SNode(T data)
        {
            Data = data;
            Next = null;
        }

        public SNode<T> InsertAfter(T item)
        {
            SNode<T> newNode = new SNode<T>(item);

            newNode.Next = Next;
            Next = newNode;

            return newNode;
        }

        public SNode<T> Next { get; set; }

        public T Data { get; set; }
    }
}
