struct Target
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

abstract class Piece
{
  protected int posX = 0;
  protected int posY = 0;
  protected List<Target> validMoves = new List<Target>();

  public Tuple<int, int> getPos()
  {
    return Tuple.Create(posX, posY);
  }

  public void move(int newX, int newY)
  {
    posX = newX;
    posY = newY;
  }

  public List<Target> getValidMoves()
  {
    return validMoves;
  }

  // True for enemies, false for allies, null for nothing
  public abstract void recalculateValidMoves(bool?[,] obstacles);
}