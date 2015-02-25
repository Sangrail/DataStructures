using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csInterviewRevision.BasicDataStructures.LinkedLists.Single
{
    public class SNode<T>
    {
        private T _data;
        private SNode<T> _next;

        public SNode(T data)
        {
            _data = data;
            _next = null;
        }

        public SNode<T> InsertAfter(T item)
        {
            SNode<T> newNode = new SNode<T>(item);

            newNode._next = _next;
            _next = newNode;

            return newNode;
        }

        public SNode<T> Next
        {
            get { return _next; }
            set { _next = value; }
        }

        public T Data
        {
            get { return _data; }
            set { _data = value; }
        }
    }
}
