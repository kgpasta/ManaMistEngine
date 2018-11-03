using System;
using ManaMist.Controllers;
using ManaMist.Managers;
using ManaMist.Processors;
using ManaMist.Commands;
using ManaMist.Utility;
using ManaMist.Models;

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

                string[] inputs = input.Split();

                CommandType? commandType = StringToCommandType(inputs[0]);
                if (commandType.HasValue)
                {
                    Command command = ArrayToCommand(commandType.Value, inputs);

                    commandProcessor.Process(command);
                }
            }
        }

        public static CommandType? StringToCommandType(string input)
        {
            object result;
            Enum.TryParse(typeof(CommandType), input, true, out result);
            if (result == null)
            {
                Console.WriteLine("Could not parse command, try 'describe', 'select', 'move', or 'build'");
                return null;
            }

            return (CommandType)result;
        }

        public static Command ArrayToCommand(CommandType commandType, string[] inputs)
        {
            Command command = null;
            switch (commandType)
            {
                case CommandType.DESCRIBE:
                    if (inputs[1].ToLower() == "all")
                    {
                        command = new DescribeCommand(1);
                    }
                    else if (inputs.Length > 2)
                    {
                        command = new DescribeCommand(1, new Coordinate(Int32.Parse(inputs[1]), Int32.Parse(inputs[2])));
                    }
                    else
                    {
                        command = new DescribeCommand(1, inputs[1]);
                    }

                    break;
                case CommandType.SELECT:
                    command = new SelectCommand(1, inputs[1]);
                    break;
                case CommandType.MOVE:
                    command = new MoveCommand(1, new Coordinate(Int32.Parse(inputs[1]), Int32.Parse(inputs[2])));
                    break;
                case CommandType.BUILD:
                    command = new BuildCommand(1, new Coordinate(Int32.Parse(inputs[1]), Int32.Parse(inputs[2])), new Mine());
                    break;
                case CommandType.ENDTURN:
                    command = new EndTurnCommand(1);
                    break;
                default:
                    break;
            }

            return command;
        }
    }
}
