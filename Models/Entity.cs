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

        public Entity(string id, string name, Cost cost)
        {
            this.id = id;
            this.name = name;
            this.cost = cost;
        }

        public abstract bool CanMove(Coordinate start, Coordinate end);

        public override string ToString()
        {
            return JsonConvert.SerializeObject(
           this, Formatting.Indented,
           new JsonConverter[] { new StringEnumConverter() });
        }
    }
}