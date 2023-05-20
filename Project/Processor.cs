using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class Processor
    {
        private readonly CommandFactory _commandFactory;
        public Processor()
        {
            _commandFactory = new();
            CommandFactory.argumentParser.AddOrIgnore("students",Program.first.Students);
            CommandFactory.argumentParser.AddOrIgnore("teachers", Program.first.Teachers);
            CommandFactory.argumentParser.AddOrIgnore("rooms", Program.first.Rooms);
            CommandFactory.argumentParser.AddOrIgnore("classes", Program.first.Classes);
        }
        public void Process(string arg)
        {
            var command = _commandFactory.CreateCommand(arg);
            command.Execute();
        }
    }
}
