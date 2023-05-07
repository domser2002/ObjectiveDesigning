using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Project
{
    public class Processor
    {
        private CommandFactory _commandFactory;
        public Processor()
        {
            _commandFactory = new();
        }
        public void Process(string arg)
        {
            var command=_commandFactory.CreateCommand(arg);
            command.Execute();
        }
    }
    public class CommandFactory
    {
        private readonly IEnumerable<IMyCommand> commands = new IMyCommand[]
        {
            new find(),new list(),new exit()
        };
        public IMyCommand CreateCommand(string arg)
        {
            string[] args = arg.Split(' ');
            string commandName = args[0];
            var tmp = commands.FirstOrDefault(c => c.CommandName == commandName);
            var command=tmp ?? new NotFoundCommand { CommandName=commandName};
            return command;
        }
    }

}
