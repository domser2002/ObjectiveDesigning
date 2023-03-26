﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static Project.Hashmap;

namespace Project
{
    public class HmAdapter : IRepresentation
    {
        private readonly Hashmap adaptee;
        public HmAdapter(Hashmap adaptee)
        {
            this.adaptee = adaptee;
        }
        public void Display()
        {
            Console.WriteLine("FORMAT 4:");
            Console.WriteLine();
            Console.WriteLine("Rooms:");
            foreach (Hashmap.Room r in adaptee.rooms)
            {
                new HmRoomAdapter(r).Display();
            }
            Console.WriteLine();
            Console.WriteLine("Classes:");
            foreach (Hashmap.Class c in adaptee.classes)
            {
                new HmClassAdapter(c).Display();
            }
            Console.WriteLine();
            Console.WriteLine("Teachers:");
            foreach (Hashmap.Teacher t in adaptee.teachers)
            {
                new HmTeacherAdapter(t).Display();
            }
            Console.WriteLine();
            Console.WriteLine("Students:");
            foreach (Hashmap.Student s in adaptee.students)
            {
                new HmStudentAdapter(s).Display();
            }
        }
    }
    public class HmTeacherAdapter : ITeacher
    {
        Hashmap.Teacher adaptee;
        public HmTeacherAdapter(Hashmap.Teacher teacher)
        {
            this.adaptee = teacher;
        }
        public void Display()
        {
            string tmp = "";
            string? tmp2;
            foreach (int name in this.adaptee.Names)
            {
                bool v=Hashmap.Teacher.Map.TryGetValue(name, out tmp2);
                if(v && tmp2 is not null)
                    tmp += tmp2 + " ";
            }
            Console.WriteLine("Names: " + tmp);
            Hashmap.Teacher.Map.TryGetValue(this.adaptee.Surname, out tmp2);
            Console.WriteLine("Surname: " + tmp2);
            Console.WriteLine("Rank: " + this.adaptee._Rank);
            Hashmap.Teacher.Map.TryGetValue(this.adaptee.Code, out tmp2);
            Console.WriteLine("Code: " + tmp2);
            string s = "";
            foreach (Hashmap.Class c in this.adaptee.Classes)
            {
                Hashmap.Class.Map.TryGetValue(c.Code, out tmp2);
                s += tmp2 + " ";
            }
            Console.WriteLine("Classes: " + s);
        }
    }
    public class HmRoomAdapter : IRoom
    {
        private Hashmap.Room adaptee;
        public HmRoomAdapter(Hashmap.Room room)
        {
            this.adaptee = room;
        }
        public void Display()
        {
            Console.WriteLine("Number: " + this.adaptee.Number);
            Console.WriteLine("Type: " + this.adaptee._Type);
            string s = "";
            foreach (Hashmap.Class c in this.adaptee.Classes)
            {
                string? tmp;
                bool v = Hashmap.Class.Map.TryGetValue(c.Code, out tmp);
                if (v && tmp is not null)
                {
                    s += tmp + " ";
                }
            }
            Console.WriteLine("Classes: " + s);
        }
    }
    public class HmClassAdapter : IClass
    {
        private Hashmap.Class adaptee;
        public HmClassAdapter(Hashmap.Class _class)
        {
            this.adaptee= _class;
        }
        public void Display()
        {
            string? tmp;
            Hashmap.Class.Map.TryGetValue(this.adaptee.Name, out tmp);
            Console.WriteLine("Name: " + tmp);
            Hashmap.Class.Map.TryGetValue(this.adaptee.Code, out tmp);
            Console.WriteLine("Code: " + tmp);
            Console.WriteLine("Duration: " + this.adaptee.Duration);
            string s = "";
            foreach (Hashmap.Teacher t in this.adaptee.Teachers)
            {
                Hashmap.Teacher.Map.TryGetValue(t.Code, out tmp);   
                s += tmp + " ";
            }
            Console.WriteLine("Teachers: " + s);
            s = "";
            foreach (Hashmap.Student st in this.adaptee.Students)
            {
                Hashmap.Student.Map.TryGetValue(st.Code, out tmp);
                s += tmp + " ";
            }
            Console.WriteLine("Students: " + s);
        }
    }
    public class HmStudentAdapter : IStudent
    {
        Hashmap.Student adaptee;
        public HmStudentAdapter(Hashmap.Student student)
        {
            this.adaptee = student;
        }
        public void Display()
        {
            string tmp = "";
            string? tmp2;
            foreach (int name in this.adaptee.Names)
            {
                bool v = Hashmap.Student.Map.TryGetValue(name, out tmp2);
                if (v && tmp2 is not null)
                    tmp += tmp2 + " ";
            }
            Console.WriteLine("Names: " + tmp);
            Hashmap.Student.Map.TryGetValue(this.adaptee.Surname, out tmp2);
            Console.WriteLine("Surname: " + tmp2);
            Console.WriteLine("Semester: " + this.adaptee.Semester);
            Hashmap.Student.Map.TryGetValue(this.adaptee.Code, out tmp2);
            Console.WriteLine("Code: " + tmp2);
            string s = "";
            foreach (Hashmap.Class c in this.adaptee.Classes)
            {
                Hashmap.Class.Map.TryGetValue(c.Code, out tmp2);
                s += tmp2 + " ";
            }
            Console.WriteLine("Classes: " + s);
        }
    }
}
