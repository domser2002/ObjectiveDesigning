using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class Processor
    {
        public static Queue<IMyCommand> commands=new();
        private readonly CommandFactory _commandFactory;
        public Processor()
        {
            _commandFactory = new();
        }
        public void Process(string arg)
        {
            var command = _commandFactory.CreateCommand(arg);
            if(command is not null)
                commands.Enqueue(command);
        }
    }
}
