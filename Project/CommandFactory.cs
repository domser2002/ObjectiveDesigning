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
        public static Dictionary<string, IObject> emptytypes = new();
        private readonly IEnumerable<IMyCommand> commands = new IMyCommand[]
        {
            new Find(),new List(),new Exit(), new Add(), new Queue(),new Edit(),new Delete()
        };
        public CommandFactory() 
        {
            emptytypes.AddOrIgnore("students", new Student());
            emptytypes.AddOrIgnore("teachers", new Teacher());
            emptytypes.AddOrIgnore("rooms", new Room());
            emptytypes.AddOrIgnore("classes", new Class());
        }
        public IMyCommand? CreateCommand(string arg)
        {
            string[] args = arg.Split(' ');
            string commandName = args[0];
            var tmp = commands.FirstOrDefault(c => c.CommandName == commandName);
            var command=tmp ?? new NotFoundCommand();
            command.Arguments = args;
            if(commandName=="queue")
            {
                command.Execute();
                return null;
            }
            return command;
        }
    }

}
