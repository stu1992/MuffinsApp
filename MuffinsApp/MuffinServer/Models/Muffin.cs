namespace MuffinServer.Models
{
    public class Muffin : IComparable<Muffin>
    {
        public string type { get; set; }

        public int CompareTo(Muffin comparison)
        {
            return this.type.CompareTo(comparison.type);
        }
    }
}