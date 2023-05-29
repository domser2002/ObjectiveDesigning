using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

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
        //public class MyCommand : IMyCommand
        //{
        //    public string[] Arguments { get; set; }
        //    public string? CommandName { get; set; }
        //    public MyCommand()
        //    {
        //        Arguments = Array.Empty<string>();
        //    }
        //    public void Execute()
        //    {
        //        // Implementation of the Execute method
        //    }
        //    public System.Xml.Schema.XmlSchema? GetSchema() => this.GetSchema();
        //    public void ReadXml(System.Xml.XmlReader reader) => this.ReadXml(reader);
        //    public void WriteXml(System.Xml.XmlWriter writer) => this.WriteXml(writer);
        //}
        public static void Main()
        {
            // Create an instance of the class that implements the interface
            //var myCommand = new MyCommand
            //{
            //    Arguments = new string[] { "arg1", "arg2", "arg3" },
            //    CommandName = "MyCommand"
            //};

            //// Create an XmlSerializer instance for the interface type
            //var serializer = new XmlSerializer(typeof(MyCommand));

            //// Serialize the instance to XML
            //using (var writer = new StringWriter())
            //{
            //    serializer.Serialize(writer, myCommand);
            //    string xml = writer.ToString();
            //    Console.WriteLine(xml);
            //}
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
