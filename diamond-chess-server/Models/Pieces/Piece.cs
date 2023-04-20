public struct Target
{
  public int posX;
  public int posY;
  public bool isOccupied;

  public Target(int x, int y, bool occupied)
  {
    this.posX = x;
    this.posY = y;
    this.isOccupied = occupied;
  }
}

public abstract class Piece
{
  protected int posX = 0;
  protected int posY = 0;

  public Piece(int startX, int startY)
  {
    posX = startX;
    posY = startY;
  }

  public Tuple<int, int> GetPos()
  {
    return Tuple.Create(posX, posY);
  }

  public void Move(int newX, int newY)
  {
    posX = newX;
    posY = newY;
  }

  // True for enemies, false for allies, null for nothing
  public abstract List<Target> GetValidMoves(bool?[,] obstacles, bool isWhite);
}