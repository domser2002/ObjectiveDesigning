using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class HmAdapter : IRepresentation
    {
        public IRoom[] rooms
        {
            get
            {
                List<IRoom> rooms = new List<IRoom>();
                foreach (Hashmap.Room room in this.adaptee.rooms)
                {
                    rooms.Add(new HmRoomAdapter(room));
                }
                return rooms.ToArray();
            }
        }
        public IClass[] classes
        {
            get
            {
                List<IClass> classes = new List<IClass>();
                foreach (Hashmap.Class c in this.adaptee.classes)
                {
                    classes.Add(new HmClassAdapter(c));
                }
                return classes.ToArray();
            }
        }
        public ITeacher[] teachers
        {
            get
            {
                List<ITeacher> teachers = new List<ITeacher>();
                foreach (Hashmap.Teacher teacher in this.adaptee.teachers)
                {
                    teachers.Add(new HmTeacherAdapter(teacher));
                }
                return teachers.ToArray();
            }
        }
        public IStudent[] students
        {
            get
            {
                List<IStudent> students = new List<IStudent>();
                foreach (Hashmap.Student student in this.adaptee.students)
                {
                    students.Add(new HmStudentAdapter(student));
                }
                return students.ToArray();
            }
        }
        private readonly Hashmap adaptee;
        public HmAdapter(Hashmap adaptee)
        {
            this.adaptee = adaptee;
        }
    }
    public class HmTeacherAdapter : ITeacher
    {
        private readonly Hashmap.Teacher adaptee;
        public List<string> Names
        {
            get
            {
                List<string> names = new List<string>();
                string? tmp;
                foreach (int name in this.adaptee.Names)
                {
                    bool v = Hashmap.Teacher.Map.TryGetValue(name, out tmp);
                    if (v && tmp is not null)
                        names.Add(tmp);
                }
                return names;
            }
        }
        public string Surname
        {
            get
            {
                string? tmp;
                Hashmap.Teacher.Map.TryGetValue(this.adaptee.Surname, out tmp);
                return (tmp is not null) ? tmp : "";
            }
        }
        public rank _Rank => this.adaptee._Rank;
        public string Code
        {
            get
            {
                string? tmp;
                Hashmap.Teacher.Map.TryGetValue(this.adaptee.Code, out tmp);
                return (tmp is not null) ? tmp : "";
            }
        }
        public List<IClass> Classes
        {
            get
            {
                List<IClass> classes = new List<IClass>();
                foreach (Hashmap.Class c in this.adaptee.Classes)
                {
                    classes.Add(new HmClassAdapter(c));
                }
                return classes;
            }
        }
        public HmTeacherAdapter(Hashmap.Teacher teacher)
        {
            this.adaptee = teacher;
        }
    }
    public class HmRoomAdapter : IRoom
    {
        private readonly Hashmap.Room adaptee;
        public int Number => this.adaptee.Number;
        public type _Type => this.adaptee._Type;
        public List<IClass> Classes
        {
            get
            {
                List<IClass> classes = new List<IClass>();
                foreach (Hashmap.Class c in this.adaptee.Classes)
                {
                    classes.Add(new HmClassAdapter(c));
                }
                return classes;
            }
        }

        public HmRoomAdapter(Hashmap.Room room)
        {
            this.adaptee = room;
        }
    }
    public class HmClassAdapter : IClass
    {
        private readonly Hashmap.Class adaptee;
        public HmClassAdapter(Hashmap.Class _class)
        {
            this.adaptee = _class;
        }
        public string Name
        {
            get
            {
                string? tmp;
                Hashmap.Class.Map.TryGetValue(this.adaptee.Name, out tmp);
                return (tmp is not null) ? tmp : "";
            }
        }
        public string Code
        {
            get
            {
                string? tmp;
                Hashmap.Class.Map.TryGetValue(this.adaptee.Code, out tmp);
                return (tmp is not null) ? tmp : "";
            }
        }
        public int Duration => this.adaptee.Duration;
        public List<ITeacher> Teachers
        {
            get
            {
                List<ITeacher> teachers = new List<ITeacher>();
                foreach (Hashmap.Teacher teacher in this.adaptee.Teachers)
                {
                    teachers.Add(new HmTeacherAdapter(teacher));
                }
                return teachers;
            }
        }
        public List<IStudent> Students
        {
            get
            {
                List<IStudent> students = new();
                foreach (Hashmap.Student student in this.adaptee.Students)
                {
                    students.Add(new HmStudentAdapter(student));
                }
                return students;
            }
        }
    }
    public class HmStudentAdapter : IStudent
    {
        private readonly Hashmap.Student adaptee;
        public HmStudentAdapter(Hashmap.Student student)
        {
            this.adaptee = student;
        }
        public List<string> Names
        {
            get
            {
                List<string> names = new List<string>();
                string? tmp;
                foreach (int name in this.adaptee.Names)
                {
                    bool v = Hashmap.Student.Map.TryGetValue(name, out tmp);
                    if (v && tmp is not null)
                        names.Add(tmp);
                }
                return names;
            }
        }
        public string Surname
        {
            get
            {
                string? tmp;
                Hashmap.Student.Map.TryGetValue(this.adaptee.Surname, out tmp);
                return (tmp is not null) ? tmp : "";
            }
        }
        public List<IClass> Classes
        {
            get
            {
                List<IClass> classes = new List<IClass>();
                foreach (Hashmap.Class c in this.adaptee.Classes)
                {
                    classes.Add(new HmClassAdapter(c));
                }
                return classes;
            }
        }
        public int Semester => this.adaptee.Semester;
        public string Code
        {
            get
            {
                string? tmp;
                Hashmap.Student.Map.TryGetValue(this.adaptee.Code, out tmp);
                return (tmp is not null) ? tmp : "";
            }
        }
    }
}
