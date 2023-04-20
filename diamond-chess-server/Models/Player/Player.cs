namespace diamond_chess_server.Models
{
  [Serializable]
  public sealed class Player
  {
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }

    public int numWins {get; set;}
    public int numDraws {get; set;}
    public int numLosses {get; set;}

    public LoginDetails? playerLogin { get; set; }
  }
}
