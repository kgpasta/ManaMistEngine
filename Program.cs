using System;
using ManaMist.Processors;
using ManaMist.Utility;

namespace ManaMistEngine
{
    class Program
    {
        static void Main(string[] args)
        {
            CommandProcessor commandProcessor = new CommandProcessor();

            while (true)
            {
                string input = Console.In.ReadLine();

                Command command = stringToCommand(input);
                commandProcessor.process(command);

            }
        }

        public static Command stringToCommand(string input)
        {
            return (Command)Enum.Parse(typeof(Command), input, true);
        }
    }
}
