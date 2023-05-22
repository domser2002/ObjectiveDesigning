using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class NotFoundCommand : IMyCommand
    {
        public string[] Arguments { get; set; }
        public string? CommandName => (Arguments.Length > 0) ? Arguments[0] : null;
        public NotFoundCommand()
        {
            Arguments = Array.Empty<string>();
        }
        public void Execute()
        {
            Console.WriteLine("Couldn't find command: " + CommandName);
        }
    }
    public class Find : IMyCommand
    {
        public string[] Arguments { get; set; }
        public string? CommandName => "find";
        public Find()
        {
            Arguments = Array.Empty<string>();
        }
        public void Execute()
        {
            if (Arguments.Length < 2 || Arguments[1] is null)
            {
                Console.WriteLine("Incorrect arguments");
                return;
            }
            List<(string, string, string)> requirments = new();
            for (int i = 2; i < Arguments.Length; i += 3)
            {
                if (i + 2 >= Arguments.Length)
                {
                    Console.WriteLine("Incorrect arguments");
                    return;
                }
                string name_of_field = Arguments[i];
                string op = Arguments[i + 1];
                string value = Arguments[i + 2];
                requirments.Add((name_of_field, op, value));
            }
            string className = Arguments[1].ToLower();
            IObject[] collection = Extensions.GetCollectionByKey(className);
            if (collection is not null)
            {
                foreach (IObject o in collection)
                {
                    bool print = true;
                    foreach ((string, string, string) requirment in requirments)
                    {
                        o.Properties.TryGetValue(requirment.Item1.ToLower(), out object? obj);
                        if (obj is not null)
                        {
                            switch (requirment.Item2)
                            {
                                case "=":
                                    if (obj.ToString() != requirment.Item3)
                                    {
                                        print = false;
                                    }
                                    break;
                                case ">":
                                    if (int.TryParse(obj.ToString(), out int t1) && int.TryParse(requirment.Item3, out int t2))
                                    {
                                        if (t1 <= t2)
                                            print = false;
                                    }
                                    else if (String.Compare(obj.ToString(), requirment.Item3) <= 0)
                                    {
                                        print = false;
                                    }
                                    break;
                                case "<":
                                    if (int.TryParse(obj.ToString(), out int t3) && int.TryParse(requirment.Item3, out int t4))
                                    {
                                        if (t3 >= t4)
                                            print = false;
                                    }
                                    else if (String.Compare(obj.ToString(), requirment.Item3) >= 0)
                                    {
                                        print = false;
                                    }
                                    break;
                            }
                        }
                    }
                    if (print)
                        o.Display();
                }
            }
        }
    }
    public class List : IMyCommand
    {
        public string[] Arguments { get; set; }
        public string? CommandName => "list";
        public List()
        {
            Arguments = Array.Empty<string>();
        }
        public void Execute()
        {
            if (Arguments.Length != 2 || Arguments[1] is null)
            {
                Console.WriteLine("Incorrect arguments");
                return;
            }
            IObject[] collection = Extensions.GetCollectionByKey(Arguments[1].ToLower());
            if (collection is not null)
            {
                foreach (IObject o in collection)
                {
                    o.Display();
                }
            }
            else
            {
                Console.WriteLine("Incorrect arguments");
            }
        }
    }
    public class Exit : IMyCommand
    {
        public string[] Arguments { get; set; }
        public string? CommandName => "exit";
        public Exit()
        {
            Arguments = Array.Empty<string>();
        }
        public void Execute()
        {
            System.Environment.Exit(0);
        }
    }
    public class Add : IMyCommand
    {
        public string[] Arguments { get; set; }
        public string? CommandName => "add";
        public Add()
        {
            Arguments = Array.Empty<string>();
        }
        public void Execute()
        {
            if (Arguments.Length != 3 || Arguments[1] is null || Arguments[2] is null)
            {
                Console.WriteLine("Incorrect arguments");
                return;
            }
            CommandFactory.emptytypes.TryGetValue(Arguments[1].ToLower(), out IObject? obj);
            if(obj is not null)
            {
                string s = "[Available fields:";
                foreach(var p in obj.Properties)
                {
                    s += " ";
                    s += p.Key;
                }
                s += "]";
                Console.WriteLine(s);
                string? line;
                while ((line = Console.ReadLine()) != null)
                {
                    if (line.ToUpper() == "DONE" || line.ToUpper() == "EXIT") break;
                    string[] sub = line.Split('=', ' ');
                    if (!line.Contains('=') || sub.Length!=2)
                        Console.WriteLine("Input must contain exactly one '=' sign!");
                    string field= sub[0];
                    object value = sub[1];
                    obj.SetProperty(field, value);
                }
                switch(Arguments[2].ToLower())
                {
                    case "base":
                        Program.first.Add(obj);
                        break;
                    case "secondary":
                        Program.third.Add(obj);
                        break;
                    default:
                        Console.WriteLine("Incorrect arguments");
                        return;
                }
            }
        }
    }
    public class Edit : IMyCommand
    {
        public string[] Arguments { get; set; }
        public string? CommandName => "edit";
        public Edit()
        {
            Arguments = Array.Empty<string>();
        }
        public void Execute()
        {
            if (Arguments.Length < 2 || Arguments[1] is null)
            {
                Console.WriteLine("Incorrect arguments");
                return;
            }
            List<(string, string, string)> requirments = new();
            for (int i = 2; i < Arguments.Length; i += 3)
            {
                if (i + 2 >= Arguments.Length)
                {
                    Console.WriteLine("Incorrect arguments");
                    return;
                }
                string name_of_field = Arguments[i];
                string op = Arguments[i + 1];
                string value = Arguments[i + 2];
                requirments.Add((name_of_field, op, value));
            }
            string className = Arguments[1].ToLower();
            IObject[] collection = Extensions.GetCollectionByKey(className);
            List<IObject> found = new();
            if (collection is not null)
            {
                foreach (IObject o in collection)
                {
                    bool print = true;
                    foreach ((string, string, string) requirment in requirments)
                    {
                        o.Properties.TryGetValue(requirment.Item1.ToLower(), out object? obj);
                        if (obj is not null)
                        {
                            switch (requirment.Item2)
                            {
                                case "=":
                                    if (obj.ToString() != requirment.Item3)
                                    {
                                        print = false;
                                    }
                                    break;
                                case ">":
                                    if (int.TryParse(obj.ToString(), out int t1) && int.TryParse(requirment.Item3, out int t2))
                                    {
                                        if (t1 <= t2)
                                            print = false;
                                    }
                                    else if (String.Compare(obj.ToString(), requirment.Item3) <= 0)
                                    {
                                        print = false;
                                    }
                                    break;
                                case "<":
                                    if (int.TryParse(obj.ToString(), out int t3) && int.TryParse(requirment.Item3, out int t4))
                                    {
                                        if (t3 >= t4)
                                            print = false;
                                    }
                                    else if (String.Compare(obj.ToString(), requirment.Item3) >= 0)
                                    {
                                        print = false;
                                    }
                                    break;
                            }
                        }
                    }
                    if (print)
                        found.Add(o);
                }
            }
            if(found.Count != 1)
            {
                return;
            }
            IObject tmp = found[0];
            Program.first.Delete(tmp);
            if (tmp is not null)
            {
                string s = "[Available fields:";
                foreach (var p in tmp.Properties)
                {
                    s += " ";
                    s += p.Key;
                }
                s += "]";
                Console.WriteLine(s);
                string? line;
                while ((line = Console.ReadLine()) != null)
                {
                    if (line.ToUpper() == "DONE" || line.ToUpper() == "EXIT") break;
                    string[] sub = line.Split('=', ' ');
                    if (!line.Contains('=') || sub.Length != 2)
                        Console.WriteLine("Input must contain exactly one '=' sign!");
                    string field = sub[0];
                    object value = sub[1];
                    tmp.SetProperty(field, value);
                }
                Program.first.Add(tmp);
            }
        }
    }
    public class Delete : IMyCommand
    {
        public string[] Arguments { get; set; }
        public string? CommandName => "delete";
        public Delete()
        {
            Arguments = Array.Empty<string>();
        }
        public void Execute() 
        {
            if (Arguments.Length < 2 || Arguments[1] is null)
            {
                Console.WriteLine("Incorrect arguments");
                return;
            }
            List<(string, string, string)> requirments = new();
            for (int i = 2; i < Arguments.Length; i += 3)
            {
                if (i + 2 >= Arguments.Length)
                {
                    Console.WriteLine("Incorrect arguments");
                    return;
                }
                string name_of_field = Arguments[i];
                string op = Arguments[i + 1];
                string value = Arguments[i + 2];
                requirments.Add((name_of_field, op, value));
            }
            string className = Arguments[1].ToLower();
            List<IObject> objects = new List<IObject>();
            IObject[] collection = Extensions.GetCollectionByKey(className);
            if (collection is not null)
            {
                foreach (IObject o in collection)
                {
                    bool print = true;
                    foreach ((string, string, string) requirment in requirments)
                    {
                        o.Properties.TryGetValue(requirment.Item1.ToLower(), out object? obj);
                        if (obj is not null)
                        {
                            switch (requirment.Item2)
                            {
                                case "=":
                                    if (obj.ToString() != requirment.Item3)
                                    {
                                        print = false;
                                    }
                                    break;
                                case ">":
                                    if (int.TryParse(obj.ToString(), out int t1) && int.TryParse(requirment.Item3, out int t2))
                                    {
                                        if (t1 <= t2)
                                            print = false;
                                    }
                                    else if (String.Compare(obj.ToString(), requirment.Item3) <= 0)
                                    {
                                        print = false;
                                    }
                                    break;
                                case "<":
                                    if (int.TryParse(obj.ToString(), out int t3) && int.TryParse(requirment.Item3, out int t4))
                                    {
                                        if (t3 >= t4)
                                            print = false;
                                    }
                                    else if (String.Compare(obj.ToString(), requirment.Item3) >= 0)
                                    {
                                        print = false;
                                    }
                                    break;
                            }
                        }
                    }
                    if (print)
                        objects.Add(o);
                }
            }
            if(objects.Count!=1)
            {
                return;
            }
            Program.first.Delete(objects[0]);
        }
    }
    public class Queue : IMyCommand
    {
        public string[] Arguments { get; set; }
        public string? CommandName => "queue";
        public Queue()
        {
            Arguments = Array.Empty<string>();
        }
        public void Execute()
        {
            switch(Arguments[1].ToLower())
            {
                case "print":
                    Print();
                    return;
                case "commit":
                    Commit();
                    return;
                case "dismiss":
                    Dismiss();
                    return;
                case "export":
                    if (Arguments[3].ToLower()=="xml")
                        ExportXML(Arguments[2]);
                    if (Arguments[3].ToLower()=="plaintext")
                        ExportPlain(Arguments[2]);
                    return;
                case "load":
                    ImportXML(Arguments[2]);
                    return;
            }
        }
        public static void Print()
        {
            foreach(var command in Processor.commands)
            {
                Console.Write(command.Display());
            }
        }
        public static void Commit()
        {
            while(Processor.commands.Count > 0) 
            {
                var command = Processor.commands.Dequeue();
                command.Execute();
            }
        }
        public static void Dismiss()
        {
            Processor.commands.Clear();
        }
        public static void ExportXML(string filename)
        {
            var p = Processor.commands;
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(p.GetType());
            x.Serialize(new StreamWriter(filename),p);
        }
        public static void ExportPlain(string filename)
        {
            StreamWriter fs=new(filename);
            foreach (var command in Processor.commands)
            {
                fs.Write(command.Display());
            }
        }
        public static void ImportXML(string filename)
        {
            var p = Processor.commands;
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(p.GetType());
            var q=(Queue<IMyCommand>?)x.Deserialize(new FileStream(filename,FileMode.Open));
            if (q is not null)
                Processor.commands = q;
        }
        public static void ImportPlain(string filename)
        {
            Processor.commands.Clear();
            StreamReader fs = new(filename);
            string s=fs.ReadToEnd();
            string[] lines = s.Split('\n');
            foreach (string line in lines)
            {
                string[] sub = line.Split(':');
                s = sub[0] + sub[1];
                Processor p = new Processor();
                p.Process(s);
            }
        }
    }
}
