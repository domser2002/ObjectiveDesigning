﻿using System;
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
            Objects first = new Objects();
            Objects.Room[] first_roooms = new Objects.Room[7];
            Objects.Class[] first_classes = new Objects.Class[4];
            Objects.Student[] first_students = new Objects.Student[5];
            Objects.Teacher[] first_teachers = new Objects.Teacher[5];
            first_roooms[0] = new Objects.Room(107, type.lecture);
            first_roooms[1] = new Objects.Room(204, type.tutorials);
            first_roooms[2] = new Objects.Room(21, type.lecture);
            first_roooms[3] = new Objects.Room(123, type.laboratory);
            first_roooms[4] = new Objects.Room(404, type.lecture);
            first_roooms[5] = new Objects.Room(504, type.tutorials);
            first_roooms[6] = new Objects.Room(73, type.laboratory);

            first_classes[0] = new Objects.Class("Diabolical Mathematics 2", "MD2", 2);
            first_classes[1] = new Objects.Class("Routers Descriptions", "RD", 1);
            first_classes[2] = new Objects.Class("Introduction to cables", "WDK", 5);
            first_classes[3] = new Objects.Class("Diabolical Mathematics 2", "MD2", 2);

            first_teachers[0] = new Objects.Teacher(new string[] { "Tomas" }, "Cherrmann", rank.MiB, "P1");
            first_teachers[1] = new Objects.Teacher(new string[] { "Jon" }, "Tron", rank.TiB, "P2");
            first_teachers[2] = new Objects.Teacher(new string[] { "William", "Joseph" }, "Blazkowicz", rank.GiB, "P3");
            first_teachers[3] = new Objects.Teacher(new string[] { "Arkadiusz", "Amadeusz" }, "Kamiński", rank.KiB, "P4");
            first_teachers[4] = new Objects.Teacher(new string[] { "Cooking" }, "Mama", rank.GiB, "P5");

            first_students[0] = new Objects.Student(new string[] { "Robert" }, "Kielbica", 3, "S1");
            first_students[1] = new Objects.Student(new string[] { "Archibald", "Agapios" }, "Linux", 7, "S2");
            first_students[2] = new Objects.Student(new string[] { "Angrboða" }, "Kára", 1, "S3");
            first_students[3] = new Objects.Student(new string[] { "Olympos" }, "Andronikos", 5, "S4");
            first_students[4] = new Objects.Student(new string[] { "Mac", "Rhymes" }, "Pickuppicker", 6, "S5");

            first_teachers[0].AddClass(first_classes[3]);
            first_teachers[1].AddClass(first_classes[0]);
            first_teachers[2].AddClass(first_classes[1]);
            first_teachers[2].AddClass(first_classes[2]);
            first_teachers[3].AddClass(first_classes[2]);
            first_teachers[4].AddClass(first_classes[3]);

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

            first.rooms = first_roooms.ToList();
            first.teachers = first_teachers.ToList();
            first.students = first_students.ToList();
            first.classes = first_classes.ToList();

            //second representation
            Hashmap.Room[] second_roooms = new Hashmap.Room[7];
            Hashmap.Class[] second_classes = new Hashmap.Class[4];
            Hashmap.Student[] second_students = new Hashmap.Student[5];
            Hashmap.Teacher[] second_teachers = new Hashmap.Teacher[5];
            second_roooms[0] = new Hashmap.Room(107, type.lecture);
            second_roooms[1] = new Hashmap.Room(204, type.tutorials);
            second_roooms[2] = new Hashmap.Room(21, type.lecture);
            second_roooms[3] = new Hashmap.Room(123, type.laboratory);
            second_roooms[4] = new Hashmap.Room(404, type.lecture);
            second_roooms[5] = new Hashmap.Room(504, type.tutorials);
            second_roooms[6] = new Hashmap.Room(73, type.laboratory);

            second_classes[0] = new Hashmap.Class("Diabolical Mathematics 2", "MD2", 2);
            second_classes[1] = new Hashmap.Class("Routers Descriptions", "RD", 1);
            second_classes[2] = new Hashmap.Class("Introduction to cables", "WDK", 5);
            second_classes[3] = new Hashmap.Class("Diabolical Mathematics 2", "MD2", 2);

            second_teachers[0] = new Hashmap.Teacher(new string[] { "Tomas" }, "Cherrmann", rank.MiB, "P1");
            second_teachers[1] = new Hashmap.Teacher(new string[] { "Jon" }, "Tron", rank.TiB, "P2");
            second_teachers[2] = new Hashmap.Teacher(new string[] { "William", "Joseph" }, "Blazkowicz", rank.GiB, "P3");
            second_teachers[3] = new Hashmap.Teacher(new string[] { "Arkadiusz", "Amadeusz" }, "Kamiński", rank.KiB, "P4");
            second_teachers[4] = new Hashmap.Teacher(new string[] { "Cooking" }, "Mama", rank.GiB, "P5");

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

            //test
            foreach(Objects.Room r in first_roooms)
            {
                Console.WriteLine(r);
            }
            foreach (Hashmap.Room r in second_roooms)
            {
                Console.WriteLine(r);
            }
        }
    }
}
