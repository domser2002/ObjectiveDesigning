using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class HmAdapter : IRepresentation
    {
        private readonly Hashmap _adaptee;
        public Room[] rooms { get; set; }
        public Class[] classes { get; set; }
        public Teacher[] teachers { get; set; }
        public Student[] students { get; set; }
        public HmAdapter(Hashmap adaptee)
        {
            this._adaptee = adaptee;
        }
    }
    public class HmTeacherAdapter : ITeacher
    {
        Hashmap.Teacher adaptee;
        public List<string> Names { get => adaptee.Names; }
        public string Surname { get => adaptee.Surname; }
        public rank _Rank { get => adaptee._Rank; }
        public string Code { get => adaptee._Code; }
        public List<Class> Classes
        {
            get
            {
                List<Class> list = new List<Class>();
                List<long> tmp = new List<long>(adaptee.Classes);
                return list;
            }
        }
        public void AddClass(Class c)
        {
            this.Classes.Add(c);
        }
        public HmTeacherAdapter(Hashmap.Teacher teacher)
        {
            this.adaptee = teacher;
        }
    }
    public class HmRoomAdapter : IRoom
    {
        privare Hashmap.Room adaptee;
        public int Number { get { return adaptee.Number; } }
        public type _Type { get; }
        public List<Class> Classes { get; }
        public void AddClass(Class c)
        {
            this.Classes.Add(c);
        }
        Class c;
        c.Code.GetHashCode()
        public HmRoomAdapter(Hashmap.Room room)
        {
            this.adaptee = room;

        }
    }
    public class HmClassAdapter : IClass
    {
        public string Name { get; }
        public string Code { get; }
        public int Duration { get; }
        public List<Teacher> Teachers { get; }
        public List<Student> Students { get; }
        public void AddStudent(Student s)
        {
            this.Students.Add(s);
        }
        public void AddTeacher(Teacher t)
        {
            this.Teachers.Add(t);
        }
        public HmClassAdapter(Hashmap.Class _class)
        {
            this.Name = _class.Name;
            this.Duration = _class.Duration;
            this.Code = _class._Code;
            this.Teachers = new List<Teacher>();
            this.Students = new List<Student>();
        }
    }
    public class HmStudentAdapter : IStudent
    {
        public List<string> Names { get; }
        public string Surname { get; }
        public int Semester { get; }
        public string Code { get; }
        public List<Class> Classes { get; }
        public void AddClass(Class c)
        {
            this.Classes.Add(c);
        }
        public HmStudentAdapter(Hashmap.Student student)
        {
            this.Names = student.Names;
            this.Semester = student.Semester;
            this.Surname = student.Surname;
            this.Code = student._Code;
            this.Classes = new List<Class>();
        }
    }
}
