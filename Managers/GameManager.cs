using System;
using System.Collections.Generic;
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
            this.mapController = mapController;

            turnController.OnTurnStart += setActivePlayer;

            playerOne = new Player(0, turnController);
            SeedPlayer(playerOne, 0);
            playerTwo = new Player(1, turnController);
            SeedPlayer(playerTwo, 10);
            activePlayer = playerOne;
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
            switch (command.type)
            {
                case CommandType.DESCRIBE:
                    DescribeCommand describeCommand = (DescribeCommand)command;
                    if (describeCommand.coordinate != null)
                    {
                        List<Entity> entities = mapController.GetEntitiesAtCoordinate(describeCommand.coordinate);

                        foreach (Entity entity in entities)
                        {
                            Console.WriteLine(entity.ToString());
                        }
                    }
                    else if (describeCommand.entity != null)
                    {
                        Coordinate coordinate = mapController.GetPositionOfEntity(describeCommand.entity);
                        if (coordinate != null)
                        {
                            Console.WriteLine(coordinate.ToString());
                        }
                        Entity entity = FindEntity(describeCommand.entity);
                        Console.WriteLine(entity.ToString());

                    }
                    break;
                case CommandType.SELECT:
                    SelectCommand selectCommand = (SelectCommand)command;
                    activePlayer.SelectEntity(selectCommand.id);
                    break;
                case CommandType.MOVE:
                    MoveCommand moveCommand = (MoveCommand)command;
                    Entity moveCommandEntity = GetPlayerById(moveCommand.playerId).selectedEntity;
                    mapController.MoveEntity(moveCommand.coordinate, moveCommandEntity);
                    break;
                default:
                    break;
            }
        }

        private void SeedPlayer(Player player, int offset)
        {
            Coordinate townCenterCoordinate = new Coordinate(offset, offset);
            TownCenter townCenter = new TownCenter("towncenter0-player" + player.id);
            player.AddEntity(townCenter);
            mapController.AddToMap(townCenterCoordinate, townCenter);

            Coordinate workerCoordinate = new Coordinate(offset + 1, offset + 1);
            Worker worker = new Worker("worker0-player" + player.id);
            player.AddEntity(worker);
            mapController.AddToMap(workerCoordinate, worker);
        }

        private Entity FindEntity(string id)
        {
            Entity playerOneEntity = playerOne.GetEntity(id);
            Entity playerTwoEntity = playerTwo.GetEntity(id);

            if (playerOneEntity != null)
            {
                return playerOneEntity;
            }
            else if (playerTwoEntity != null)
            {
                return playerTwoEntity;
            }
            return null;
        }

        private Player GetPlayerById(int playerId)
        {
            return playerId == 1 ? playerOne : playerTwo;
        }
    }
}