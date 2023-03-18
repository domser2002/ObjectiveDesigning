using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{

    internal class Hashmap
    {
        public static long hash(string s)
        {
            long hash = 0;
            foreach (char c in s)
            {
                hash = hash * 97 + (c - 32);
            }
            return hash;
        }
        public class Room
        {
            private int number;
            private type _type;
            private List<long> classes;
            public Room(int number, type _type, Class[] classes)
            {
                this.number = number;
                this._type = _type;
                this.classes = new List<long>();
                foreach (Class c in classes)
                {
                    this.classes.Add(hash(c.Name));
                }
            }
        }
        public class Class
        {
            //w klasie tylko longi
            private string name;
            public string Name { get => name; set => name = value; }
            private string code;
            private int duration;
            private List<long> teachers;
            private List<long> students;
            public Class(string name, string code, int duration, Teacher[] teachers, Student[] students)
            {
                this.name = name;
                this.code = code;
                this.duration = duration;
                this.teachers = new List<long>();
                foreach (Teacher t in teachers)
                {
                    this.teachers.Add(hash(t.Name));
                }
                this.students = new List<long>();
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
            public Teacher(string[] names, string surname, rank _rank, string code, Class[] classes)
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
            public Student(string[] names, string surname, int semester, string code, Class[] classes)
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
    }
}
