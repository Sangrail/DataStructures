using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csInterviewRevision.BasicDataStructures.LinkedLists.Double
{
    public class DNode<T>
    {
        private T _data;
        private DNode<T> _next;
        private DNode<T> _prev;


        public DNode(T data)
        {
            this._data = data;
        }

        public DNode<T> InsertAfter(T item)
        {
            DNode<T> newNode = new DNode<T>(item);

            newNode._prev = this;
            newNode._next = this._next;
            this._next = newNode;


            return newNode;
        }

        public DNode<T> InsertBefore(T item)
        {
            throw new NotImplementedException();
        }
    }
}
