class Rook : Piece
{
  public Rook(int startX, int startY) : base(startX, startY) { }

  public override List<Target> getValidMoves(bool?[,] obstacles)
  {
    List<Target> validMoves = new List<Target>();

    // Can move up
    for (int i = 1; i <= 7; i++)
    {
      if (posX + i > 7 || posY + i > 7)
      {
        break;
      }
      if (obstacles[posX + i, posY + i] is null)
      {
        validMoves.Add(new Target(posX + i, posY + i, false));
      }
      else
      {
        if (obstacles[posX + i, posY + i]!.Value)
        {
          validMoves.Add(new Target(posX + i, posY + i, true));
        }
        break;
      }
    }

    // Can move left
    for (int i = 1; i <= 7; i++)
    {
      if (posX + i > 7 || posY - i < 0)
      {
        break;
      }
      if (obstacles[posX + i, posY - i] is null)
      {
        validMoves.Add(new Target(posX + i, posY - i, false));
      }
      else
      {
        if (obstacles[posX + i, posY - i]!.Value)
        {
          validMoves.Add(new Target(posX + i, posY - i, true));
        }
        break;
      }
    }

    // Can move right
    for (int i = 1; i <= 7; i++)
    {
      if (posX - i < 0 || posY + i > 7)
      {
        break;
      }
      if (obstacles[posX - i, posY + i] is null)
      {
        validMoves.Add(new Target(posX - i, posY + i, false));
      }
      else
      {
        if (obstacles[posX - i, posY + i]!.Value)
        {
          validMoves.Add(new Target(posX - i, posY + i, true));
        }
        break;
      }
    }

    // Can move down
    for (int i = 1; i <= 7; i++)
    {
      if (posX - i < 0 || posY - i < 0)
      {
        break;
      }
      if (obstacles[posX - i, posY - i] is null)
      {
        validMoves.Add(new Target(posX - i, posY - i, false));
      }
      else
      {
        if (obstacles[posX - i, posY - i]!.Value)
        {
          validMoves.Add(new Target(posX - i, posY - i, true));
        }
        break;
      }
    }

    return validMoves;
  }
}