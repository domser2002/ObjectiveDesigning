using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class Program
    {
        public static void Main()
        {
            //first representation
            Room[] rooms=new Room[7];
            Class[] classes=new Class[4];
            Student[] students=new Student[5];
            Teacher[] teachers = new Teacher[5];
            rooms[0] = new Room(107,type.lecture,ref { classes[0], classes[1], classes[2], classes[3] });
            rooms[1] = new Room(204, type.tutorials, new Class[] { classes[2], classes[3] });
            rooms[2] = new Room(21, type.lecture, new Class[] { classes[1] });
            rooms[3] = new Room(123, type.laboratory, new Class[] { classes[1], classes[2] });
            rooms[4] = new Room(404, type.lecture, new Class[] { classes[0], classes[1], classes[2] });
            rooms[5] = new Room(504, type.tutorials, new Class[] { classes[0] });
            rooms[6] = new Room(73, type.laboratory, new Class[] { classes[3] });

            classes[0] = new Class("Diabolical Mathematics 2", "MD2", 2, 
            new Teacher[] { teachers[1] }, new Student[] { students[0], students[1], students[4] });
            classes[1] = new Class("Routers Descriptions", "RD", 1,
            new Teacher[] { teachers[2] }, new Student[] { students[2], students[3] });
            classes[2] = new Class("Introduction to cables", "WDK", 5,
            new Teacher[] { teachers[2], teachers[3] }, students);
            classes[3] = new Class("Diabolical Mathematics 2", "MD2", 2,
            new Teacher[] { teachers[1] }, new Student[] { students[0], students[1], students[4] });

            teachers[0]=new Teacher(new string[] { "John", "Jan" },"x",rank.MiB,"UU",classes);
            //second representation

        }
    }
}
