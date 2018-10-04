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
    }
}