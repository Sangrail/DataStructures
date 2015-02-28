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
            //SLinkedList<string> vowels = new SLinkedList<string>();

            //vowels.Append("a");
            //vowels.Append("e");
            //vowels.Append("i");
            //vowels.Append("o");
            //vowels.Append("u");

            //foreach(var vowel in vowels)
            //{
            //    Console.WriteLine(vowel);
            //}

            DLinkedList<int> dll = new DLinkedList<int>();

            DNode<int> n1 = new DNode<int>(0);

            n1.InsertAfter(1);


            Console.WriteLine("Press ANY key to continue");
            Console.ReadLine();
        }
    }
}
