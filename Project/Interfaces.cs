using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public interface IRepresentation
    {
        public IRoom[] rooms { get; }
        public IClass[] classes { get; }
        public ITeacher[] teachers { get; }
        public IStudent[] students { get; }
        public void Display();
        public void Select();
    }
    public interface IRoom
    {
        public int Number { get; }
        public type _Type { get; }
        //public List<Class> Classes { get; }
        //public void AddClass(Class c);
        //public void Display();
    }
    public interface IClass
    {
        //public string Name { get; }
        //public string Code { get; }
        //public int Duration { get; }
        //public List<Teacher> Teachers { get; }
        //public List<Student> Students { get; }
        //public void AddStudent(Student s);
        //public void AddTeacher(Teacher t);
        public void Display();

    }
    public interface ITeacher
    {
        //public List<string> Names { get; }
        //public string Surname { get; }
        //public rank _Rank { get; }
        //public string Code { get; }
        //public List<Class> Classes { get; }
        //public void AddClass(Class c);
        public void Display();

    }
    public interface IStudent
    {
        //public List<string> Names { get; }
        //public string Surname { get; }
        //public int Semester { get; }
        //public string Code { get; }
        //public List<Class> Classes { get; }
        //public void AddClass(Class c);
        public void Display();

    }
    public interface IMyCollection
    {
        public void AddObject(IRepresentation obj);
        public bool RemoveObject(IRepresentation obj);
        public IMyiterator GetForwardIterator();
        public IMyiterator GetBackwardIterator();
    }
    public interface IMyiterator
    {
        public IRepresentation? Current { get; }
        public bool MoveNext();
    }
}
