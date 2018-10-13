using ManaMist.Utility;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ManaMist.Models
{
    public abstract class Entity
    {
        public string id { get; set; }

        public string name { get; set; }

        public Cost cost { get; set; }

        public Entity(string name, Cost cost)
        {
            this.id = System.Guid.NewGuid().ToString();
            this.name = name;
            this.cost = cost;
        }

        public abstract bool CanMove(Coordinate start, Coordinate end);
        public abstract bool CanBuild(Coordinate currentCoordinate, Coordinate buildingCoordinate);

        public override string ToString()
        {
            return JsonConvert.SerializeObject(
           this, Formatting.Indented,
           new JsonConverter[] { new StringEnumConverter() });
        }
    }
}