using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Project
{

    public class Hashmap
    {
        public Room[] rooms { get; set; }
        public Class[] classes { get; set; }
        public Teacher[] teachers { get; set; }
        public Student[] students { get; set; }
        public Hashmap(Room[] rooms, Class[] classes, Teacher[] teachers, Student[] students)
        {
            this.rooms = rooms;
            this.classes = classes;
            this.teachers = teachers;
            this.students = students;
        }
        public class Room
        {
            private int number;
            public int Number { get => this.number; }
            private type _type;
            public type _Type { get => this._type; }
            private List<Hashmap.Class> classes;
            public List<Hashmap.Class> Classes { get => this.classes; }
            public Room(int number, type _type)
            {
                this.number = number;
                this._type = _type;
                this.classes = new List<Hashmap.Class>();
            }
            public void AddClass(Hashmap.Class c)
            {
                this.classes.Add(c);
            }
            //public override string ToString()
            //{
            //    string s = number.ToString() + " " + _type.ToString();
            //    foreach (int c in classes)
            //    {
            //        s += " " + c;
            //    }
            //    return s;
            //}
        }
        public class Class
        {
            public static Dictionary<int,string> Map=new Dictionary<int,string>();
            private int name;
            public int Name { get => this.name; }
            private int code;
            public int Code { get => this.code; }
            private int duration;
            public int Duration { get => this.duration; }
            private List<Hashmap.Teacher> teachers;
            public List<Hashmap.Teacher> Teachers { get => this.teachers; }
            private List<Hashmap.Student> students;
            public List<Hashmap.Student> Students { get => this.students; }
            public Class(string name, string code, int duration)
            {
                this.name = name.GetHashCode();
                Map.AddOrIgnore(name.GetHashCode(), name);
                this.code = code.GetHashCode();
                Map.AddOrIgnore(code.GetHashCode(), code);
                this.duration = duration;
                this.teachers = new List<Hashmap.Teacher>();
                this.students = new List<Hashmap.Student>();
            }
            public void AddTeacher(Hashmap.Teacher t)
            {
                this.teachers.Add(t);
            }
            public void AddStudent(Hashmap.Student s)
            {
                this.students.Add(s);
            }
        }
        public class Teacher
        {
            public static Dictionary<int, string> Map = new Dictionary<int, string>();
            private List<int> names;
            public List<int> Names { get => this.names; }
            private int surname;
            public int Surname { get => this.surname; }
            private rank _rank;
            public rank _Rank { get => this._rank; }
            private int code;
            public int Code { get => this.code; }
            private List<Hashmap.Class> classes;
            public List<Hashmap.Class> Classes { get => this.classes; }
            public Teacher(string[] names, string surname, rank _rank, string code)
            {
                this.names = new List<int>();
                foreach (string name in names)
                {
                    this.names.Add(name.GetHashCode());
                    Map.AddOrIgnore(name.GetHashCode(), name);
                }
                this.surname = surname.GetHashCode();
                Map.AddOrIgnore(surname.GetHashCode(), surname);
                this._rank = _rank;
                this.code = code.GetHashCode();
                Map.AddOrIgnore(code.GetHashCode(), code);
                this.classes = new List<Hashmap.Class>();
            }
            public void AddClass(Hashmap.Class c)
            {
                this.classes.Add(c);
            }
        }
        public class Student
        {
            public static Dictionary<int, string> Map = new Dictionary<int, string>();
            private List<int> names;
            public List<int> Names { get => this.names; }
            private int surname;
            public int Surname { get => this.surname; }
            private int semester;
            public int Semester { get => this.semester; }
            private int code;
            public int Code { get => code; }
            private List<Hashmap.Class> classes;
            public List<Hashmap.Class> Classes { get => this.classes; }
            public Student(string[] names, string surname, int semester, string code)
            {
                this.names = new List<int>();
                foreach (string name in names)
                {
                    this.names.Add(name.GetHashCode());
                    Map.AddOrIgnore(name.GetHashCode(), name);  
                }
                this.surname = surname.GetHashCode();
                Map.AddOrIgnore(surname.GetHashCode(), surname);
                this.semester = semester;
                this.code = code.GetHashCode();
                Map.AddOrIgnore(code.GetHashCode(), code);
                this.classes = new List<Hashmap.Class>();
            }
            public void AddClass(Hashmap.Class c)
            {
                this.classes.Add(c);
            }
        }
    }
}
