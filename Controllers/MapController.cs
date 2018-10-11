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
        private Dictionary<Coordinate, List<Entity>> coordinateToEntities { get; set; }

        private Dictionary<string, Coordinate> entityIdToCoordinate { get; set; }

        private const int MAP_DIMENSION = 100;


        public MapController() { }

        public void addToMap(Coordinate coordinate, Entity entity)
        {
            if (!coordinateToEntities.ContainsKey(coordinate))
            {
                coordinateToEntities[coordinate] = new List<Entity>();
            }

            coordinateToEntities[coordinate].Add(entity);

            entityIdToCoordinate[entity.id] = coordinate;
        }

        public Coordinate getPositionOfEntity(Entity entity)
        {
            if (entityIdToCoordinate.ContainsKey(entity.id))
            {
                return entityIdToCoordinate[entity.id];
            }

            return null;
        }

        public List<Entity> getEntitiesAtCoordinate(Coordinate coordinate)
        {
            if (coordinateToEntities.ContainsKey(coordinate))
            {
                return coordinateToEntities[coordinate];
            }

            return new List<Entity>();
        }

        public void removeFromMap(Entity entity)
        {
            if (entityIdToCoordinate.ContainsKey(entity.id))
            {
                Coordinate current = entityIdToCoordinate[entity.id];

                if (coordinateToEntities.ContainsKey(current))
                {
                    coordinateToEntities[current].Remove(entity);
                }

                entityIdToCoordinate.Remove(entity.id);
            }
        }

        public void moveEntity(Coordinate coordinate, Entity entity)
        {
            if (getPositionOfEntity(entity) != null)
            {
                removeFromMap(entity);
                addToMap(coordinate, entity);
            }
        }

    }
}