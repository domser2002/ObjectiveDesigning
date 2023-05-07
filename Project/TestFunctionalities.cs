using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public static class TestFunctionalities
    {
        public static void TestAdapter(Objects first,Hashmap second,Stacks third)
        {
            //test
            Console.WriteLine("First representation:");
            first.Display();
            Console.Write("\n\n\n");
            Console.WriteLine("Second representation:");
            IRepresentation a = new HmAdapter(second);
            a.Display();
            Console.Write("\n\n\n");
            Console.WriteLine("Third representation:");
            IRepresentation st = new StAdapter(third);
            st.Display();
            //select test
            Console.Write("\n\n\n");
            first.Select();
            Console.Write("\n\n\n");
            st.Select();
        }
        public static void TestIterator(Objects first, Hashmap second, Stacks third)
        {
            IRepresentation a = new HmAdapter(second);
            IRepresentation st = new StAdapter(third);
            SortedArray L = new((IRepresentation r1, IRepresentation r2) =>
            {
                if (r1.Equals(r2)) return 0;
                if (r1.GetHashCode() > r2.GetHashCode()) return 1;
                else return -1;
            }
            );
            L.Insert(first);
            L.Insert(a);
            L.Insert(st);
            var x = Extensions.Find(L.GetForwardIterator(), (IRepresentation arg1) => (arg1.GetHashCode().Equals(a.GetHashCode())));
            x?.Display();
            Console.WriteLine(Extensions.CountIf(L.GetForwardIterator(),
                (IRepresentation arg1) => (arg1.GetHashCode().Equals(st.GetHashCode()))));
        }
    }
}
