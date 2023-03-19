using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Project
{

    internal class Hashmap
    {
        public class Room
        {
            private int number;
            private type _type;
            private List<long> classes;
            public Room(int number, type _type)
            {
                this.number = number;
                this._type = _type;
                this.classes = new List<long>();
            }
            public void AddClass(Class c)
            {
                this.classes.Add(c.Code);
            }
            public override string ToString()
            {
                string s = number.ToString() + " " + _type.ToString();
                foreach (long c in classes)
                {
                    s += " " + c;
                }
                return s;
            }
        }
        public class Class
        {
            private string name;
            public long Code { get => code.GetHashCode();}
            private string code;
            private int duration;
            private List<long> teachers;
            private List<long> students;
            public Class(string name, string code, int duration)
            {
                this.name = name;
                this.code = code;
                this.duration = duration;
                this.teachers = new List<long>();
                this.students = new List<long>();
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
            private List<string> names;
            private string surname;
            public long Code { get => code.GetHashCode(); }
            private rank _rank;
            private string code;
            private List<long> classes;
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
                this.classes = new List<long>();
            }
            public void AddClass(Class c)
            {
                this.classes.Add(c.Code);
            }
        }
        public class Student
        {
            private List<string> names;
            private string surname;
            public long Code { get => code.GetHashCode(); }
            private int semester;
            private string code;
            private List<long> classes;
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
                this.classes = new List<long>();
            }
            public void AddClass(Class c)
            {
                this.classes.Add(c.Code);
            }
        }
    }
}
