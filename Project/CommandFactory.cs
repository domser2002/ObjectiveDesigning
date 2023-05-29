using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Project
{
    public static class CommandFactory
    {
        public static Dictionary<string, IObject> emptytypes = new();
        public static IMyCommand? CreateCommand(string arg)
        {
            IEnumerable<IMyCommand> commands = new IMyCommand[]
            {
                new Find(),new List(),new Exit(), new Add(), new Queue(),new Edit(),new Delete()
            };
            string[] args = arg.Split(' ');
            string commandName = args[0];
            var tmp = commands.FirstOrDefault(c => c.CommandName == commandName);
            var command = tmp ?? new NotFoundCommand();
            if (!command.Prepare(args))
            {
                return null;
            }
            return (commandName=="queue")?null:command;
        }
    }

}
