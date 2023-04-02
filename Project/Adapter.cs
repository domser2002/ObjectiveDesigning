using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static Project.Hashmap;
using static System.Net.Mime.MediaTypeNames;

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
        public void Select()
        {

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
                bool v = Hashmap.Teacher.Map.TryGetValue(name, out tmp2);
                if (v && tmp2 is not null)
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
            this.adaptee = _class;
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

    public class StAdapter : IRepresentation
    {
        private Stacks adaptee;
        public StAdapter(Stacks adaptee)
        {
            this.adaptee = adaptee;
        }
        private static void ReadEnumerator(IEnumerator<string> iter)
        {
            string final = "";
            int test;
            string s = "";
            while (iter.MoveNext())
            {
                string tmp = iter.Current;
                if (int.TryParse(tmp, out test))
                {
                    for (int i = 0; i < test; i++)
                    {
                        iter.MoveNext();
                        s += iter.Current + " ";
                    }
                    final = s + "\n" + final;
                    s = "";
                }
                else
                {
                    s += tmp + ": ";
                }
            }
            Console.Write(final);
        }
        public void Display()
        {
            Console.WriteLine("\nFORMAT 8:\n");
            Console.WriteLine("Rooms:");
            foreach ((int, Stack<string>) room in this.adaptee.rooms)
            {
                Console.WriteLine("Number: " + room.Item1);
                var iter = room.Item2.GetEnumerator();
                ReadEnumerator(iter);
            }
            Console.WriteLine("Classes:");
            foreach ((string, Stack<string>) c in this.adaptee.classes)
            {
                Console.WriteLine("Code: " + c.Item1);
                var iter = c.Item2.GetEnumerator();
                ReadEnumerator(iter);
            }
            Console.WriteLine("Teachers:");
            foreach ((string, Stack<string>) teacher in this.adaptee.teachers)
            {
                Console.WriteLine("Code: " + teacher.Item1);
                var iter = teacher.Item2.GetEnumerator();
                ReadEnumerator(iter);
            }
            Console.WriteLine("Students:");
            foreach ((string, Stack<string>) student in this.adaptee.students)
            {
                Console.WriteLine("Code: " + student.Item1);
                var iter = student.Item2.GetEnumerator();
                ReadEnumerator(iter);
            }
        }
        public void Select()
        {
            foreach ((string, Stack<string>) c in this.adaptee.classes)
            {
                bool student = false;
                bool teacher = false;
                int tmp, tmp2;
                var iter = c.Item2.GetEnumerator();
                while (iter.MoveNext())
                {
                    if (iter.Current == "Students")
                    {
                        iter.MoveNext();
                        int.TryParse(iter.Current, out tmp);
                        for (int i = 0; i < tmp; i++)
                        {
                            iter.MoveNext();
                            string scode = iter.Current;
                            foreach ((string, Stack<string>) s in this.adaptee.students)
                            {
                                if (s.Item1 == scode)
                                {
                                    var iters = s.Item2.GetEnumerator();
                                    while (iters.MoveNext())
                                    {
                                        if (iters.Current == "Names")
                                        {
                                            iters.MoveNext();
                                            int.TryParse(iters.Current, out tmp2);
                                            if (tmp2 > 1)
                                            {
                                                student = true;
                                                break;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    if (iter.Current == "Teachers")
                    {
                        iter.MoveNext();
                        int.TryParse(iter.Current, out tmp);
                        for (int i = 0; i < tmp; i++)
                        {
                            iter.MoveNext();
                            string tcode = iter.Current;
                            foreach ((string, Stack<string>) t in this.adaptee.teachers)
                            {
                                if (t.Item1 == tcode)
                                {
                                    var iters = t.Item2.GetEnumerator();
                                    while (iters.MoveNext())
                                    {
                                        if (iters.Current == "Names")
                                        {
                                            iters.MoveNext();
                                            int.TryParse(iters.Current, out tmp2);
                                            if (tmp2 > 1)
                                            {
                                                teacher = true;
                                                break;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                if (!student) { continue; }
                if (!teacher) { continue; }
                iter = c.Item2.GetEnumerator();
                Console.WriteLine("Code: " + c.Item1);
                ReadEnumerator(iter);
            }
        }
    }
}
