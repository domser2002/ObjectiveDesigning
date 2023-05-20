using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static Project.Hashmap;
using static System.Net.Mime.MediaTypeNames;

namespace Project
{
    public class StAdapter : IRepresentation
    {
        private readonly Stacks adaptee;
        public IRoom[] Rooms
        {
            get
            {
                List<IRoom> rooms = new List<IRoom>();
                foreach ((int, Stack<string>) room in this.adaptee.Rooms)
                {
                    Room tmp;
                    int number = room.Item1;
                    var iter = room.Item2.GetEnumerator();
                    int test;
                    List<string> class_codes=new List<string>();
                    Type _type=Type.tutorials;
                    while (iter.MoveNext())
                    {
                        switch(iter.Current)
                        {
                            case "Classes":
                                iter.MoveNext();
                                if (!int.TryParse(iter.Current, out test))
                                {
                                    throw new BadRepresentationException();
                                }
                                for(int i = 0; i < test; i++)
                                {
                                    iter.MoveNext();
                                    class_codes.Add(iter.Current);
                                }
                                break;
                            case "Type":
                                iter.MoveNext();
                                if (!int.TryParse(iter.Current, out test))
                                {
                                    throw new BadRepresentationException();
                                }
                                if(test!=1)
                                {
                                    throw new BadRepresentationException();
                                }
                                iter.MoveNext();
                                if (!Enum.TryParse(iter.Current,out _type))
                                {
                                    throw new BadRepresentationException();
                                }
                                break;
                            default:
                                throw new BadRepresentationException();
                        }
                    }
                    tmp = new Room(number, _type);
                    foreach(string class_code in class_codes)
                    {
                        tmp.AddClass(new Class("", class_code, 0));
                    }
                    rooms.Add(tmp);
                }
                return rooms.ToArray();
            }
        }
        public IClass[] Classes {
            get
            {
                List<IClass> classes = new List<IClass>();
                foreach ((string, Stack<string>) c in this.adaptee.Classes)
                {
                    Class tmp;
                    string code = c.Item1;
                    var iter = c.Item2.GetEnumerator();
                    int test;
                    string name="";
                    int duration=0;
                    List<string> student_codes=new();
                    List<string> teacher_codes=new();
                    while (iter.MoveNext())
                    {
                        switch(iter.Current)
                        {
                            case "Name":
                                iter.MoveNext();
                                if(!int.TryParse(iter.Current, out test) || test!=1)
                                {
                                    throw new BadRepresentationException();
                                }
                                iter.MoveNext();
                                name=iter.Current;
                                break;
                            case "Duration":
                                iter.MoveNext();
                                if (!int.TryParse(iter.Current, out test) || test != 1)
                                {
                                    throw new BadRepresentationException();
                                }
                                iter.MoveNext();
                                if(!int.TryParse(iter.Current,out duration))
                                {
                                    throw new BadRepresentationException();
                                }
                                break;
                            case "Teachers":
                                iter.MoveNext();
                                if(!int.TryParse(iter.Current,out test))
                                {
                                    throw new BadRepresentationException();
                                }
                                for (int i = 0; i < test; i++)
                                {
                                    iter.MoveNext();
                                    string teacher_code = iter.Current;
                                    teacher_codes.Add(teacher_code);
                                }
                                break;
                            case "Students":
                                iter.MoveNext();
                                if (!int.TryParse(iter.Current, out test))
                                {
                                    throw new BadRepresentationException();
                                }
                                for (int i = 0; i < test; i++)
                                {
                                    iter.MoveNext();
                                    string student_code = iter.Current;
                                    student_codes.Add(student_code);
                                }
                                break;
                            default:
                                Console.WriteLine(iter.Current);
                                throw new BadRepresentationException();
                        }
                    }
                    tmp = new Class(name,code,duration);
                    foreach(string student_code in student_codes)
                    {
                        tmp.AddStudent(new Student(Array.Empty<string>(), "", 1, student_code));
                    }
                    foreach (string teacher_code in teacher_codes)
                    {
                        tmp.AddTeacher(new Teacher(Array.Empty<string>(), "", Rank.KiB, teacher_code));
                    }
                    classes.Add(tmp);
                }
                return classes.ToArray();
            }
        }
        public ITeacher[] Teachers { 
            get 
            {
                List<ITeacher> teachers = new();
                foreach((string,Stack<string>) teacher in this.adaptee.Teachers)
                {
                    Teacher tmp;
                    int test;
                    string code = teacher.Item1;
                    var iter = teacher.Item2.GetEnumerator();
                    List<string> names = new();
                    string surname="";
                    Rank _rank=Rank.KiB;
                    List<string> class_codes = new();
                    while (iter.MoveNext())
                    {
                        switch (iter.Current)
                        {
                            case "Names":
                                iter.MoveNext();
                                if (!int.TryParse(iter.Current, out test))
                                {
                                    throw new BadRepresentationException();
                                }
                                for (int i = 0; i < test; i++)
                                {
                                    iter.MoveNext();
                                    names.Add(iter.Current);
                                }
                                break;
                            case "Surname":
                                iter.MoveNext();
                                if (!int.TryParse(iter.Current, out test) || test != 1)
                                {
                                    throw new BadRepresentationException();
                                }
                                iter.MoveNext();
                                surname = iter.Current;
                                break;
                            case "Rank":
                                iter.MoveNext();
                                if (!int.TryParse(iter.Current, out test) || test != 1)
                                {
                                    throw new BadRepresentationException();
                                }
                                iter.MoveNext();
                                if (!Enum.TryParse(iter.Current, out _rank))
                                {
                                    throw new BadRepresentationException();
                                }
                                break;
                            case "Classes":
                                iter.MoveNext();
                                if (!int.TryParse(iter.Current, out test))
                                {
                                    throw new BadRepresentationException();
                                }
                                for (int i = 0; i < test; i++)
                                {
                                    iter.MoveNext();
                                    class_codes.Add(iter.Current);
                                }
                                break;
                        }
                    }
                        tmp = new Teacher(names.ToArray(),surname,_rank,code);
                        foreach (string class_code in class_codes)
                        {
                            tmp.AddClass(new Class("", class_code, 0));
                        }
                        teachers.Add(tmp);
                }
                return teachers.ToArray();
            }
        }
        public IStudent[] Students { 
            get
            {
                List<IStudent> students = new();
                foreach ((string, Stack<string>) student in this.adaptee.Students)
                {
                    Student tmp;
                    int test;
                    string code = student.Item1;
                    var iter = student.Item2.GetEnumerator();
                    List<string> names = new();
                    string surname = "";
                    int semester = 0;
                    List<string> class_codes = new();
                    while (iter.MoveNext())
                    {
                        switch (iter.Current)
                        {
                            case "Names":
                                iter.MoveNext();
                                if (!int.TryParse(iter.Current, out test))
                                {
                                    throw new BadRepresentationException();
                                }
                                for (int i = 0; i < test; i++)
                                {
                                    iter.MoveNext();
                                    names.Add(iter.Current);
                                }
                                break;
                            case "Surname":
                                iter.MoveNext();
                                if (!int.TryParse(iter.Current, out test) || test != 1)
                                {
                                    throw new BadRepresentationException();
                                }
                                iter.MoveNext();
                                surname = iter.Current;
                                break;
                            case "Semester":
                                iter.MoveNext();
                                if (!int.TryParse(iter.Current, out test) || test != 1)
                                {
                                    throw new BadRepresentationException();
                                }
                                iter.MoveNext();
                                if (!int.TryParse(iter.Current, out semester))
                                {
                                    throw new BadRepresentationException();
                                }
                                break;
                            case "Classes":
                                iter.MoveNext();
                                if (!int.TryParse(iter.Current, out test))
                                {
                                    throw new BadRepresentationException();
                                }
                                for (int i = 0; i < test; i++)
                                {
                                    iter.MoveNext();
                                    class_codes.Add(iter.Current);
                                }
                                break;
                        }
                    }
                        tmp = new Student(names.ToArray(), surname, semester, code);
                        foreach (string class_code in class_codes)
                        {
                            tmp.AddClass(new Class("", class_code, 0));
                        }
                        students.Add(tmp);
                }
                return students.ToArray();
            }
        }
        public StAdapter(Stacks adaptee)
        {
            this.adaptee = adaptee;
        }
    }
}
