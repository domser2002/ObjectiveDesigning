using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Project.Hashmap;

namespace Project
{
    static class Extensions
    {
        public static void Display(this IRoom room)
        {
            Console.WriteLine();
            Console.WriteLine("Number: " + room.Number);
            Console.WriteLine("Type: " + room._Type);
        }
        public static void Display(this ITeacher teacher)
        {
            Console.WriteLine();
            string tmp = "";
            foreach (string name in teacher.Names)
            {
                tmp += name + " ";
            }
            Console.WriteLine("Names: " + tmp);
            Console.WriteLine("Surname: " + teacher.Surname);
            Console.WriteLine("Rank: " + teacher._Rank);
            Console.WriteLine("Code: " + teacher.Code);
        }
        public static void Display(this IClass c)
        {
            Console.WriteLine();
            Console.WriteLine("Name: " + c.Name);
            Console.WriteLine("Code: " + c.Code);
            Console.WriteLine("Duration: " + c.Duration);
        }
        public static void Display(this IStudent student)
        {
            Console.WriteLine();
            string tmp = "";
            foreach (string name in student.Names)
            {
                tmp += name + " ";
            }
            Console.WriteLine("Names: " + tmp);
            Console.WriteLine("Surname: " + student.Surname);
            Console.WriteLine("Semester: " + student.Semester);
            Console.WriteLine("Code: " + student.Code);
        }
        public static void Display(this IRepresentation representation)
        {
            Console.WriteLine();
            Console.WriteLine("Rooms:");
            foreach(IRoom room in representation.rooms)
            {
                room.Display();
            }
            Console.WriteLine();
            Console.WriteLine("Classes:");
            foreach(IClass c in representation.classes)
            {
                c.Display();
            }
            Console.WriteLine();
            Console.WriteLine("Students:");
            foreach(IStudent student in representation.students)
            {
                student.Display();
            }
            Console.WriteLine();
            Console.WriteLine("Teachers:");
            foreach(ITeacher teacher in representation.teachers)
            {
                teacher.Display();
            }
        }
        public static void Select(this IRepresentation representation)
        {
            foreach (IClass c in representation.classes)
            {
                bool student = false;
                bool teacher = false;
                foreach (IStudent s in c.Students)
                {
                    if (s.Names.Count > 1)
                    {
                        student = true;
                        break;
                    }
                }
                if (!student) { continue; }
                foreach (ITeacher t in c.Teachers)
                {
                    if (t.Names.Count > 1)
                    {
                        teacher = true;
                        break;
                    }
                }
                if (!teacher) { continue; }
                c.Display();
            }
        }
        public static void AddOrIgnore(this Dictionary<int, string> dictionary, int key, string value)
        {
            if (!dictionary.ContainsKey(key))
                dictionary.Add(key, value);
        }
        public static IRepresentation? Find(this IMyCollection collection,Func<IRepresentation,
            bool> pred,bool frombeginning)
        {
            IMyiterator iter;
            if(frombeginning)
                iter=collection.GetForwardIterator();
            else
                iter=collection.GetBackwardIterator();
            while(iter is not null && iter.Current is not null)
            {
                if(pred(iter.Current)) return iter.Current;
                if (!iter.MoveNext()) break;
            }
            return null;
        }
        public static void Print(this IMyCollection collection, Func<IRepresentation,
            bool> pred, bool frombeginning)
        {
            IMyiterator iter;
            if (frombeginning)
                iter = collection.GetForwardIterator();
            else
                iter = collection.GetBackwardIterator();
            while (iter is not null && iter.Current is not null)
            {
                if (pred(iter.Current))
                    iter.Current.Display();
                if (!iter.MoveNext()) break;
            }
        }
        public static IRepresentation? Find(IMyiterator iter, Func<IRepresentation, bool> pred)
        {
            while (iter is not null && iter.Current is not null)
            {
                if (pred(iter.Current)) return iter.Current;
                if (!iter.MoveNext()) break;
            }
            return null;
        }
        public static void ForEach(IMyiterator iterator,Action<IRepresentation?> func)
        {
            IMyiterator tmp=iterator;
            while (tmp is not null && tmp.Current is not null)
            {
                func(tmp.Current);
                if (!tmp.MoveNext()) break;
            }
        }
        public static int CountIf(IMyiterator iterator, Func<IRepresentation,
            bool> pred)
        {
            int count = 0;
            while(iterator is not null && iterator.Current is not null)
            {
                if(pred(iterator.Current)) count++; 
                if(!iterator.MoveNext()) break; 
            }
            return count;
        }
    }
}
