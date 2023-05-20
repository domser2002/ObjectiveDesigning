using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public enum Type { laboratory, tutorials, lecture, other };
    public enum Rank { KiB, MiB, GiB, TiB };
    public class Program
    {
        //first representation
        public static Objects first = ConstructData.ConstructFirst();
        //second representation
        public static Hashmap second = ConstructData.ConstructSecond();
        //third representation
        public static Stacks third = ConstructData.ConstructThird();
        public static void Main()
        {
            Console.WriteLine("Possible commands:");
            Console.WriteLine("list <name_of_the_class>");
            Console.WriteLine("find <name_of_the_class> [<name_of_field> =|<|> value]");
            Console.WriteLine("exit");
            Processor p= new();
            while (true)
            {
                Console.WriteLine("Type your command:");
                string? s = Console.ReadLine();
                if (s is not null)
                {
                    if (s.ToLower() == "test adapter")
                    {
                        TestFunctionalities.TestAdapter(first, second, third);
                    }
                    else if (s.ToLower() == "test iterator")
                    {
                        TestFunctionalities.TestIterator(first, second, third);
                    }
                    else
                    {
                        p.Process(s);
                    }
                }
            }
        }
    }
}
