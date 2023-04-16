class Bishop : Piece
{
  public Bishop(int startX, int startY) : base(startX, startY) { }

  public override List<Target> getValidMoves(bool?[,] obstacles)
  {
    List<Target> validMoves = new List<Target>();

    // Can move diagonally up-left
    for (int i = 1; i <= 7 - posX; i++)
    {
      if (obstacles[posX + i, posY] is null)
      {
        validMoves.Add(new Target(posX + i, posY, false));
      }
      else
      {
        if (obstacles[posX + i, posY]!.Value)
        {
          validMoves.Add(new Target(posX + i, posY, true));
        }
        break;
      }
    }

    // Can move diagonally up-right
    for (int i = 1; i <= 7 - posY; i++)
    {
      if (obstacles[posX, posY + i] is null)
      {
        validMoves.Add(new Target(posX, posY + i, false));
      }
      else
      {
        if (obstacles[posX, posY + i]!.Value)
        {
          validMoves.Add(new Target(posX, posY + i, true));
        }
        break;
      }
    }

    // Can move diagonally down-right
    for (int i = 1; i <= posX; i++)
    {
      if (obstacles[posX - i, posY] is null)
      {
        validMoves.Add(new Target(posX - i, posY, false));
      }
      else
      {
        if (obstacles[posX - i, posY]!.Value)
        {
          validMoves.Add(new Target(posX - i, posY, true));
        }
        break;
      }
    }

    // Can move diagonally down-left
    for (int i = 1; i <= posY; i++)
    {
      if (obstacles[posX, posY - i] is null)
      {
        validMoves.Add(new Target(posX, posY - i, false));
      }
      else
      {
        if (obstacles[posX, posY - i]!.Value)
        {
          validMoves.Add(new Target(posX, posY - i, true));
        }
        break;
      }
    }

    return validMoves;
  }
}