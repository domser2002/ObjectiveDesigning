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
    }
    public interface IRoom
    {
        public int Number { get; }
        public type _Type { get; }
        public List<IClass> Classes { get; }
    }
    public interface IClass
    {
        public string Name { get; }
        public string Code { get; }
        public int Duration { get; }
        public List<ITeacher> Teachers { get; }
        public List<IStudent> Students { get; }

    }
    public interface ITeacher
    {
        public List<string> Names { get; }
        public string Surname { get; }
        public rank _Rank { get; }
        public string Code { get; }
        public List<IClass> Classes { get; }
    }
    public interface IStudent
    {
        public List<string> Names { get; }
        public string Surname { get; }
        public int Semester { get; }
        public string Code { get; }
        public List<IClass> Classes { get; }
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
    public interface IMyCommand
    {
        string CommandName { get; }
        void Execute();
    }
}
