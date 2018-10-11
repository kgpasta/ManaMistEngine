using System;
using ManaMist.Managers;
using ManaMist.Utility;

namespace ManaMist.Processors
{
    public class CommandProcessor
    {

        private GameManager gameManager;

        public CommandProcessor(GameManager gameManager)
        {
            this.gameManager = gameManager;
        }

        public void process(Command command)
        {
            gameManager.DoCommand(command);
        }
    }
}