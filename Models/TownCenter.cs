namespace ManaMist.Models
{
    public class TownCenter : Building
    {
        public TownCenter(string id) : base(id, "TownCenter", new Cost(), 10)
        {
        }
    }
}