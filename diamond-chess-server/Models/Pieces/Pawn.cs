public class Pawn : Piece
{
  public Pawn(int startX, int startY) : base(startX, startY) { }

  public override List<Target> GetValidMoves(bool?[,] obstacles)
  {
    List<Target> validMoves = new List<Target>();

    // Can move one space forwards
    if (posX < 7 && posY < 7)
    {
      if (obstacles[posX + 1, posY + 1] is null)
      {
        validMoves.Add(new Target(posX + 1, posY + 1, false));
      }
    }

    // Can attack diagonally to the left
    if (posX < 7)
    {
      if (obstacles[posX + 1, posY] is not null && obstacles[posX + 1, posY]!.Value)
      {
        validMoves.Add(new Target(posX + 1, posY, true));
      }
    }

    // Can attack diagonally to the right
    if (posY < 7)
    {
      if (obstacles[posX, posY + 1] is not null && obstacles[posX, posY + 1]!.Value)
      {
        validMoves.Add(new Target(posX, posY + 1, true));
      }
    }

    return validMoves;
  }
}