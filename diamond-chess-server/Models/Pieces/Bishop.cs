class Bishop : Piece
{
  public Bishop(int startX, int startY) : base(startX, startY) { }

  private static List<Target> getValidMovesDirectional(int posX, int posY, int xDirection, int yDirection, int boundary, bool?[,] obstacles)
  {
    List<Target> validMoves = new List<Target>();

    for (int i = 1; i <= boundary; i++)
    {
      int xOff = i * xDirection;
      int yOff = i * yDirection;
      if (obstacles[posX + xOff, posY + yOff] is null)
      {
        validMoves.Add(new Target(posX + xOff, posY + yOff, false));
      }
      else
      {
        if (obstacles[posX + xOff, posY + yOff]!.Value)
        {
          validMoves.Add(new Target(posX + xOff, posY + yOff, true));
        }
        break;
      }
    }

    return validMoves;
  }

  public override List<Target> getValidMoves(bool?[,] obstacles)
  {
    List<Target> validMoves = new List<Target>();

    // Can move diagonally up-left
    validMoves.AddRange(getValidMovesDirectional(posX, posY, 1, 0, 7 - posX, obstacles));

    // Can move diagonally up-right
    validMoves.AddRange(getValidMovesDirectional(posX, posY, 0, 1, 7 - posY, obstacles));

    // Can move diagonally down-right
    validMoves.AddRange(getValidMovesDirectional(posX, posY, -1, 0, posX, obstacles));

    // Can move diagonally down-left
    validMoves.AddRange(getValidMovesDirectional(posX, posY, 0, -1, posY, obstacles));

    return validMoves;
  }
}