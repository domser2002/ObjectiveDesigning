using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public enum type { laboratory, tutorials, lecture, other };
    public enum rank { KiB, MiB, GiB, TiB };
    public class Program
    {
        public static void Main()
        {
            //first representation
            Objects first = ConstructData.ConstructFirst();
            //second representation
            Hashmap second = ConstructData.ConstructSecond();
            //third representation
            Stacks third = ConstructData.ConstructThird();
            //TestFunctionalities.TestAdapter(first,second,third);
            //TestFunctionalities.TestIterator(first, second, third);
            Console.WriteLine("Possible commands:");
            Console.WriteLine("list <name_of_the_class>");
            Console.WriteLine("find <name_of_the_class> [<name_of_field> =|<|> value]");
            Console.WriteLine("exit");
            //while (true)
            //{
            //    Console.WriteLine("Type your command:");
            //    string? s = Console.ReadLine();
            //    if (s is not null)
            //    {
            //        if (s == "exit")
            //        {
            //            break;
            //        }
            //        else
            //        {
            //            s.Process();
            //        }
            //    }
            //}
        }
    }
}
