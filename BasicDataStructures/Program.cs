using BasicDataStructures.LinkedLists.Double;
using BasicDataStructures.LinkedLists.Single;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csInterviewRevision
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
            Console.WriteLine("Press ANY key to continue");
            Console.ReadLine();
        }
    }
}
