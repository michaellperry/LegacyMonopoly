namespace LegacyMonopoly.DataAccess
{
    public class Deed
    {
        public int DeedId { get; set; }

        public Player Player { get; set; }
        public int PlayerId { get; set; }
        public Property Property { get; set; }
        public int PropertyId { get; set; }
    }
}