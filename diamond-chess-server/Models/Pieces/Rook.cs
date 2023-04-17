class Rook : Piece
{
  public Rook(int startX, int startY) : base(startX, startY) { }

  private static bool topCheck(int val)
  {
    return val > 7;
  }

  private static bool bottomCheck(int val)
  {
    return val < 0;
  }

  public static List<Target> getValidMovesDirectional(int posX, int posY, int xDirection, int yDirection, bool?[,] obstacles)
  {
    List<Target> validMoves = new List<Target>();

    for (int i = 1; i <= 7; i++)
    {
      int xOff = i * xDirection;
      int yOff = i * yDirection;
      bool xCheck;
      if (xDirection == 1) { xCheck = topCheck(posX + xOff); }
      else { xCheck = bottomCheck(posX + xOff); }
      bool yCheck;
      if (yDirection == 1) { yCheck = topCheck(posY + yOff); }
      else { yCheck = bottomCheck(posY + yOff); }


      if (xCheck || yCheck)
      {
        break;
      }
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

    // Can move up
    validMoves.AddRange(getValidMovesDirectional(posX, posY, 1, 1, obstacles));

    // Can move left
    validMoves.AddRange(getValidMovesDirectional(posX, posY, 1, -1, obstacles));

    // Can move right
    validMoves.AddRange(getValidMovesDirectional(posX, posY, -1, 1, obstacles));

    // Can move down
    validMoves.AddRange(getValidMovesDirectional(posX, posY, -1, -1, obstacles));

    return validMoves;
  }
}