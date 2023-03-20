using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public interface ObjInterface
    {
        public List<Objects.Room>? rooms { get; }
        public List<Objects.Class>? classes { get; }
        public List<Objects.Teacher>? teachers { get; }
        public List<Objects.Student>? students { get; }

    }


    public class Adapter : ObjInterface
    {
        private readonly Hashmap _adaptee;
        public List<Objects.Room>? rooms { get; }
        public List<Objects.Class>? classes { get; }
        public List<Objects.Teacher>? teachers { get; }
        public List<Objects.Student>? students { get; }
        public Adapter(Hashmap adaptee)
        {
            this._adaptee = adaptee;
            rooms = new List<Objects.Room>();
            classes = new List<Objects.Class>();
            teachers = new List<Objects.Teacher>();
            students = new List<Objects.Student>();
            if (this._adaptee.students is not null)
            {
                foreach (Hashmap.Student hs in this._adaptee.students)
                {
                    Objects.Student os = new Objects.Student(hs.Names.ToArray(), hs.Surname, hs.Semester, hs._Code);
                    this.students.Add(os);
                }
            }
            if (this._adaptee.teachers is not null)
            {
                foreach (Hashmap.Teacher ht in this._adaptee.teachers)
                {
                    Objects.Teacher ot = new Objects.Teacher(ht.Names.ToArray(), ht.Surname, ht._Rank, ht._Code);
                    this.teachers.Add(ot);
                }
            }
            if (this._adaptee.rooms is not null)
            {
                foreach (Hashmap.Room hr in this._adaptee.rooms)
                {
                    Objects.Room or = new Objects.Room(hr.Number, hr._Type);
                    this.rooms.Add(or);
                }
            }
            if (this._adaptee.classes is not null)
            {
                foreach (Hashmap.Class hc in this._adaptee.classes)
                {
                    Objects.Class oc = new Objects.Class(hc.Name, hc._Code, hc.Duration);
                    this.classes.Add(oc);
                }
            }
            //foreach(Objects.Class c in this.classes) 
            //{
            //    foreach(Objects.Student s in this.students)
            //    {
            //        if(s.Code.GetHashCode()==hs.Code)
            //    }
            //}
        }
    }
}
