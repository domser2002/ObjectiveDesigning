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
        public static Stack<IMyCommand> toundo = new();
        public static Stack<IMyCommand> toredo = new();
        public static IMyCommand? CreateCommand(string arg)
        {
            IEnumerable<IMyCommand> commands = new IMyCommand[]
            {
                new Find(),new List(),new Exit(), new Add(), new Edit(),new Delete(), new History()
            };
            string[] args = arg.Split(' ');
            string commandName = args[0];
            if(commandName=="undo")
            {
                if(toundo.Count == 0)
                {
                    Console.WriteLine("No commands to undo!");
                    return null;
                }
                IMyCommand myCommand = toundo.Pop();
                myCommand.UnExecute();
                return null;
            }
            if (commandName == "redo")
            {
                if (toredo.Count == 0)
                {
                    Console.WriteLine("No commands to redo!");
                    return null;
                }
                IMyCommand myCommand = toredo.Pop();
                myCommand.Execute();
                return null;
            }
            var tmp = commands.FirstOrDefault(c => c.CommandName == commandName);
            var command = tmp ?? new NotFoundCommand();
            if (!command.Prepare(args))
            {
                return null;
            }
            command.Execute();
            return command;
        }
    }

}
