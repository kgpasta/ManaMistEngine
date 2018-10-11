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
        private Dictionary<Coordinate, List<Entity>> coordinateToEntities { get; set; } = new Dictionary<Coordinate, List<Entity>>();

        private Dictionary<string, Coordinate> entityIdToCoordinate { get; set; } = new Dictionary<string, Coordinate>();

        private const int MAP_DIMENSION = 100;


        public MapController() { }

        public void AddToMap(Coordinate coordinate, Entity entity)
        {
            if (!coordinateToEntities.ContainsKey(coordinate))
            {
                coordinateToEntities[coordinate] = new List<Entity>();
            }

            coordinateToEntities[coordinate].Add(entity);

            entityIdToCoordinate[entity.id] = coordinate;
        }

        public Coordinate GetPositionOfEntity(Entity entity)
        {
            if (entityIdToCoordinate.ContainsKey(entity.id))
            {
                return entityIdToCoordinate[entity.id];
            }

            return null;
        }

        public List<Entity> GetEntitiesAtCoordinate(Coordinate coordinate)
        {
            if (coordinateToEntities.ContainsKey(coordinate))
            {
                return coordinateToEntities[coordinate];
            }

            return new List<Entity>();
        }

        public void RemoveFromMap(Entity entity)
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

        public void MoveEntity(Coordinate coordinate, Entity entity)
        {
            if (GetPositionOfEntity(entity) != null)
            {
                RemoveFromMap(entity);
                AddToMap(coordinate, entity);
            }
        }

    }
}