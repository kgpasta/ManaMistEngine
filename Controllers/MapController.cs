using System;
using System.IO.File;
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
            //SetupMap("filename");
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

        private void SetupMap(string mapFilePath)
        {
            int count = 0;
            string[] allMapText = ReadAllText(mapFilePath).Split(',');

            for (int i = 0; i < MAP_DIMENSION; i++)
            {
                for (int j = 0; j < MAP_DIMENSION; j++)
                {
                    Coordinate coordinate = new Coordinate(i, j);

                    coordinateToMapTile[coordinate] = StringToMapTile(allMapText[count]);

                    count++;
                }
            }
        }

        private MapTile StringToMapTile(string str)
        {
            Terrain terrain = Terrain.NONE;
            Resource resource = Resource.NONE;

            char[] charArr = str.ToCharArray();

            Terrain terrain = CharToTerrain(charArr[0]);

            if (charArr.Length > 1)
            {
                Resource resource = StringToResource(charArr.Length > 2 ? charArr[1] + charArr[2] : charArr[1]);
            }

            return new MapTile(terrain, resource);
        }

        private Resource StringToResource(string str)
        {
            Resource resource = Resource.NONE;

            switch (str)
            {
                case "F":
                    resource = Resource.FOOD;
                    break;

                case "Ma":
                    resource = Resource.MANA;
                    break;

                case "Me":
                    resource = Resource.METAL;
                    break;
            }

            return resource;
        }

        private Terrain CharToTerrain(char character)
        {
            Terrain terrain = Terrain.NONE;

            switch (character)
            {
                case 'G':
                    terrain = Terrain.GRASS;
                    break;

                case 'H':
                    terrain = Terrain.HILL;
                    break;

                case 'F':
                    terrain = Terrain.FOREST;
                    break;

                case 'M':
                    terrain = Terrain.MOUNTAIN;
                    break;

                case 'W':
                    terrain = Terrain.WATER;
                    break;

                case 'S':
                    terrain = Terrain.SWAMP;
                    break;

                case 'D':
                    terrain = Terrain.DESERT;
                    break;
            }

            return terrain;
        }

    }
}