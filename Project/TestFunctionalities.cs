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
            SortedArray L = new((IObject obj1, IObject obj2) =>
            {
                if (obj1.GetType() != obj2.GetType()) return 0;
                return obj1.GetHashCode().CompareTo(obj2.GetHashCode());
            }
            );
            //IObject? a = null;
            foreach(Student s in first.Students)
            {
                L.Insert(s);
            }
            foreach (Room r in first.Rooms)
            {
                L.Insert(r);
            }
            foreach (Teacher t in first.Teachers)
            {
                L.Insert(t);
            }
            foreach (Class c in first.Classes)
            {
                L.Insert(c);
            }
            //var x = Extensions.Find(L, (IObject arg1) => (arg1.GetHashCode().Equals(a.GetHashCode())),true);
            //x?.Display();
            //Console.WriteLine(Extensions.CountIf(L.GetForwardIterator(),
            //    (IRepresentation arg1) => (arg1.GetHashCode().Equals(st.GetHashCode()))));
        }
    }
}
