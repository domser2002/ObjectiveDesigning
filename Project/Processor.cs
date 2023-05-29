using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class Processor
    {
        public static Queue<IMyCommand> commands_queue=new();
        public Processor()
        {
            CommandFactory.emptytypes.AddOrIgnore("students", new Student());
            CommandFactory.emptytypes.AddOrIgnore("teachers", new Teacher());
            CommandFactory.emptytypes.AddOrIgnore("rooms", new Room());
            CommandFactory.emptytypes.AddOrIgnore("classes", new Class());
        }
        public static void Process(string arg)
        {
            var command = CommandFactory.CreateCommand(arg);
            if(command is not null)
                commands_queue.Enqueue(command);
        }
    }
}
