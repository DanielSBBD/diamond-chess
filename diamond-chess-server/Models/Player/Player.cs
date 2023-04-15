namespace diamond_chess_server.Models
{
  [Serializable]
  public sealed class Player
  {
    public int Id { get; set; }
    public string Name { get; set; } 
    public string Surname { get; set; }

    public LoginDetails playerLogin { get; set; }
  }
}
