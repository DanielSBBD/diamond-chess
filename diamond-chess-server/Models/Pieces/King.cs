class King : Piece
{
  public King(int startX, int startY) : base(startX, startY) { }

  private static bool boundaryCheck(int pos, int offset)
  {
    switch (offset)
    {
      case -1:
        return pos > 0;
      case 0:
        return true;
      case 1:
        return pos < 7;
      default:
        return false;
    }
  }

  private Target? getValidMove(int x, int y, int xOff, int yOff, bool?[,] obstacles)
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

    // Can move one space up
    move = getValidMove(posX, posY, 1, 1, obstacles);
    if (move is not null) { validMoves.Add(move.Value); }

    // Can move one space diagonally up-right
    move = getValidMove(posX, posY, 0, 1, obstacles);
    if (move is not null) { validMoves.Add(move.Value); }

    // Can move one space to the right
    move = getValidMove(posX, posY, -1, 1, obstacles);
    if (move is not null) { validMoves.Add(move.Value); }

    // Can move one space diagonally down-right
    move = getValidMove(posX, posY, -1, 0, obstacles);
    if (move is not null) { validMoves.Add(move.Value); }

    // Can move one space down
    move = getValidMove(posX, posY, -1, -1, obstacles);
    if (move is not null) { validMoves.Add(move.Value); }

    // Can move one space diagonally down-left
    move = getValidMove(posX, posY, 0, -1, obstacles);
    if (move is not null) { validMoves.Add(move.Value); }

    // Can move one space to the left
    move = getValidMove(posX, posY, 1, -1, obstacles);
    if (move is not null) { validMoves.Add(move.Value); }

    // Can move one space diagonally up-left
    move = getValidMove(posX, posY, 1, 0, obstacles);
    if (move is not null) { validMoves.Add(move.Value); }

    return validMoves;
  }
}