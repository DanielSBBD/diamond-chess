class Pawn : Piece
{
  public override void recalculateValidMoves(bool?[,] obstacles)
  {
    validMoves = new List<Target>();
    if (posX < 7 && posY < 7)
    {
      if (obstacles[posX + 1, posY + 1] is null)
      {
        validMoves.Add(new Target(posX + 1, posY + 1, false));
      }
      else if (obstacles[posX + 1, posY + 1]!.Value)
      {
        validMoves.Add(new Target(posX + 1, posY + 1, true));
      }
    }
  }
}