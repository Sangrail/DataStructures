using BasicDataStructures.LinkedLists.Double;
using BasicDataStructures.LinkedLists.Single;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace BasicDataStructures
{
    class Program
    {
        private static IEnumerable<Tuple<int,int>> QueryIndices3()
        {
            return from x in Enumerable.Range(0, 10)
                   from y in Enumerable.Range(0, 10)
                   where x + y == 10
                   select Tuple.Create<int, int>(x, y);
        }

        private static IEnumerable<Tuple<int, int>> QueryIndices4()
        {
            return from x in Enumerable.Range(0, 10)
                   from y in Enumerable.Range(0, 10)
                   where x + y < 10
                   orderby (x*x + y*y) descending
                   select Tuple.Create<int, int>(x, y);
        }

        static void Main(string[] args)
        {
            DLinkedList<int> dll = new DLinkedList<int>();
 
            dll.Append(2);
            dll.Append(3);
            dll.Append(4);

            dll.Prepend(1);
            dll.Prepend(0);

            var it = dll.GetIterator();

            while(it.IsValid())
            {
                Console.WriteLine("{0}", it.GetData());
                it.MoveNext();
            }


            DNode<int> t = dll.Tail;

            while(t!=null)
            {
                Console.WriteLine("{0}", t.Data);

                t = t.Prev;
            }
           
            Console.WriteLine("Press ANY key to continue");
            Console.ReadLine();
        }
    }
}
