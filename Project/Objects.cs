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
        //public void Select()
        //{
        //    foreach (Class c in this.classes)
        //    {
        //        bool student = false;
        //        bool teacher = false;
        //        foreach (Student s in c.Students)
        //        {
        //            if (s.Names.Count > 1)
        //            {
        //                student = true;
        //            }
        //        }
        //        if (!student) { continue; }
        //        foreach (Teacher t in c.Teachers)
        //        {
        //            if (t.Names.Count > 1)
        //            {
        //                teacher = true;
        //            }
        //        }
        //        if (!teacher) { continue; }
        //        c.Display();
        //    }
        //}
        //public void Display()
        //{
        //    Console.WriteLine("FORMAT 0:");
        //    Console.WriteLine();
        //    Console.WriteLine("Rooms:");
        //    foreach(Room r in rooms)
        //    {
        //        r.Display();
        //    }
        //    Console.WriteLine();
        //    Console.WriteLine("Classes:");
        //    foreach (Class c in classes)
        //    {
        //        c.Display();
        //    }
        //    Console.WriteLine();
        //    Console.WriteLine("Teachers:");
        //    foreach (Teacher t in teachers)
        //    {
        //        t.Display();
        //    }
        //    Console.WriteLine();
        //    Console.WriteLine("Students:");
        //    foreach (Student s in students)
        //    {
        //        s.Display();
        //    }
        //    Console.WriteLine();
        //}
    }
    public class Room : IRoom
    {
        private int number;
        public int Number { get => this.number; }
        private type _type;
        public type _Type { get => this._type; }
        private List<IClass> classes;
        public List<IClass> Classes { get => this.classes; }
        public Room(int number, type _type)
        {
            this.number = number;
            this._type = _type;
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
        private string name;
        public string Name { get => this.name; }
        private string code;
        public string Code { get => this.code; }
        private int duration;
        public int Duration { get => this.duration; }
        private List<ITeacher> teachers;
        public List<ITeacher> Teachers { get => this.teachers; }
        private List<IStudent> students;
        public List<IStudent> Students { get => this.students; }
        public Class(string name, string code, int duration)
        {
            this.name = name;
            this.code = code;
            this.duration = duration;
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
        private List<string> names;
        public List<string> Names { get => this.names; }
        private string surname;
        public string Surname { get => this.surname; }
        private rank _rank;
        public rank _Rank { get => this._rank; }
        private string code;
        public string Code { get => this.code; }
        private List<IClass> classes;
        public List<IClass> Classes { get => this.classes; }
        public Teacher(string[] names, string surname, rank _rank, string code)
        {
            this.names = new List<string>();
            foreach (string name in names)
            {
                this.names.Add(name);
            }
            this.surname = surname;
            this._rank = _rank;
            this.code = code;
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
        private List<string> names;
        public List<string> Names { get => this.names; }
        private string surname;
        public string Surname { get => this.surname; }
        private int semester;
        public int Semester { get => this.semester; }
        private string code;
        public string Code { get => this.code; }
        private List<IClass> classes;
        public List<IClass> Classes { get => this.classes; }
        public Student(string[] names, string surname, int semester, string code)
        {
            this.names = new List<string>();
            foreach (string name in names)
            {
                this.names.Add(name);
            }
            this.surname = surname;
            this.semester = semester;
            this.code = code;
            this.classes = new List<IClass>();
        }
        public void AddClass(Class c)
        {
            this.classes.Add(c);
        }
        public void Display() => Extensions.Display(this);
    }
}
