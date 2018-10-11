using System;
using ManaMist.Commands;
using ManaMist.Controllers;
using ManaMist.Models;
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
            playerOne = new Player(0, turnController);
            SeedPlayer(playerOne, 0);
            playerTwo = new Player(1, turnController);
            SeedPlayer(playerTwo, 10);
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
            Console.WriteLine(activePlayer.id + " is doing command: " + command.type.ToString());
        }

        private void SeedPlayer(Player player, int offset)
        {
            Coordinate townCenterCoordinate = new Coordinate(offset, offset);
            TownCenter townCenter = new TownCenter();
            player.AddEntity(townCenter);
            mapController.AddToMap(townCenterCoordinate, townCenter);

            Coordinate workerCoordinate = new Coordinate(offset + 1, offset + 1);
            Worker worker = new Worker();
            player.AddEntity(worker);
            mapController.AddToMap(workerCoordinate, worker);
        }
    }
}