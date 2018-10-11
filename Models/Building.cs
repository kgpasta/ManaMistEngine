namespace ManaMist.Models
{
    public abstract class Building : Entity
    {
        public int buildTurns { get; set; }

        public Building(string id, string name, Cost cost, int buildTurns) : base(id, name, cost)
        {
            this.buildTurns = buildTurns;
        }
    }
}