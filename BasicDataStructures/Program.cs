using BasicDataStructures.LinkedLists.Double;
using BasicDataStructures.LinkedLists.Single;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.Serialization.Formatters.Binary;
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

            PrintForwardList(dll);

            dll.Reverse();

            PrintForwardList(dll);

            Console.WriteLine("Press ANY key to continue");
            Console.ReadLine();
        }

        private static void LoadDll()
        {
            using (Stream stream = File.Open("data.bin", FileMode.Open))
            {
                BinaryFormatter bin = new BinaryFormatter();

                var lizards2 = (DLinkedList<int>)bin.Deserialize(stream);
            }
        }

        private static void SaveDLL(DLinkedList<int> dll)
        {
            using (Stream stream = File.Open("data.bin", FileMode.Create))
            {
                BinaryFormatter bin = new BinaryFormatter();
                bin.Serialize(stream, dll);
            }
        }

        private static void PrintForwardList(DLinkedList<int> dll)
        {
            Console.WriteLine("");

            var it = dll.GetIterator();

            it.Start();

            while (it.IsValid())
            {
                Console.WriteLine("{0}", it.GetData());
                it.MoveNext();
            }
        }

        private static void PrintReverseList(DLinkedList<int> dll)
        {
            Console.WriteLine("");

            var itr = dll.GetIterator();
            itr.End();

            while (itr.IsValid())
            {
                Console.WriteLine("{0}", itr.GetData());
                itr.MovePrev();
            }
        }
    }
}
