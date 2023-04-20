public class King : Piece
{
  public King(int startX, int startY) : base(startX, startY) { }

  private static bool BoundaryCheck(int pos, int offset)
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

  private Target? GetValidMove(int x, int y, int xOff, int yOff, bool?[,] obstacles)
  {
    if (BoundaryCheck(x, xOff) && BoundaryCheck(y, yOff))
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

  public override List<Target> GetValidMoves(bool?[,] obstacles)
  {
    List<Target> validMoves = new List<Target>();
    Target? move;

    // Can move one space up
    move = GetValidMove(posX, posY, 1, 1, obstacles);
    if (move is not null) { validMoves.Add(move.Value); }

    // Can move one space diagonally up-right
    move = GetValidMove(posX, posY, 0, 1, obstacles);
    if (move is not null) { validMoves.Add(move.Value); }

    // Can move one space to the right
    move = GetValidMove(posX, posY, -1, 1, obstacles);
    if (move is not null) { validMoves.Add(move.Value); }

    // Can move one space diagonally down-right
    move = GetValidMove(posX, posY, -1, 0, obstacles);
    if (move is not null) { validMoves.Add(move.Value); }

    // Can move one space down
    move = GetValidMove(posX, posY, -1, -1, obstacles);
    if (move is not null) { validMoves.Add(move.Value); }

    // Can move one space diagonally down-left
    move = GetValidMove(posX, posY, 0, -1, obstacles);
    if (move is not null) { validMoves.Add(move.Value); }

    // Can move one space to the left
    move = GetValidMove(posX, posY, 1, -1, obstacles);
    if (move is not null) { validMoves.Add(move.Value); }

    // Can move one space diagonally up-left
    move = GetValidMove(posX, posY, 1, 0, obstacles);
    if (move is not null) { validMoves.Add(move.Value); }

    return validMoves;
  }
}