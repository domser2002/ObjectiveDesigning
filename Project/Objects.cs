using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using static Project.Hashmap;

namespace Project
{
    public class Objects : IRepresentation
    {
        public IRoom[] Rooms { get; set; }
        public IClass[] Classes { get; set; }
        public ITeacher[] Teachers { get; set; }
        public IStudent[] Students { get; set; }
        public Objects(Room[] rooms, Class[] classes, Teacher[] teachers, Student[] students)
        {
            this.Rooms = rooms;
            this.Classes = classes;
            this.Teachers = teachers;
            this.Students = students;
        }
        public void AddStudent(Student s)
        {
            var tmp = this.Students.ToList();
            tmp.Add(s);
            this.Students=tmp.ToArray();
        }
        public void AddTeacher(Teacher t)
        {
            var tmp = this.Teachers.ToList();
            tmp.Add(t);
            this.Teachers = tmp.ToArray();
        }
        public void AddClass(Class c)
        {
            var tmp = this.Classes.ToList();
            tmp.Add(c);
            this.Classes = tmp.ToArray();
        }
        public void AddRoom(Room r)
        {
            var tmp = this.Rooms.ToList();
            tmp.Add(r);
            this.Rooms = tmp.ToArray();
        }
    }
    public class Room : IRoom
    {
        public Dictionary<string, object> Properties { get; }
        private readonly int number;
        public int Number { get => this.number; }
        private readonly Type type;
        public Type Type { get => this.type; }
        private readonly List<IClass> classes;
        public List<IClass> Classes { get => this.classes; }
        public Room(int number, Type type)
        {
            Properties = new();
            this.number = number;
            Properties.AddOrIgnore("number", this.number);
            this.type = type;
            Properties.AddOrIgnore("type", this.type);
            this.classes = new List<IClass>();
        }
        public void AddClass(Class c)
        {
            this.classes.Add(c);
        }
        public void Display() => Extensions.Display(this); 
    }
    public class Class : IClass
    {
        public Dictionary<string, object> Properties { get;  }
        private readonly string name;
        public string Name { get => this.name; }
        private readonly string code;
        public string Code { get => this.code; }
        private readonly int duration;
        public int Duration { get => this.duration; }
        private readonly List<ITeacher> teachers;
        public List<ITeacher> Teachers { get => this.teachers; }
        private readonly List<IStudent> students;
        public List<IStudent> Students { get => this.students; }
        public Class(string name, string code, int duration)
        {
            Properties = new();
            this.name = name;
            Properties.AddOrIgnore("name", this.name);
            this.code = code;
            Properties.AddOrIgnore("code",this.code);
            this.duration = duration;
            Properties.AddOrIgnore("duration", this.duration);
            this.teachers = new List<ITeacher>();
            this.students = new List<IStudent>();
        }
        public void AddStudent(Student s)
        {
            this.students.Add(s);
        }
        public void AddTeacher(Teacher t)
        {
            this.teachers.Add(t);
        }
        public void Display() => Extensions.Display(this);
    }
    public class Teacher : ITeacher
    {
        public Dictionary<string, object> Properties { get; }
        private readonly List<string> names;
        public List<string> Names { get => this.names; }
        private readonly string surname;
        public string Surname { get => this.surname; }
        private readonly Rank rank;
        public Rank Rank { get => this.rank; }
        private readonly string code;
        public string Code { get => this.code; }
        private readonly List<IClass> classes;
        public List<IClass> Classes { get => this.classes; }
        public Teacher(string[] names, string surname, Rank rank, string code)
        {
            Properties = new();
            this.names = new List<string>();
            foreach (string name in names)
            {
                this.names.Add(name);
            }
            Properties.AddOrIgnore("name", this.names);
            this.surname = surname;
            Properties.AddOrIgnore("surname", this.surname);
            this.rank = rank;
            Properties.AddOrIgnore("rank", this.rank);
            this.code = code;
            Properties.AddOrIgnore("code", this.code);
            this.classes = new List<IClass>();
        }
        public void AddClass(Class c)
        {
            this.classes.Add(c);
        }
        public void Display() => Extensions.Display(this);
    }
    public class Student : IStudent
    {
        public Dictionary<string, object> Properties { get; }
        private readonly List<string> names;
        public List<string> Names { get => this.names; }
        private readonly string surname;
        public string Surname { get => this.surname; }
        private readonly int semester;
        public int Semester { get => this.semester; }
        private readonly string code;
        public string Code { get => this.code; }
        private readonly List<IClass> classes;
        public List<IClass> Classes { get => this.classes; }
        public Student(string[] names, string surname, int semester, string code)
        {
            Properties = new();
            this.names = new List<string>();
            foreach (string name in names)
            {
                this.names.Add(name);
            }
            Properties.AddOrIgnore("name", this.names);
            this.surname = surname;
            Properties.AddOrIgnore("surname", this.surname);
            this.semester = semester;
            Properties.AddOrIgnore("semester", this.semester);
            this.code = code;
            Properties.AddOrIgnore("code", this.code);
            this.classes = new List<IClass>();
        }
        public void AddClass(Class c)
        {
            this.classes.Add(c);
        }
        public void Display() => Extensions.Display(this);
    }
}
