//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Input;

//namespace Project
//{
//    public interface ICommand
//    {
//        string CommandName { get; }
//        void Execute();
//    }
//    public class CommandFactory
//    {
//        private readonly IEnumerable<ICommand> commands = new ICommand[]
//        {
//            new Commands.find(),new Commands.list(),new Commands.exit()
//        };
//        public ICommand CreateCommand(string s)
//        {
//            var command=commands.FirstOrDefault(c => c.CommandName == s);
//            return command;
//        }
//    }

//    public static class Builder
//    {
//        public static void Process(this string s)
//        {
//            CommandFactory commandFactory = new CommandFactory();
//            var command = commandFactory.CreateCommand(s);
//        }
//    }
//}
