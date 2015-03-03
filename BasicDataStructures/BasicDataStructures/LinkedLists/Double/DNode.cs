using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicDataStructures.LinkedLists.Double
{
    [Serializable()]
    public sealed class DNode<T>
    {
        public T Data { get; set; }

        public DNode<T> Prev { get; set; }
        public DNode<T> Next { get; set; }

        public DNode(T data)
        {
            this.Data = data;
            this.Prev = null;
            this.Next = null;
        }

        public DNode<T> InsertAfter(T item)
        {
            DNode<T> newNode = new DNode<T>(item);

            newNode.Prev = this;
            newNode.Next = Next;
            
            if (Next != null)
                Next.Prev = newNode;
            
            Next = newNode;

            return newNode;
        }

        public DNode<T> InsertBefore(T item)
        {
            DNode<T> newNode = new DNode<T>(item);

            newNode.Prev = Prev;

            Prev = newNode;
                        
            newNode.Next = this;

            return newNode;
        }
    }
}
