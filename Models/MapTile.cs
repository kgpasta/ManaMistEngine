using ManaMist.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManaMist.Models
{
    class MapTile
    {
        public Terrain terrain { get; set; }
        public Resource resource { get; set; }
        public List<Entity> entities { get; set; }
        

        public MapTile(Terrain terrain)
        {
            this.terrain = terrain;
            this.entities = new List<Entity>();
        }
    }
}
