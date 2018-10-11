using System;
using ManaMist.Controllers;
using ManaMist.Managers;
using ManaMist.Processors;
using ManaMist.Utility;

namespace ManaMistEngine
{
    class Program
    {
        static void Main(string[] args)
        {
            TurnController turnController = new TurnController();
            MapController mapController = new MapController();
            GameManager gameManager = new GameManager(turnController, mapController);
            CommandProcessor commandProcessor = new CommandProcessor(gameManager);

            while (true)
            {
                string input = Console.In.ReadLine();

                Command? command = stringToCommand(input);
                if(command.HasValue) {
                    commandProcessor.process(command.Value);
                }
            }
        }

        public static Command? stringToCommand(string input)
        {
            object result;
            Enum.TryParse(typeof (Command), input, true, out result);
            if (result == null) {
                Console.WriteLine("Could not parse command, try 'select', 'move', or 'build'");
                return null;
            }

            return (Command) result;
        }
    }
}
