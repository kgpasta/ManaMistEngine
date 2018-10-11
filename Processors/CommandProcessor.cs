using System;
using ManaMist.Utility;

namespace ManaMist.Processors
{
    public class CommandProcessor
    {
        public void process(Command command)
        {
            Console.WriteLine(command.ToString());
        }
    }
}