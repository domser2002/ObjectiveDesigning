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
            Arguments=Array.Empty<string>();
        }
        public void Execute()
        {
            Console.WriteLine("Couldn't find command: " + CommandName);
        }
    }
    public class find : IMyCommand
    {
        public string[] Arguments { get; set; }
        public string? CommandName => "find";
        public find()
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
            List<(string,string)> requirments = new();
            for (int i=2;i<Arguments.Length;i++)
            {
                string requirment = Arguments[i];
                string[] sub=requirment.Split('=');
                if (sub.Length != 2) 
                {
                    Console.WriteLine("Incorrect arguments");
                    return;
                }
                string name_of_field = sub[0];
                string value = sub[1];
                requirments.Add((name_of_field,value));
            }
            switch (Arguments[1].ToLower())
            {
                case "students":
                    foreach (Student s in Program.first.students)
                    {
                        bool print = true;
                        foreach((string,string) requirment in requirments)
                        {
                            switch(requirment.Item1.ToLower())
                            {
                                case "surname":
                                    if(s.Surname!=requirment.Item2)
                                    {
                                        print = false;
                                    }
                                    break;
                                case "names":
                                    if(!s.Names.Contains(requirment.Item2)) 
                                    {
                                        print = false;
                                    }
                                    break;
                                case "semester":
                                    int sem;
                                    int.TryParse(requirment.Item2, out sem);
                                    if(sem!=s.Semester)
                                    {
                                        print = false;
                                    }
                                    break;
                                case "code":
                                    if(s.Code!=requirment.Item1)
                                    {
                                        print = false;
                                    }
                                    break;
                            }
                        }
                        if(print)
                            s.Display();
                    }
                    break;
                case "teachers":
                    foreach (Teacher t in Program.first.teachers)
                    {
                        bool print = true;
                        foreach((string,string) requirment in requirments)
                        {
                            switch (requirment.Item1.ToLower())
                            {
                                case "surname":
                                    if (t.Surname != requirment.Item2)
                                    {
                                        print = false;
                                    }
                                    break;
                                case "names":
                                    if (!t.Names.Contains(requirment.Item2))
                                    {
                                        print = false;
                                    }
                                    break;
                                case "rank":
                                    rank sem;
                                    Enum.TryParse(requirment.Item2, out sem);
                                    if (sem != t._Rank)
                                    {
                                        print = false;
                                    }
                                    break;
                                case "code":
                                    if (t.Code != requirment.Item1)
                                    {
                                        print = false;
                                    }
                                    break;
                            }
                        }
                        if (print)
                            t.Display();
                    }
                    break;
                case "classes":
                    foreach (Class c in Program.first.classes)
                    {
                        bool print = true;
                        foreach((string,string) requirment in requirments)
                        {
                            switch (requirment.Item1.ToLower())
                            {
                                case "Name":
                                    if(c.Name != requirment.Item2)
                                    {
                                        print = false;  
                                    }
                                    break;
                                case "Code":
                                    if (c.Code != requirment.Item2)
                                    {
                                        print = false;
                                    }
                                    break;
                                case "Duration":
                                    int duration;
                                    int.TryParse(requirment.Item2, out duration);
                                    if(c.Duration!= duration)
                                    {
                                        print = false;
                                    }
                                    break;
                            }
                        }
                        if(print)
                            c.Display();
                    }
                    break;
                case "rooms":
                    foreach (Room r in Program.first.rooms)
                    {
                        bool print = true;
                        foreach((string,string) requirment in requirments)
                        {
                            switch (requirment.Item1.ToLower())
                            {
                                case "number":
                                    int number;
                                    int.TryParse(requirment.Item2, out number);
                                    if(r.Number != number)
                                    {
                                        print = false;
                                    }
                                    break;
                                case "type":
                                    type _type;
                                    Enum.TryParse(requirment.Item2,out _type);
                                    if(r._Type!=_type)
                                    {
                                        print = false;
                                    }
                                    break;
                            }
                        }
                        if(print)
                            r.Display();
                    }
                    break;
                default:
                    Console.WriteLine("Incorrect arguments");
                    break;
            }
        }
    }
    public class list : IMyCommand
    {
        public string[] Arguments { get; set; }
        public string? CommandName => "list";
        public list()
        {
            Arguments = Array.Empty<string>();
        }
        public void Execute()
        {
            if(Arguments.Length != 2 || Arguments[1] is null) 
            {
                Console.WriteLine("Incorrect arguments");
                return;
            }
            switch(Arguments[1].ToLower())
            {
                case "students":
                    foreach(Student s in Program.first.students)
                    {
                        s.Display();
                    }
                    //foreach(Student s in new StAdapter(Program.third).students)
                    //{
                    //    if (!Program.first.students.Contains(s))
                    //        s.Display();
                    //}
                    break;
                case "teachers":
                    foreach (Teacher t in Program.first.teachers)
                    {
                        t.Display();
                    }
                    break;
                case "classes":
                    foreach (Class c in Program.first.classes)
                    {
                        c.Display();
                    }
                    break;
                case "rooms":
                    foreach (Room r in Program.first.rooms)
                    {
                        r.Display();
                    }
                    break;
                default:
                    Console.WriteLine("Incorrect arguments");
                    break;
            }
        }
    }
    public class exit : IMyCommand
    {
        public string[] Arguments { get; set; }
        public string? CommandName => "exit";
        public exit()
        {
            Arguments = Array.Empty<string>();
        }
        public void Execute()
        {
            System.Environment.Exit(0);
        }
    }
    public class add : IMyCommand
    {
        public string[] Arguments { get; set; }
        public string? CommandName => "add";
        public add()
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
                        string tosub = Console.ReadLine()??"";
                        string[] names = tosub.Split(' ');
                        Console.Write("Surname=");
                        string surname=Console.ReadLine()??"";
                        Console.Write("Semester=");
                        int.TryParse(Console.ReadLine(), out int semester);
                        Console.Write("Code=");
                        string code = Console.ReadLine()??"";
                        Student s = new Student(names, surname, semester, code);
                    if (Arguments[2]=="base")
                        Program.first.AddStudent(s);
                    if (Arguments[2] == "secondary")
                        Program.third.AddStudent(names, surname, semester, code,Array.Empty<string>());
                    break;
                case "teacher":
                    Console.Write("Names=");
                    tosub = Console.ReadLine() ?? "";
                    names = tosub.Split(' ');
                    Console.Write("Surname=");
                    surname = Console.ReadLine() ?? "";
                    Console.Write("Rank=");
                    Enum.TryParse(Console.ReadLine(), out rank _rank);
                    Console.Write("Code=");
                    code = Console.ReadLine() ?? "";
                    Teacher t =  new Teacher(names, surname, _rank, code);
                    if (Arguments[2]=="base")
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
                    if (Arguments[2]=="base")
                        Program.first.AddClass(c);
                    if (Arguments[2] == "secondary")
                        Program.third.AddClass(name, code, duration, Array.Empty<string>(), Array.Empty<string>());
                    break;
                case "room":
                    Console.Write("Number=");
                    int.TryParse(Console.ReadLine(), out int number);
                    Console.Write("Type=");
                    Enum.TryParse(Console.ReadLine(), out type _type);
                    Room r = new Room(number, _type);
                    if (Arguments[2]=="base")
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
