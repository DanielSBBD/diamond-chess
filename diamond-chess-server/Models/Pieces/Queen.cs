class Queen : Piece
{
  public Queen(int startX, int startY) : base(startX, startY) { }

  private static bool topCheck(int val)
  {
    return val > 7;
  }

  private static bool bottomCheck(int val)
  {
    return val < 0;
  }

  public static List<Target> getValidStraightMoves(int posX, int posY, int xDirection, int yDirection, bool?[,] obstacles)
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

  private static List<Target> getValidDiagonalMoves(int posX, int posY, int xDirection, int yDirection, int boundary, bool?[,] obstacles)
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

    // Can move up
    validMoves.AddRange(getValidStraightMoves(posX, posY, 1, 1, obstacles));

    // Can move diagonally up-right
    validMoves.AddRange(getValidDiagonalMoves(posX, posY, 0, 1, 7 - posY, obstacles));

    // Can move right
    validMoves.AddRange(getValidStraightMoves(posX, posY, -1, 1, obstacles));

    // Can move diagonally down-right
    validMoves.AddRange(getValidDiagonalMoves(posX, posY, -1, 0, posX, obstacles));

    // Can move down
    validMoves.AddRange(getValidStraightMoves(posX, posY, -1, -1, obstacles));

    // Can move diagonally down-left
    validMoves.AddRange(getValidDiagonalMoves(posX, posY, 0, -1, posY, obstacles));

    // Can move left
    validMoves.AddRange(getValidStraightMoves(posX, posY, 1, -1, obstacles));

    // Can move diagonally up-left
    validMoves.AddRange(getValidDiagonalMoves(posX, posY, 1, 0, 7 - posX, obstacles));

    return validMoves;
  }
}