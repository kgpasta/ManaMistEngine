namespace ManaMist.Models
{
    public abstract class Building : Entity
    {
        public int buildTurns { get; set; }

        public Building(Cost cost, int buildTurns) : base(cost)
        {
            this.buildTurns = buildTurns;
        }
    }
}