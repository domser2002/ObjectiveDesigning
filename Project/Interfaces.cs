using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

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
        public Type Type { get; }
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
        public Rank Rank { get; }
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
        public Dictionary<string, object> Properties { get; set; }
        public IObject Copy();
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
        [XmlArray("Arguments")]
        string[] Arguments { get; set; }
        [XmlElement("Name")]
        string? CommandName { get; }
        void Execute();
        void UnExecute();
        bool Prepare(string[] args);
        //public new System.Xml.Schema.XmlSchema? GetSchema();
        //public new void ReadXml(System.Xml.XmlReader reader);
        //public new void WriteXml(System.Xml.XmlWriter writer);
    }
    public interface IBuilder
    {
        IObject Result { get; set; }
        void SetProperty(string name, object value);
    }
}
