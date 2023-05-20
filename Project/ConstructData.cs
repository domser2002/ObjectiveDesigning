using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public static class ConstructData
    {
        public static Objects ConstructFirst()
        {
            Room[] first_roooms = new Room[7];
            Class[] first_classes = new Class[4];
            Student[] first_students = new Student[5];
            Teacher[] first_teachers = new Teacher[5];
            first_roooms[0] = new Room(107, Type.lecture);
            first_roooms[1] = new Room(204, Type.tutorials);
            first_roooms[2] = new Room(21, Type.lecture);
            first_roooms[3] = new Room(123, Type.laboratory);
            first_roooms[4] = new Room(404, Type.lecture);
            first_roooms[5] = new Room(504, Type.tutorials);
            first_roooms[6] = new Room(73, Type.laboratory);

            first_classes[0] = new Class("Diabolical Mathematics 2", "MD2", 2);
            first_classes[1] = new Class("Routers Descriptions", "RD", 1);
            first_classes[2] = new Class("Introduction to cables", "WDK", 5);
            first_classes[3] = new Class("Diabolical Mathematics 2", "MD2", 2);

            first_teachers[0] = new Teacher(new string[] { "Tomas" }, "Cherrmann", Rank.MiB, "P1");
            first_teachers[1] = new Teacher(new string[] { "Jon" }, "Tron", Rank.TiB, "P2");
            first_teachers[2] = new Teacher(new string[] { "William", "Joseph" }, "Blazkowicz", Rank.GiB, "P3");
            first_teachers[3] = new Teacher(new string[] { "Arkadiusz", "Amadeusz" }, "Kamiński", Rank.KiB, "P4");
            first_teachers[4] = new Teacher(new string[] { "Cooking" }, "Mama", Rank.GiB, "P5");

            first_students[0] = new Student(new string[] { "Robert" }, "Kielbica", 3, "S1");
            first_students[1] = new Student(new string[] { "Archibald", "Agapios" }, "Linux", 7, "S2");
            first_students[2] = new Student(new string[] { "Angrboða" }, "Kára", 1, "S3");
            first_students[3] = new Student(new string[] { "Olympos" }, "Andronikos", 5, "S4");
            first_students[4] = new Student(new string[] { "Mac", "Rhymes" }, "Pickuppicker", 6, "S5");

            first_teachers[0].AddClass(first_classes[3]);
            first_teachers[1].AddClass(first_classes[0]);
            first_teachers[2].AddClass(first_classes[1]);
            first_teachers[2].AddClass(first_classes[2]);
            first_teachers[3].AddClass(first_classes[2]);
            first_teachers[4].AddClass(first_classes[3]);

            first_students[0].AddClass(first_classes[0]);
            first_students[0].AddClass(first_classes[2]);
            first_students[1].AddClass(first_classes[0]);
            first_students[1].AddClass(first_classes[2]);
            first_students[1].AddClass(first_classes[3]);
            first_students[2].AddClass(first_classes[1]);
            first_students[2].AddClass(first_classes[2]);
            first_students[3].AddClass(first_classes[1]);
            first_students[3].AddClass(first_classes[2]);
            first_students[3].AddClass(first_classes[3]);
            first_students[4].AddClass(first_classes[0]);
            first_students[4].AddClass(first_classes[2]);
            first_students[4].AddClass(first_classes[3]);

            first_classes[0].AddStudent(first_students[0]);
            first_classes[0].AddStudent(first_students[1]);
            first_classes[0].AddStudent(first_students[4]);
            first_classes[0].AddTeacher(first_teachers[1]);
            first_classes[1].AddStudent(first_students[2]);
            first_classes[1].AddStudent(first_students[3]);
            first_classes[1].AddTeacher(first_teachers[2]);
            first_classes[2].AddStudent(first_students[0]);
            first_classes[2].AddStudent(first_students[1]);
            first_classes[2].AddStudent(first_students[2]);
            first_classes[2].AddStudent(first_students[3]);
            first_classes[2].AddStudent(first_students[4]);
            first_classes[2].AddTeacher(first_teachers[2]);
            first_classes[2].AddTeacher(first_teachers[3]);
            first_classes[3].AddStudent(first_students[0]);
            first_classes[3].AddStudent(first_students[1]);
            first_classes[3].AddStudent(first_students[4]);
            first_classes[3].AddTeacher(first_teachers[1]);

            first_roooms[0].AddClass(first_classes[0]);
            first_roooms[0].AddClass(first_classes[1]);
            first_roooms[0].AddClass(first_classes[2]);
            first_roooms[0].AddClass(first_classes[3]);
            first_roooms[1].AddClass(first_classes[2]);
            first_roooms[1].AddClass(first_classes[3]);
            first_roooms[2].AddClass(first_classes[1]);
            first_roooms[3].AddClass(first_classes[1]);
            first_roooms[3].AddClass(first_classes[2]);
            first_roooms[4].AddClass(first_classes[0]);
            first_roooms[4].AddClass(first_classes[1]);
            first_roooms[4].AddClass(first_classes[2]);
            first_roooms[5].AddClass(first_classes[0]);
            first_roooms[6].AddClass(first_classes[3]);

            Objects first = new Objects(first_roooms, first_classes, first_teachers, first_students);
            return first;
        }
        public static Hashmap ConstructSecond()
        {
            Hashmap.Room[] second_roooms = new Hashmap.Room[7];
            Hashmap.Class[] second_classes = new Hashmap.Class[4];
            Hashmap.Student[] second_students = new Hashmap.Student[5];
            Hashmap.Teacher[] second_teachers = new Hashmap.Teacher[5];
            second_roooms[0] = new Hashmap.Room(107, Type.lecture);
            second_roooms[1] = new Hashmap.Room(204, Type.tutorials);
            second_roooms[2] = new Hashmap.Room(21, Type.lecture);
            second_roooms[3] = new Hashmap.Room(123, Type.laboratory);
            second_roooms[4] = new Hashmap.Room(404, Type.lecture);
            second_roooms[5] = new Hashmap.Room(504, Type.tutorials);
            second_roooms[6] = new Hashmap.Room(73, Type.laboratory);

            second_classes[0] = new Hashmap.Class("Diabolical Mathematics 2", "MD2", 2);
            second_classes[1] = new Hashmap.Class("Routers Descriptions", "RD", 1);
            second_classes[2] = new Hashmap.Class("Introduction to cables", "WDK", 5);
            second_classes[3] = new Hashmap.Class("Diabolical Mathematics 2", "MD2", 2);

            second_teachers[0] = new Hashmap.Teacher(new string[] { "Tomas" }, "Cherrmann", Rank.MiB, "P1");
            second_teachers[1] = new Hashmap.Teacher(new string[] { "Jon" }, "Tron", Rank.TiB, "P2");
            second_teachers[2] = new Hashmap.Teacher(new string[] { "William", "Joseph" }, "Blazkowicz", Rank.GiB, "P3");
            second_teachers[3] = new Hashmap.Teacher(new string[] { "Arkadiusz", "Amadeusz" }, "Kamiński", Rank.KiB, "P4");
            second_teachers[4] = new Hashmap.Teacher(new string[] { "Cooking" }, "Mama", Rank.GiB, "P5");

            second_students[0] = new Hashmap.Student(new string[] { "Robert" }, "Kielbica", 3, "S1");
            second_students[1] = new Hashmap.Student(new string[] { "Archibald", "Agapios" }, "Linux", 7, "S2");
            second_students[2] = new Hashmap.Student(new string[] { "Angrboða" }, "Kára", 1, "S3");
            second_students[3] = new Hashmap.Student(new string[] { "Olympos" }, "Andronikos", 5, "S4");
            second_students[4] = new Hashmap.Student(new string[] { "Mac", "Rhymes" }, "Pickuppicker", 6, "S5");

            second_teachers[0].AddClass(second_classes[3]);
            second_teachers[1].AddClass(second_classes[0]);
            second_teachers[2].AddClass(second_classes[1]);
            second_teachers[2].AddClass(second_classes[2]);
            second_teachers[3].AddClass(second_classes[2]);
            second_teachers[4].AddClass(second_classes[3]);

            second_students[0].AddClass(second_classes[0]);
            second_students[0].AddClass(second_classes[2]);
            second_students[1].AddClass(second_classes[0]);
            second_students[1].AddClass(second_classes[2]);
            second_students[1].AddClass(second_classes[3]);
            second_students[2].AddClass(second_classes[1]);
            second_students[2].AddClass(second_classes[2]);
            second_students[3].AddClass(second_classes[1]);
            second_students[3].AddClass(second_classes[2]);
            second_students[3].AddClass(second_classes[3]);
            second_students[4].AddClass(second_classes[0]);
            second_students[4].AddClass(second_classes[2]);
            second_students[4].AddClass(second_classes[3]);

            second_classes[0].AddStudent(second_students[0]);
            second_classes[0].AddStudent(second_students[1]);
            second_classes[0].AddStudent(second_students[4]);
            second_classes[0].AddTeacher(second_teachers[1]);
            second_classes[1].AddStudent(second_students[2]);
            second_classes[1].AddStudent(second_students[3]);
            second_classes[1].AddTeacher(second_teachers[2]);
            second_classes[2].AddStudent(second_students[0]);
            second_classes[2].AddStudent(second_students[1]);
            second_classes[2].AddStudent(second_students[2]);
            second_classes[2].AddStudent(second_students[3]);
            second_classes[2].AddStudent(second_students[4]);
            second_classes[2].AddTeacher(second_teachers[2]);
            second_classes[2].AddTeacher(second_teachers[3]);
            second_classes[3].AddStudent(second_students[0]);
            second_classes[3].AddStudent(second_students[1]);
            second_classes[3].AddStudent(second_students[4]);
            second_classes[3].AddTeacher(second_teachers[1]);

            second_roooms[0].AddClass(second_classes[0]);
            second_roooms[0].AddClass(second_classes[1]);
            second_roooms[0].AddClass(second_classes[2]);
            second_roooms[0].AddClass(second_classes[3]);
            second_roooms[1].AddClass(second_classes[2]);
            second_roooms[1].AddClass(second_classes[3]);
            second_roooms[2].AddClass(second_classes[1]);
            second_roooms[3].AddClass(second_classes[1]);
            second_roooms[3].AddClass(second_classes[2]);
            second_roooms[4].AddClass(second_classes[0]);
            second_roooms[4].AddClass(second_classes[1]);
            second_roooms[4].AddClass(second_classes[2]);
            second_roooms[5].AddClass(second_classes[0]);
            second_roooms[6].AddClass(second_classes[3]);
            Hashmap second = new Hashmap(second_roooms, second_classes, second_teachers, second_students);
            return second;
        }
        public static Stacks ConstructThird()
        {
            Stacks third = new Stacks();
            //rooms
            third.AddRoom(107, Type.lecture, new string[] { "MD2", "RD", "WDK", "AC3" });
            third.AddRoom(204, Type.tutorials, new string[] { "WDK", "AC3" });
            third.AddRoom(21, Type.lecture, new string[] { "RD" });
            third.AddRoom(123, Type.laboratory, new string[] { "RD", "WDK" });
            third.AddRoom(404, Type.lecture, new string[] { "MD2", "WDK", "RD" });
            third.AddRoom(504, Type.tutorials, new string[] { "MD2" });
            third.AddRoom(73, Type.laboratory, new string[] { "AC3" });
            //classes
            third.AddClass("Diabolical Mathematics 2", "MD2", 2,
                new string[] { "P2" }, new string[] { "S1", "S2", "S5" });
            third.AddClass("Routers Descriptions", "RD", 1,
                new string[] { "P3" }, new string[] { "S3", "S4" });
            third.AddClass("Introduction to cables", "WDK", 5,
                new string[] { "P4", "P3" }, new string[] { "S1", "S2", "S3", "S4", "S5" });
            third.AddClass("Diabolical Mathematics 2", "MD2", 2, new string[] { "P5", "P1" }, new string[] { "S2", "S4", "S5" });
            //teachers
            third.AddTeacher(new string[] { "Tomas" }, "Cherrmann", Rank.MiB,
                "P1", new string[] { "AC3" });
            third.AddTeacher(new string[] { "Jon" }, "Tron", Rank.TiB,
                "P2", new string[] { "MD2" });
            third.AddTeacher(new string[] { "William", "Joseph" }, "Blazkowicz", Rank.GiB,
                "P3", new string[] { "RD", "WDK" });
            third.AddTeacher(new string[] { "Arkadiusz", "Amadeusz" }, "Kamiński", Rank.KiB,
                "P4", new string[] { "WDK" });
            third.AddTeacher(new string[] { "Cooking" }, "Mama", Rank.GiB,
                "P5", new string[] { "AC3" });
            //students
            third.AddStudent(new string[] { "Robert" }, "Kielbica", 3,
                "S1", new string[] { "MD2", "WDK" });
            third.AddStudent(new string[] { "Archibald", "Agapios" }, "Linux", 7,
                "S2", new string[] { "MD2", "WDK", "AC3" });
            third.AddStudent(new string[] { "Angrboða" }, "Kára", 1,
                "S3", new string[] { "RD", "WDK" });
            third.AddStudent(new string[] { "Olympos" }, "Andronikos", 5,
                "S4", new string[] { "RD", "WDK", "AC3" });
            third.AddStudent(new string[] { "Mac", "Rhymes" }, "Pickuppicker", 6,
                "S5", new string[] { "MD2", "WDK", "AC3" });
            return third;
        }
    }
}
