using System;
using ManaMist.Controllers;
using ManaMist.Managers;
using ManaMist.Processors;
using ManaMist.Commands;

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

            Console.WriteLine("Welcome to the ManaMistEngine. Please input a command:");

            while (true)
            {
                string input = Console.In.ReadLine();

                CommandType? command = StringToCommand(input);
                if(command.HasValue) {
                    //commandProcessor.Process(command.Value);
                }
            }
        }

        public static CommandType? StringToCommand(string input)
        {
            object result;
            Enum.TryParse(typeof (CommandType), input, true, out result);
            if (result == null) {
                Console.WriteLine("Could not parse command, try 'describe', 'select', 'move', or 'build'");
                return null;
            }

            return (CommandType) result;
        }
    }
}
