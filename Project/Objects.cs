using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public enum type { laboratory, tutorials, lecture, other };
    public enum rank { KiB, MiB, GiB, TiB };
    internal class Objects
    {
        public class Room
        {
            private int number;
            private type _type;
            private List<Class> classes;
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
        public class Class
        {
            private string name;
            private string code;
            public string Code { get { return code; } }
            private int duration;
            private List<Teacher> teachers;
            private List<Student> students;
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
        public class Teacher
        {
            private List<string> names;
            private string surname;
            private rank _rank;
            private string code;
            private List<Class> classes;
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
        public class Student
        {
            private List<string> names;
            private string surname;
            private int semester;
            private string code;
            private List<Class> classes;
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
}
