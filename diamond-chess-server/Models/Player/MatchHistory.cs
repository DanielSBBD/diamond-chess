namespace diamond_chess_server.Models
{
    [Serializable]
    public sealed class MatchHistory
    {
        public int Id { get; set; }

        public Player White { get; set; }

        public Player Black { get; set; }

        public int Outcome { get; set; }

        public TimeSpan Duration { get; set; }
    }
}
