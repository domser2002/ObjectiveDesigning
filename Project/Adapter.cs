using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public interface ObjInterface
    {
        public Objects.Student[]? students { get; }
        public Objects.Class[]? classes { get; }
        public Objects.Teacher[]? teachers { get; }
        public Objects.Room[]? rooms { get; }

    }


    public class Adapter : ObjInterface
        {
            private readonly Hashmap _adaptee;
            public Objects.Student[]? students { get; }
            public Objects.Class[]? classes { get; }
            public Objects.Teacher[]? teachers { get; }
            public Objects.Room[]? rooms { get; }
            public Adapter(Hashmap adaptee)
            {
                this._adaptee = adaptee;
                if (this._adaptee.students is not null)
                {
                    foreach (Hashmap.Student hs in this._adaptee.students)
                    {
                    Objects.Student os = new Objects.Student(hs.Names.ToArray(), hs.Surname, hs.Semester, hs.Code); 
                    }
                }
            }
        }
}
