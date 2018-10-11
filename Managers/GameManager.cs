using System;
using ManaMist.Controllers;
using ManaMist.Processors;
using ManaMist.Utility;

namespace ManaMist.Managers
{
    public class GameManager
    {
        private Player playerOne;

        private Player playerTwo;

        private Player activePlayer;

        private MapController mapController;

        public GameManager(TurnController turnController, MapController mapController)
        {
            playerOne = new Player(turnController);
            playerTwo = new Player(turnController);
            activePlayer = playerOne;

            this.mapController = mapController;

            turnController.OnTurnStart += setActivePlayer;
        }

        private void setActivePlayer(object sender, TurnEventArgs args)
        {
            if (args.player == 1)
            {
                activePlayer = playerOne;
            }
            else
            {
                activePlayer = playerTwo;
            }
        }

        public void DoCommand(Command command)
        {
            Console.WriteLine(activePlayer.id + " is doing command: " + command.ToString());
        }
    }
}