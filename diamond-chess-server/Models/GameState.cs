namespace diamond_chess_server.Models
{
  public struct GameState
  {
    public MatchHistory? Match { get; set; }
    public List<Piece>? Pieces { get; set; }
  }
}
