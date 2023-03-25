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
        public Room[] rooms { get; set; }
        public Class[] classes { get; set; }
        public Teacher[] teachers { get; set; }
        public Student[] students { get; set; }
    }
    public class Room : IRoom
    {
        private int number;
        public int Number { get => this.number; }
        private type _type;
        public type _Type { get => this._type; }
        private List<Class> classes;
        public List<Class> Classes { get => this.classes; }
        public Room(int number, type _type)
        {
            this.number = number;
            this._type = _type;
            this.classes = new List<Class>();
        }
        public void AddClass(Class c)
        {
            this.classes.Add(c);
        }
        public override string ToString()
        {
            string s = number.ToString() + " " + _type.ToString();
            foreach (Class c in classes)
            {
                s += " " + c.Code;
            }
            return s;
        }
    }
    public class Class : IClass
    {
        private string name;
        public string Name { get => this.name; }
        private string code;
        public string Code { get => this.code; }
        private int duration;
        public int Duration { get => this.duration; }
        private List<Teacher> teachers;
        public List<Teacher> Teachers { get => this.teachers; }
        private List<Student> students;
        public List<Student> Students { get => this.students; }
        public Class(string name, string code, int duration)
        {
            this.name = name;
            this.code = code;
            this.duration = duration;
            this.teachers = new List<Teacher>();
            this.students = new List<Student>();
        }
        public void AddStudent(Student s)
        {
            this.students.Add(s);
        }
        public void AddTeacher(Teacher t)
        {
            this.teachers.Add(t);
        }
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
        private List<Class> classes;
        public List<Class> Classes { get => this.classes; }
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
            this.classes = new List<Class>();
        }
        public void AddClass(Class c)
        {
            this.classes.Add(c);
        }
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
        private List<Class> classes;
        public List<Class> Classes { get => this.classes; }
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
            this.classes = new List<Class>();
        }
        public void AddClass(Class c)
        {
            this.classes.Add(c);
        }
    }
}
