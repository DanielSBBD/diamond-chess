namespace diamond_chess_server.Models
{
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

  public abstract partial class Piece
  {
    protected int posX = 0;
    protected int posY = 0;

    public Tuple<int, int> getPos()
    {
      return Tuple.Create(posX, posY);
    }

    public void move(int newX, int newY)
    {
      posX = newX;
      posY = newY;
    }

    // True for enemies, false for allies, null for nothing
    public abstract List<Target> getValidMoves(bool?[,] obstacles);
  }
}
