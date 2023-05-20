using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Project
{
    public class CommandFactory
    {
        public static Dictionary<string, IObject[]> argumentParser = new();
        //public static Dictionary<string,string> fieldinclass=new();
        private readonly IEnumerable<IMyCommand> commands = new IMyCommand[]
        {
            new Find(),new List(),new Exit(), new Add()
        };
        public IMyCommand CreateCommand(string arg)
        {
            string[] args = arg.Split(' ');
            string commandName = args[0];
            var tmp = commands.FirstOrDefault(c => c.CommandName == commandName);
            var command=tmp ?? new NotFoundCommand();
            command.Arguments = args;
            return command;
        }
    }

}
