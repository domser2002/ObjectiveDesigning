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
    //internal class Objects
    //{
        public class Room
        {
            private int number;
            private type _type;
            private List<Class> classes;
            public Room(int number, type _type, ref Class[] classes)
            {
                this.number = number;
                this._type = _type;
                this.classes = new List<Class>();
                foreach (Class c in classes)
                {
                    this.classes.Add(c);
                }
            }
        }
        public class Class
        {
            private string name;
            private string code;
            private int duration;
            private List<Teacher> teachers;
            private List<Student> students;
            public Class(string name, string code, int duration, ref Teacher[] teachers, ref Student[] students)
            {
                this.name = name;
                this.code = code;
                this.duration = duration;
                this.teachers = new List<Teacher>();
                foreach (Teacher t in teachers)
                {
                    this.teachers.Add(t);
                }
                this.students = new List<Student>();
                foreach (Student s in students)
                {
                    this.students.Add(s);
                }
            }
        }
        public class Teacher
        {
            private List<string> names;
            private string surname;
            private rank _rank;
            private string code;
            private List<Class> classes;
            public Teacher(string[] names, string surname, rank _rank, string code, ref Class[] classes)
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
                foreach (Class c in classes)
                {
                    this.classes.Add(c);
                }
            }
        }
        public class Student
        {
            private List<string> names;
            private string surname;
            private int semester;
            private string code;
            private List<Class> classes;
            public Student(string[] names, string surname, int semester, string code, ref Class[] classes)
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
                foreach (Class c in classes)
                {
                    this.classes.Add(c);
                }
            }
        }
   // }
}
