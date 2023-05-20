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
            CommandFactory.argumentParser.TryGetValue(className, out IObject[]? collection);
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
            CommandFactory.argumentParser.TryGetValue(Arguments[1].ToLower(), out IObject[]? collection);
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
            switch (Arguments[1].ToLower())
            {
                case "student":
                    Console.Write("Names=");
                    string tosub = Console.ReadLine() ?? "";
                    string[] names = tosub.Split(' ');
                    Console.Write("Surname=");
                    string surname = Console.ReadLine() ?? "";
                    Console.Write("Semester=");
                    int.TryParse(Console.ReadLine(), out int semester);
                    Console.Write("Code=");
                    string code = Console.ReadLine() ?? "";
                    Student s = new Student(names, surname, semester, code);
                    if (Arguments[2] == "base")
                        Program.first.AddStudent(s);
                    if (Arguments[2] == "secondary")
                        Program.third.AddStudent(names, surname, semester, code, Array.Empty<string>());
                    break;
                case "teacher":
                    Console.Write("Names=");
                    tosub = Console.ReadLine() ?? "";
                    names = tosub.Split(' ');
                    Console.Write("Surname=");
                    surname = Console.ReadLine() ?? "";
                    Console.Write("Rank=");
                    Enum.TryParse(Console.ReadLine(), out Rank _rank);
                    Console.Write("Code=");
                    code = Console.ReadLine() ?? "";
                    Teacher t = new Teacher(names, surname, _rank, code);
                    if (Arguments[2] == "base")
                        Program.first.AddTeacher(t);
                    if (Arguments[2] == "secondary")
                        Program.third.AddTeacher(names, surname, _rank, code, Array.Empty<string>());
                    break;
                case "class":
                    Console.Write("Name=");
                    string name = Console.ReadLine() ?? "";
                    Console.Write("Code=");
                    code = Console.ReadLine() ?? "";
                    Console.Write("Duration=");
                    int.TryParse(Console.ReadLine(), out int duration);
                    Class c = new Class(name, code, duration);
                    if (Arguments[2] == "base")
                        Program.first.AddClass(c);
                    if (Arguments[2] == "secondary")
                        Program.third.AddClass(name, code, duration, Array.Empty<string>(), Array.Empty<string>());
                    break;
                case "room":
                    Console.Write("Number=");
                    int.TryParse(Console.ReadLine(), out int number);
                    Console.Write("Type=");
                    Enum.TryParse(Console.ReadLine(), out Type _type);
                    Room r = new Room(number, _type);
                    if (Arguments[2] == "base")
                        Program.first.AddRoom(r);
                    if (Arguments[2] == "secondary")
                        Program.third.AddRoom(number, _type, Array.Empty<string>());
                    break;
                default:
                    Console.WriteLine("Incorrect arguments");
                    break;
            }
        }
    }
}
