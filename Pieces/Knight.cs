class Knight : Piece
{
  public Knight(int startX, int startY) : base(startX, startY) { }

  private delegate bool boundaryCheck(int val);

  private static bool topCheck(int val)
  {
    return val <= 7;
  }

  private static bool bottomCheck(int val)
  {
    return val >= 0;
  }

  private static Target? checkValidMove(int x, int y, boundaryCheck xCheck, boundaryCheck yCheck, bool?[,] obstacles)
  {
    if (xCheck(x) && yCheck(y))
    {
      if (obstacles[x, y] is null)
      {
        return new Target(x, y, false);
      }
      else if (obstacles[x, y]!.Value)
      {
        return new Target(x, y, true);
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
    move = checkValidMove(posX + 3, posY + 1, topCheck, topCheck, obstacles);
    if (move is not null) { validMoves.Add((Target)move); }

    // Can move up and right
    move = checkValidMove(posX + 1, posY + 3, topCheck, topCheck, obstacles);
    if (move is not null) { validMoves.Add((Target)move); }

    // Can move right and up
    move = checkValidMove(posX - 1, posY + 3, bottomCheck, topCheck, obstacles);
    if (move is not null) { validMoves.Add((Target)move); }

    // Can move right and down
    move = checkValidMove(posX - 3, posY + 1, bottomCheck, topCheck, obstacles);
    if (move is not null) { validMoves.Add((Target)move); }

    // Can move down and right
    move = checkValidMove(posX - 3, posY - 1, bottomCheck, bottomCheck, obstacles);
    if (move is not null) { validMoves.Add((Target)move); }

    // Can move down and left
    move = checkValidMove(posX - 1, posY - 3, bottomCheck, bottomCheck, obstacles);
    if (move is not null) { validMoves.Add((Target)move); }

    // Can move left and down
    move = checkValidMove(posX + 1, posY - 3, topCheck, bottomCheck, obstacles);
    if (move is not null) { validMoves.Add((Target)move); }

    // Can move left and up
    move = checkValidMove(posX + 3, posY - 1, topCheck, bottomCheck, obstacles);
    if (move is not null) { validMoves.Add((Target)move); }

    return validMoves;
  }
}