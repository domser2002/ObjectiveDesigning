using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Project.Hashmap;

namespace Project
{
    public class Stacks
    {
        private List<(int, Stack<string>)> rooms;
        public List<(int, Stack<string>)> Rooms => this.rooms;
        private List<(string, Stack<string>)> classes;
        public List<(string, Stack<string>)> Classes => this.classes;
        private List<(string, Stack<string>)> teachers;
        public List<(string, Stack<string>)> Teachers => this.teachers;
        private List<(string, Stack<string>)> students;
        public List<(string, Stack<string>)> Students => this.students;
        public Stacks()
        {
            this.rooms=new List<(int, Stack<string>)>();
            this.classes=new List<(string, Stack<string>)>();
            this.teachers=new List<(string, Stack<string>)>();
            this.students=new List<(string, Stack<string>)>();
        }
        public void AddRoom(int number, Type _type, string[] class_codes)
        {
            (int, Stack<string>) room;
            room.Item1 = number;
            room.Item2 = new Stack<string>();
            room.Item2.Push(_type.ToString());
            room.Item2.Push("1");
            room.Item2.Push("Type");
            foreach(var code in class_codes)
            {
                room.Item2.Push(code);
            }
            room.Item2.Push(class_codes.Length.ToString());
            room.Item2.Push("Classes");
            rooms.Add(room);
        }
        public void AddClass(string name, string code, int duration, 
            string[] teacher_codes, string[] student_codes)
        {
            (string, Stack<string>) c;
            c.Item1 = code;
            c.Item2 = new Stack<string>();
            c.Item2.Push(name);
            c.Item2.Push("1");
            c.Item2.Push("Name");
            c.Item2.Push(duration.ToString());
            c.Item2.Push("1");
            c.Item2.Push("Duration");
            foreach(var tcode in teacher_codes) { c.Item2.Push(tcode);}
            c.Item2.Push(teacher_codes.Length.ToString());
            c.Item2.Push("Teachers");
            foreach (var scode in student_codes) { c.Item2.Push(scode); }
            c.Item2.Push(student_codes.Length.ToString());
            c.Item2.Push("Students");
            this.classes.Add(c);
        }
        public void AddTeacher(string[] names, string surname, Rank _rank, string code, string[] class_codes)
        {
            (string,Stack<string>) teacher;
            teacher.Item1 = code;
            teacher.Item2 = new Stack<string>();
            foreach(string name in names) 
            {
                teacher.Item2.Push(name);
            }
            teacher.Item2.Push(names.Length.ToString());
            teacher.Item2.Push("Names");
            teacher.Item2.Push(surname);
            teacher.Item2.Push("1");
            teacher.Item2.Push("Surname");
            teacher.Item2.Push(_rank.ToString());
            teacher.Item2.Push("1");
            teacher.Item2.Push("Rank");
            foreach (var ccode in class_codes)
            {
                teacher.Item2.Push(ccode);
            }
            teacher.Item2.Push(class_codes.Length.ToString());
            teacher.Item2.Push("Classes");
            this.teachers.Add(teacher);
        }
        public void AddStudent(string[] names, string surname, int semester, string code, string[] class_codes)
        {
            (string, Stack<string>) student;
            student.Item1 = code;
            student.Item2 = new Stack<string>();
            foreach (string name in names)
            {
                student.Item2.Push(name);
            }
            student.Item2.Push(names.Length.ToString());
            student.Item2.Push("Names");
            student.Item2.Push(surname);
            student.Item2.Push("1");
            student.Item2.Push("Surname");
            student.Item2.Push(semester.ToString());
            student.Item2.Push("1");
            student.Item2.Push("Semester");
            foreach (var ccode in class_codes)
            {
                student.Item2.Push(ccode);
            }
            student.Item2.Push(class_codes.Length.ToString());
            student.Item2.Push("Classes");
            this.students.Add(student);
        }
        //public class Room
        //{
        //    (int, Stack<string>) room;
        //}
    }
}
