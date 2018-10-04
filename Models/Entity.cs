namespace ManaMist.Models
{
    public abstract class Entity
    {
        public string id { get; set; }

        public Cost cost { get; set; }

        public Entity(Cost cost)
        {
            this.id = System.Guid.NewGuid().ToString();
            this.cost = cost;
        }
    }
}