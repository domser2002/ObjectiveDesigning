using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class NotFoundCommand : IMyCommand
    {
        public string CommandName { get; set; }
        public NotFoundCommand(string name) 
        {
            this.CommandName = name;
        }
        public void Execute()
        {
            Console.WriteLine("Couldn't find command: " + CommandName);
        }
    }
    public class find : IMyCommand
    {
        public string CommandName
        {
            get
            { return "find"; }
        }
        public void Execute()
        {

        }
    }
    public class list : IMyCommand
    {
        public string CommandName
        {
            get
            { return "list"; }
        }
        public void Execute()
        {

        }
    }
    public class exit : IMyCommand
    {
        public string CommandName
        {
            get
            { return "exit"; }
        }
        public void Execute()
        {
            System.Environment.Exit(0);
        }
    }
}
