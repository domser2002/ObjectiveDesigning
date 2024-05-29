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
        public void UnExecute() { }
        public bool Prepare(string[] args)
        {
            Execute();
            return true;
        }
    }
    public class Find : IMyCommand
    {
        public string[] Arguments { get; set; }
        public string? CommandName => "find";
        private readonly List<(string, string, string)> requirments = new();
        private IObject[] collection = Array.Empty<IObject>();
        public Find()
        {
            Arguments = Array.Empty<string>();
        }
        public bool Prepare(string[] args)
        {
            Arguments = args;
            if (args.Length < 2 || args[1] is null)
            {
                Console.WriteLine("Incorrect arguments");
                return false;
            }
            for (int i = 2; i < args.Length; i += 3)
            {
                if (i + 2 >= args.Length)
                {
                    Console.WriteLine("Incorrect arguments");
                    return false;
                }
                string name_of_field = args[i];
                string op = args[i + 1];
                string value = args[i + 2];
                requirments.Add((name_of_field, op, value));
            }
            string className = args[1].ToLower();
            collection = Extensions.GetCollectionByKey(className);
            if (collection is null) return false;
            return true;
        }
        public void Execute()
        {
            foreach (IObject o in collection)
            {
                if (Extensions.FullfillsRequirments(o, requirments))
                    o.Display();
            }
        }
        public void UnExecute() { }
    }
    public class List : IMyCommand
    {
        public string[] Arguments { get; set; }
        public string? CommandName => "list";
        private IObject[] collection = Array.Empty<IObject>();
        public List()
        {
            Arguments = Array.Empty<string>();
        }
        public bool Prepare(string[] args)
        {
            Arguments = args;
            if (args.Length != 2 || args[1] is null)
            {
                Console.WriteLine("Incorrect arguments");
                return false;
            }
            collection = Extensions.GetCollectionByKey(args[1].ToLower());
            if (collection is null)
            {
                Console.WriteLine("No such class!");
                return false;
            }
            return true;
        }
        public void Execute()
        {
            foreach (IObject o in collection)
            {
                o.Display();
            }
        }
        public void UnExecute() { }
    }
    public class Exit : IMyCommand
    {
        public string[] Arguments { get; set; }
        public string? CommandName => "exit";
        public Exit()
        {
            Arguments = Array.Empty<string>();
        }
        public bool Prepare(string[] args)
        {
            Execute();
            return true;
        }
        public void Execute()
        {
            Environment.Exit(0);
        }
        public void UnExecute() { }
    }
    public class Add : IMyCommand
    {
        public string[] Arguments { get; set; }
        public string? CommandName => "add";
        private IObject? obj;
        public Add()
        {
            Arguments = Array.Empty<string>();
        }
        public bool Prepare(string[] args)
        {
            Arguments = args;
            if (args.Length != 3 || args[1] is null || args[2] is null)
            {
                Console.WriteLine("Incorrect arguments");
                return false;
            }
            CommandFactory.emptytypes.TryGetValue(args[1].ToLower(), out IObject? tmp);
            obj = tmp.Copy();
            if (obj is null)
            {
                Console.WriteLine("No such class!");
                return false;
            }
            string s = "[Available fields:";
            foreach (var p in obj.Properties)
            {
                s += " ";
                s += p.Key;
            }
            s += "]";
            Console.WriteLine(s);
            string? line;
            while ((line = Console.ReadLine()) != null)
            {
                if (line.ToUpper() == "DONE") break;
                if (line.ToUpper() == "EXIT") return false;
                string[] sub = line.Split('=', ' ');
                if (!line.Contains('=') || sub.Length != 2)
                    Console.WriteLine("Input must contain exactly one '=' sign!");
                string field = sub[0];
                object value = sub[1];
                if (!obj.SetProperty(field, value))
                {
                    Console.WriteLine("No such field!");
                }
            }
            return true;
        }
        public void Execute()
        {
            if (obj is null) return;
            switch (Arguments[2].ToLower())
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
            CommandFactory.toundo.Push(this);
        }
        public void UnExecute()
        {
            if (obj is null) return;
            switch (Arguments[2].ToLower())
            {
                case "base":
                    Program.first.Delete(obj);
                    break;
                case "secondary":
                    Program.third.Delete(obj);
                    break;
                default:
                    Console.WriteLine("Incorrect arguments");
                    return;
            }
            CommandFactory.toredo.Push(this);
        }
    }
    public class Edit : IMyCommand
    {
        public string[] Arguments { get; set; }
        public string? CommandName => "edit";
        private readonly List<(string, string, string)> requirments = new();
        private IObject? toadd;
        private IObject? toremove;
        public Edit()
        {
            Arguments = Array.Empty<string>();
        }
        public bool Prepare(string[] args)
        {
            Arguments = args;
            if (Arguments.Length < 2 || Arguments[1] is null)
            {
                Console.WriteLine("Incorrect arguments");
                return false;
            }
            List<(string, string, string)> requirments = new();
            for (int i = 2; i < Arguments.Length; i += 3)
            {
                if (i + 2 >= Arguments.Length)
                {
                    Console.WriteLine("Incorrect arguments");
                    return false;
                }
                string name_of_field = Arguments[i];
                string op = Arguments[i + 1];
                string value = Arguments[i + 2];
                requirments.Add((name_of_field, op, value));
            }
            string className = Arguments[1].ToLower();
            IObject[] collection = Extensions.GetCollectionByKey(className);
            if (collection is null)
            {
                Console.WriteLine("No such class!");
                return false;
            }
            List<IObject> found = new();
            foreach (IObject o in collection)
            {
                if (Extensions.FullfillsRequirments(o, requirments))
                    found.Add(o);
            }
            if (found.Count != 1)
            {
                Console.WriteLine("Requirments do not specify one record uniquely");
                return false;
            }
            toremove = found[0];
            toadd = found[0].Copy();
            if (toadd is null || toremove is null) return false;
            string s = "[Available fields:";
            foreach (var p in toadd.Properties)
            {
                s += " ";
                s += p.Key;
            }
            s += "]";
            Console.WriteLine(s);
            string? line;
            while ((line = Console.ReadLine()) != null)
            {
                if (line.ToUpper() == "DONE") break;
                if (line.ToUpper() == "EXIT") return false;
                string[] sub = line.Split('=', ' ');
                if (!line.Contains('=') || sub.Length != 2)
                    Console.WriteLine("Input must contain exactly one '=' sign!");
                string field = sub[0];
                object value = sub[1];
                toadd.SetProperty(field, value);
            }
            return true;
        }
        public void Execute()
        {
            if (toadd is not null && toremove is not null)
            {
                Program.first.Delete(toremove);
                Program.first.Add(toadd);
            }
            CommandFactory.toundo.Push(this);
        }
        public void UnExecute()
        {
            if (toadd is not null && toremove is not null)
            {
                Program.first.Delete(toadd);
                Program.first.Add(toremove);
            }
            CommandFactory.toredo.Push(this);
        }
    }
    public class Delete : IMyCommand
    {
        public string[] Arguments { get; set; }
        public string? CommandName => "delete";

        readonly List<(string, string, string)> requirments = new();
        private IObject? toremove;
        public Delete()
        {
            Arguments = Array.Empty<string>();
        }
        public bool Prepare(string[] args)
        {
            Arguments = args;
            if (Arguments.Length < 2 || Arguments[1] is null)
            {
                Console.WriteLine("Incorrect arguments");
                return false;
            }
            for (int i = 2; i < Arguments.Length; i += 3)
            {
                if (i + 2 >= Arguments.Length)
                {
                    Console.WriteLine("Incorrect arguments");
                    return false;
                }
                string name_of_field = Arguments[i];
                string op = Arguments[i + 1];
                string value = Arguments[i + 2];
                requirments.Add((name_of_field, op, value));
            }
            string className = Arguments[1].ToLower();
            List<IObject> objects = new();
            IObject[] collection = Extensions.GetCollectionByKey(className);
            if (collection is null)
            {
                Console.WriteLine("No such class!");
                return false;
            }
            foreach (IObject o in collection)
            {
                if (Extensions.FullfillsRequirments(o, requirments))
                    objects.Add(o);
            }
            if (objects.Count != 1)
            {
                return false;
            }
            toremove = objects[0];
            if (toremove is null) return false;
            return true;
        }
        public void Execute()
        {
            if (toremove is not null)
                Program.first.Delete(toremove);
            CommandFactory.toundo.Push(this);
        }
        public void UnExecute()
        {
            if (toremove is not null)
                Program.first.Add(toremove);
            CommandFactory.toredo.Push(this);
        }
    }
    //public class Queue : IMyCommand
    //{
    //    public string[] Arguments { get; set; }
    //    public string? CommandName => "queue";
    //    public Queue()
    //    {
    //        Arguments = Array.Empty<string>();
    //    }
    //    public bool Prepare(string[] args)
    //    {
    //        Arguments = args;
    //        Execute();
    //        return true;
    //    }
    //    public void Execute()
    //    {
    //        switch (Arguments[1].ToLower())
    //        {
    //            case "print":
    //                Print();
    //                return;
    //            case "commit":
    //                Commit();
    //                return;
    //            case "dismiss":
    //                Dismiss();
    //                return;
    //            case "export":
    //                if (Arguments[3].ToLower() == "xml")
    //                    ExportXML(Arguments[2]);
    //                if (Arguments[3].ToLower() == "plaintext")
    //                    ExportPlain(Arguments[2]);
    //                return;
    //            case "load":
    //                ImportXML(Arguments[2]);
    //                return;
    //        }
    //    }
    //    public static void Print()
    //    {
    //        foreach (var command in Processor.commands_queue)
    //        {
    //            command.Display();
    //        }
    //    }
    //    public static void Commit()
    //    {
    //        while (Processor.commands_queue.Count > 0)
    //        {
    //            var command = Processor.commands_queue.Dequeue();
    //            command.Execute();
    //        }
    //    }
    //    public static void Dismiss()
    //    {
    //        Processor.commands_queue.Clear();
    //    }
    //    public static void ExportXML(string filename)
    //    {
    //        var p = Processor.commands_queue;
    //        System.Xml.Serialization.XmlSerializer x = new(p.GetType());
    //        x.Serialize(new StreamWriter(filename), p);
    //    }
    //    public static void ExportPlain(string filename)
    //    {
    //        StreamWriter fs = new(filename);
    //        foreach (var command in Processor.commands_queue)
    //        {
    //            command.Display();
    //        }
    //    }
    //    public static void ImportXML(string filename)
    //    {
    //        var p = Processor.commands_queue;
    //        System.Xml.Serialization.XmlSerializer x = new(p.GetType());
    //        var q = (Queue<IMyCommand>?)x.Deserialize(new FileStream(filename, FileMode.Open));
    //        if (q is not null)
    //            Processor.commands_queue = q;
    //    }
    //    public static void ImportPlain(string filename)
    //    {
    //        Processor.commands_queue.Clear();
    //        StreamReader fs = new(filename);
    //        string s = fs.ReadToEnd();
    //        string[] lines = s.Split('\n');
    //        foreach (string line in lines)
    //        {
    //            string[] sub = line.Split(':');
    //            s = sub[0] + sub[1];
    //            Processor p = new Processor();
    //            Processor.Process(s);
    //        }
    //    }
    //}
    public class History : IMyCommand
    {
        public string[] Arguments { get; set; }
        public string? CommandName => "history";
        public History()
        {
            Arguments = Array.Empty<string>();
        }
        public bool Prepare(string[] args)
        {
            return true;
        }
        public void Execute()
        {
            foreach (var command in Processor.commands_queue)
            {
                command.Display();
            }
        }
        public void UnExecute() { }
    }
}
