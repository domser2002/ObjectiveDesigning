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
        public List<Room>? rooms;
        public List<Class>? classes;
        public List<Teacher>? teachers;
        public List<Student>? students;
        public class Room
        {
            private int number;
            public int Number { get => this.number; }
            private type _type;
            public type _Type { get => this._type; }
            private List<int> classes;
            public List<int> Classes { get => this.classes; }
            public Room(int number, type _type)
            {
                this.number = number;
                this._type = _type;
                this.classes = new List<int>();
            }
            public void AddClass(Class c)
            {
                this.classes.Add(c.Code);
            }
            public override string ToString()
            {
                string s = number.ToString() + " " + _type.ToString();
                foreach (int c in classes)
                {
                    s += " " + c;
                }
                return s;
            }
        }
        public class Class
        {
            private string name;
            public string Name { get => this.name; }
            private string code;
            public int Code { get => this.code.GetHashCode(); }
            public string _Code { get => this.code; }
            private int duration;
            public int Duration { get => this.duration; }
            private List<int> teachers;
            public List<int> Teachers { get => this.teachers; }
            private List<int> students;
            public List<int> Students { get => this.students; }
            public Class(string name, string code, int duration)
            {
                this.name = name;
                this.code = code;
                this.duration = duration;
                this.teachers = new List<int>();
                this.students = new List<int>();
            }
            public void AddTeacher(Teacher t)
            {
                this.teachers.Add(t.Code);
            }
            public void AddStudent(Student s)
            {
                this.students.Add(s.Code);
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
            private string code;
            public string Code { get => this.code; }
            private List<int> classes;
            public List<int> Classes { get => this.classes; }
            public Teacher(string[] names, string surname, rank _rank, string code)
            {
                this.names = new List<int>();
                foreach (string name in names)
                {
                    this.names.Add(name.GetHashCode());
                    Map.Add(name.GetHashCode(), name);
                }
                this.surname = surname.GetHashCode();
                Map.Add(surname.GetHashCode(), surname);
                this._rank = _rank;
                this.code = code;
                this.classes = new List<int>();
            }
            public void AddClass(Hashmap.Class c)
            {
                this.classes.Add(c.Code);
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
            private string code;
            public string Code { get => code; }
            private List<string> classes;
            public List<string> Classes { get => this.classes; }
            public Student(string[] names, string surname, int semester, string code)
            {
                this.names = new List<int>();
                foreach (string name in names)
                {
                    this.names.Add(name.GetHashCode());
                    Map.Add(name.GetHashCode(), name);  
                }
                this.surname = surname.GetHashCode();
                Map.Add(surname.GetHashCode(), surname);
                this.semester = semester;
                this.code = code;
                this.classes = new List<string>();
            }
            public void AddClass(Hashmap.Class c)
            {
                this.classes.Add(c.Code);
            }
        }
    }
}
