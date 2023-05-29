using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using static Project.Hashmap;

namespace Project
{
    public class Objects : IRepresentation
    {
        public IRoom[] Rooms { get; set; }
        public IClass[] Classes { get; set; }
        public ITeacher[] Teachers { get; set; }
        public IStudent[] Students { get; set; }
        public Objects(Room[] rooms, Class[] classes, Teacher[] teachers, Student[] students)
        {
            this.Rooms = rooms;
            this.Classes = classes;
            this.Teachers = teachers;
            this.Students = students;
        }
        public void AddStudent(Student s)
        {
            var tmp = this.Students.ToList();
            tmp.Add(s);
            this.Students = tmp.ToArray();
        }
        public void AddTeacher(Teacher t)
        {
            var tmp = this.Teachers.ToList();
            tmp.Add(t);
            this.Teachers = tmp.ToArray();
        }
        public void AddClass(Class c)
        {
            var tmp = this.Classes.ToList();
            tmp.Add(c);
            this.Classes = tmp.ToArray();
        }
        public void AddRoom(Room r)
        {
            var tmp = this.Rooms.ToList();
            tmp.Add(r);
            this.Rooms = tmp.ToArray();
        }
        public void Add(IObject obj)
        {
            if (obj is null) return;
            if(obj is Student student)
            {
                AddStudent(student);
                return;
            }
            if (obj is Teacher teacher)
            {
                AddTeacher(teacher);
                return;
            }
            if (obj is Class c)
            {
                AddClass(c);
                return;
            }
            if (obj is Room room)
            {
                AddRoom(room);
                return;
            }
        }
        public void Delete(IObject obj)
        {
            if (obj is null) return;
            if (obj is Student student)
            {
                var tmp = this.Students.ToList();
                tmp.Remove(student);
                this.Students = tmp.ToArray();
                return;
            }
            if (obj is Teacher teacher)
            {
                var tmp = this.Teachers.ToList();
                tmp.Remove(teacher);
                this.Teachers = tmp.ToArray();
                return;
            }
            if (obj is Class c)
            {
                var tmp = this.Classes.ToList();
                tmp.Remove(c);
                this.Classes = tmp.ToArray();
                return;
            }
            if (obj is Room room)
            {
                var tmp = this.Rooms.ToList();
                tmp.Remove(room);
                this.Rooms = tmp.ToArray();
                return;
            }
        }
    }
    public class Room : IRoom
    {
        public Dictionary<string, object> Properties { get; set; }
        private int number;
        public int Number {
            get
            {
                if (this.Properties["number"].ToString() != this.number.ToString())
                    _ = int.TryParse(this.Properties["number"].ToString(), out number);
                return this.number;
            }
            set 
            {
                if(!this.Properties.ContainsKey("number"))
                    this.Properties.Add("number", value);
                this.Properties["number"] = value;
                this.number = value; 
            }
        }
        private Type type;
        public Type Type {
            get
            {
                if (this.Properties["type"].ToString() != this.type.ToString())
                    _ = Enum.TryParse(this.Properties["type"].ToString(), out this.type);
                return this.type;
            }
            set
            {
                if(!this.Properties.ContainsKey("type"))
                    Properties.Add("type", value);  
                this.Properties["type"] = value;
                this.type = value;
            }
        }
        private readonly List<IClass> classes;
        public List<IClass> Classes { get => this.classes; }
        public Room(int number, Type type)
        {
            Properties = new();
            this.number = number;
            Properties.AddOrIgnore("number", this.number);
            this.type = type;
            Properties.AddOrIgnore("type", this.type);
            this.classes = new();
        }
        public Room()
        {
            Properties = new();
            this.number = default;
            Properties.AddOrIgnore("number", this.number);
            this.type = default;
            Properties.AddOrIgnore("type", this.type);
            this.classes = new();
        }
        public void AddClass(Class c)
        {
            this.classes.Add(c);
        }
        public void Display() => Extensions.Display(this);
        public IObject Copy()
        {
            return new Room(this.number,this.type);
        }
    }
    public class Class : IClass
    {
        public Dictionary<string, object> Properties { get; set; }
        private string name;
        public string Name {
            get
            {
                if (this.Properties["name"].ToString() != this.name.ToString())
                    this.name=(string)this.Properties["name"];
                return this.name;
            }
            set
            {
                if(!this.Properties.ContainsKey("name"))
                    this.Properties.Add("name", value); 
                this.Properties["name"] = value;
                this.name = value;
            }
        }
        private string code;
        public string Code
        {
            get
            {
                if (this.Properties["code"].ToString() != this.code.ToString())
                    this.code = (string)this.Properties["code"];
                return this.code;
            }
            set
            {
                if (!this.Properties.ContainsKey("code"))
                    this.Properties.Add("code", value);
                this.Properties["code"] = value;
                this.code = value;
            }
        }
        private int duration;
        public int Duration
        {
            get
            {
                if (this.Properties["duration"].ToString() != this.duration.ToString())
                    
                    
                    _ = int.TryParse(this.Properties["duration"].ToString(), out duration);
                return this.duration;
            }
            set
            {
                if (!this.Properties.ContainsKey("duration"))
                    this.Properties.Add("duration", value);
                this.Properties["duration"] = value;
                this.duration = value;
            }
        }
        private readonly List<ITeacher> teachers;
        public List<ITeacher> Teachers { get => this.teachers; }
        private readonly List<IStudent> students;
        public List<IStudent> Students { get => this.students; }
        public Class(string name, string code, int duration)
        {
            Properties = new();
            this.name = name;
            Properties.AddOrIgnore("name", this.name);
            this.code = code;
            Properties.AddOrIgnore("code", this.code);
            this.duration = duration;
            Properties.AddOrIgnore("duration", this.duration);
            this.teachers = new();
            this.students = new();
        }
        public Class()
        {
            Properties = new();
            this.name = "";
            Properties.AddOrIgnore("name", this.name);
            this.code = "";
            Properties.AddOrIgnore("code", this.code);
            this.duration = default;
            Properties.AddOrIgnore("duration", this.duration);
            this.teachers = new();
            this.students = new();
        }
        public void AddStudent(Student s)
        {
            this.students.Add(s);
        }
        public void AddTeacher(Teacher t)
        {
            this.teachers.Add(t);
        }
        public void Display() => Extensions.Display(this);
        public IObject Copy()
        {
            return new Class(this.name,this.code,this.duration);
        }
    }
    public class Teacher : ITeacher
    {
        public Dictionary<string, object> Properties { get; set; }
        private List<string> names;
        public List<string> Names {
            get
            {
                if (this.Properties["name"] is List<string> list)
                {
                    if (list != this.names)
                        this.names = list;
                }
                return this.names;
            }
            set
            {
                if (this.Properties.ContainsKey("name"))
                    this.Properties.Add("name", value);    
                this.Properties["name"] = value;
                this.names = value;
            }
        }
        private string surname;
        public string Surname
        {
            get
            {
                if (this.Properties["surname"].ToString() != this.surname)
                    this.surname = (string)this.Properties["surname"];
                return this.surname;
            }
            set
            {
                if (this.Properties.ContainsKey("surname"))
                    this.Properties.Add("surname", value);
                this.Properties["surname"] = value;
                this.surname = value;
            }
        }
        private Rank rank;
        public Rank Rank
        {
            get
            {
                if (this.Properties["rank"].ToString() != this.rank.ToString())
                    _ = Enum.TryParse(this.Properties["rank"].ToString(),out rank);
                return this.rank;
            }
            set
            {
                if (this.Properties.ContainsKey("rank"))
                    this.Properties.Add("rank", value);
                this.Properties["rank"] = value;
                this.rank = value;
            }
        }
        private string code;
        public string Code
        {
            get
            {
                if (this.Properties["code"].ToString() !=this.code)
                    this.code= (string)this.Properties["code"];
                return this.code;
            }
            set
            {
                if (this.Properties.ContainsKey("code"))
                    this.Properties.Add("code", value);
                this.Properties["code"] = value;
                this.code = value;
            }
        }
        private readonly List<IClass> classes;
        public List<IClass> Classes { get => this.classes; }
        public Teacher(string[] names, string surname, Rank rank, string code)
        {
            Properties = new();
            this.names = new();
            foreach (string name in names)
            {
                this.names.Add(name);
            }
            Properties.AddOrIgnore("name", this.names);
            this.surname = surname;
            Properties.AddOrIgnore("surname", this.surname);
            this.rank = rank;
            Properties.AddOrIgnore("rank", this.rank);
            this.code = code;
            Properties.AddOrIgnore("code", this.code);
            this.classes = new();
        }
        public Teacher()
        {
            Properties = new();
            this.names = new();
            Properties.AddOrIgnore("name", this.names);
            this.surname = "";
            Properties.AddOrIgnore("surname", this.surname);
            this.rank = default;
            Properties.AddOrIgnore("rank", this.rank);
            this.code = "";
            Properties.AddOrIgnore("code", this.code);
            this.classes = new();
        }
        public void AddClass(Class c)
        {
            this.classes.Add(c);
        }
        public void Display() => Extensions.Display(this);
        public IObject Copy()
        {
            return new Teacher(this.names.ToArray(),this.surname,this.rank,this.code);
        }
    }
    public class Student : IStudent
    {
        public Dictionary<string, object> Properties { get; set; }
        private List<string> names;
        public List<string> Names
        {
            get
            {
                if (this.Properties["name"] is List<string> list)
                {
                    if (list != this.names)
                        this.names = list;
                }
                return this.names;
            }
            set
            {
                if (this.Properties.ContainsKey("name"))
                    this.Properties.Add("name", value);
                this.Properties["name"] = value;
                this.names = value;
            }
        }
        private string surname;
        public string Surname
        {
            get
            {
                if (this.Properties["surname"].ToString() != this.surname)
                    this.surname = (string)this.Properties["surname"];
                return this.surname;
            }
            set
            {
                if (this.Properties.ContainsKey("surname"))
                    this.Properties.Add("surname", value);
                this.Properties["surname"] = value;
                this.surname = value;
            }
        }
        private int semester;
        public int Semester
        {
            get
            {
                if (this.Properties["semester"].ToString() != this.semester.ToString())
                    _ = int.TryParse(this.Properties["semester"].ToString(), out semester);
                return this.semester;
            }
            set
            {
                if (this.Properties.ContainsKey("semester"))
                    this.Properties.Add("semester", value);
                this.Properties["semester"] = value;
                this.semester = value;
            }
        }
        private string code;
        public string Code
        {
            get
            {
                if (this.Properties["code"].ToString() != this.code)
                    this.code = (string)this.Properties["code"];
                return this.code;
            }
            set
            {
                if (this.Properties.ContainsKey("code"))
                    this.Properties.Add("code", value);
                this.Properties["code"] = value;
                this.code = value;
            }
        }
        private readonly List<IClass> classes;
        public List<IClass> Classes { get => this.classes; }
        public Student(string[] names, string surname, int semester, string code)
        {
            Properties = new();
            this.names = new();
            foreach (string name in names)
            {
                this.names.Add(name);
            }
            Properties.AddOrIgnore("name", this.names);
            this.surname = surname;
            Properties.AddOrIgnore("surname", this.surname);
            this.semester = semester;
            Properties.AddOrIgnore("semester", this.semester);
            this.code = code;
            Properties.AddOrIgnore("code", this.code);
            this.classes = new();
        }
        public Student()
        {
            Properties = new();
            this.names = new();
            Properties.AddOrIgnore("name", this.names);
            this.surname = "";
            Properties.AddOrIgnore("surname", this.surname);
            this.semester = default;
            Properties.AddOrIgnore("semester", this.semester);
            this.code = "";
            Properties.AddOrIgnore("code", this.code);
            this.classes = new();
        }
        public void AddClass(Class c)
        {
            this.classes.Add(c);
        }
        public void Display() => Extensions.Display(this);
        public IObject Copy()
        {
            return new Student(this.names.ToArray(),this.surname,this.semester,this.code);
        }
    }
}
