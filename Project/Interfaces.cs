using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public interface IRepresentation
    {
        public IRoom[] Rooms { get; }
        public IClass[] Classes { get; }
        public ITeacher[] Teachers { get; }
        public IStudent[] Students { get; }
    }
    public interface IRoom : IObject
    {
        public int Number { get; }
        public type _Type { get; }
        public List<IClass> Classes { get; }
    }
    public interface IClass : IObject
    {
        public string Name { get; }
        public string Code { get; }
        public int Duration { get; }
        public List<ITeacher> Teachers { get; }
        public List<IStudent> Students { get; }

    }
    public interface ITeacher : IObject
    {
        public List<string> Names { get; }
        public string Surname { get; }
        public rank _Rank { get; }
        public string Code { get; }
        public List<IClass> Classes { get; }
    }
    public interface IStudent : IObject
    {
        public List<string> Names { get; }
        public string Surname { get; }
        public int Semester { get; }
        public string Code { get; }
        public List<IClass> Classes { get; }
    }
    public interface IObject
    {
        public void Display();
    }
    public interface IMyCollection
    {
        public void AddObject(IObject obj);
        public bool RemoveObject(IObject obj);
        public IMyiterator GetForwardIterator();
        public IMyiterator GetBackwardIterator();
    }
    public interface IMyiterator
    {
        public IObject? Current { get; set; }
        public bool MoveNext();
    }
    public interface IMyCommand
    {
        string[] Arguments { get; set; }
        string? CommandName { get; }
        void Execute();
    }
}
