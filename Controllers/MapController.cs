using System;
using System.Collections;
using System.Collections.Generic;
using ManaMist.Controllers;
using ManaMist.Models;
using ManaMist.Utility;

namespace ManaMist.Controllers
{
    public class MapController
    {
        private Dictionary<Coordinate, MapTile> coordinateToMapTile { get; set; } = new Dictionary<Coordinate, MapTile>();

        private Dictionary<string, Coordinate> entityIdToCoordinate { get; set; } = new Dictionary<string, Coordinate>();

        private const int MAP_DIMENSION = 50;


        public MapController() {
            for(int i = 0; i < MAP_DIMENSION; i++)
            {
                for(int j = 0; j < MAP_DIMENSION; j++)
                {
                    Coordinate coordinate = new Coordinate(i, j);
                    coordinateToMapTile[coordinate] = new MapTile(Terrain.GRASS);
                }
            }
        }

        public void AddToMap(Coordinate coordinate, Entity entity)
        {
            coordinateToMapTile[coordinate].entities.Add(entity);

            entityIdToCoordinate[entity.id] = coordinate;
        }

        public Coordinate GetPositionOfEntity(string id)
        {
            if (entityIdToCoordinate.ContainsKey(id))
            {
                return entityIdToCoordinate[id];
            }

            return null;
        }

        public List<Entity> GetEntitiesAtCoordinate(Coordinate coordinate)
        {
            if (coordinateToMapTile.ContainsKey(coordinate))
            {
                return coordinateToMapTile[coordinate].entities;
            }

            return new List<Entity>();
        }

        public void RemoveFromMap(Entity entity)
        {
            if (entityIdToCoordinate.ContainsKey(entity.id))
            {
                Coordinate current = entityIdToCoordinate[entity.id];

                if (coordinateToMapTile.ContainsKey(current))
                {
                    coordinateToMapTile[current].entities.Remove(entity);
                }

                entityIdToCoordinate.Remove(entity.id);
            }
        }

        public void MoveEntity(Coordinate coordinate, Entity entity)
        {
            if (GetPositionOfEntity(entity.id) != null)
            {
                RemoveFromMap(entity);
                AddToMap(coordinate, entity);
            }
        }

    }
}