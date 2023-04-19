class Knight : Piece
{
  public Knight(int startX, int startY) : base(startX, startY) { }

  private static bool boundaryCheck(int pos, int offset)
  {
    switch (offset)
    {
      case -1:
      case -3:
        return pos >= 0;
      case 1:
      case 3:
        return pos <= 7;
      default:
        return false;
    }
  }

  private static Target? checkValidMove(int x, int y, int xOff, int yOff, bool?[,] obstacles)
  {
    if (boundaryCheck(x, xOff) && boundaryCheck(y, yOff))
    {
      if (obstacles[x + xOff, y + yOff] is null)
      {
        return new Target(x + xOff, y + yOff, false);
      }
      else if (obstacles[x + xOff, y + yOff]!.Value)
      {
        return new Target(x + xOff, y + yOff, true);
      }
    }
    return null;
  }

  public override List<Target> getValidMoves(bool?[,] obstacles)
  {
    List<Target> validMoves = new List<Target>();
    Target? move;

    // All these moves are considered with moving two diagonals in the
    // first direction then one diagonal in the second direction

    // Can move up and left
    move = checkValidMove(posX, posY, 3, 1, obstacles);
    if (move is not null) { validMoves.Add(move.Value); }

    // Can move up and right
    move = checkValidMove(posX, posY, 1, 3, obstacles);
    if (move is not null) { validMoves.Add(move.Value); }

    // Can move right and up
    move = checkValidMove(posX, posY, -1, 3, obstacles);
    if (move is not null) { validMoves.Add(move.Value); }

    // Can move right and down
    move = checkValidMove(posX, posY, -3, 1, obstacles);
    if (move is not null) { validMoves.Add(move.Value); }

    // Can move down and right
    move = checkValidMove(posX, posY, -3, -1, obstacles);
    if (move is not null) { validMoves.Add(move.Value); }

    // Can move down and left
    move = checkValidMove(posX, posY, -1, -3, obstacles);
    if (move is not null) { validMoves.Add(move.Value); }

    // Can move left and down
    move = checkValidMove(posX, posY, 1, -3, obstacles);
    if (move is not null) { validMoves.Add(move.Value); }

    // Can move left and up
    move = checkValidMove(posX, posY, 3, -1, obstacles);
    if (move is not null) { validMoves.Add(move.Value); }

    return validMoves;
  }
}