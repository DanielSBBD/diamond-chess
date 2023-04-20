using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace DiamondChess
{
  internal class Tile : PictureBox
  {
    int xPos, yPos, tileRadius, xCoord, yCoord;
    Color originalTileColor;
    Point[] diamondPoints = new Point[4];

    public delegate void CallbackDelegate(int x, int y);
    public event CallbackDelegate? Callback;

    public Tile(Graphics graphics, int x, int y, int xCoord, int yCoord, Color color, int radius)
    {
      this.xPos = x;
      this.yPos = y;
      this.xCoord = xCoord;
      this.yCoord = yCoord;
      this.originalTileColor = color;
      this.tileRadius = radius;
      this.Size = new Size(radius, radius);
      this.BackgroundImageLayout = ImageLayout.Zoom;
      this.BackColor = Color.Transparent;
      this.Location = new Point(x - radius / 2, y - radius / 2);
      this.Click += piece_Click;
      SetDiamondPoints();
      FillTile(color, graphics);
    }

    void piece_Click(object sender, EventArgs e)
    {
      Callback?.Invoke(xCoord, yCoord);
    }

    void SetDiamondPoints()
    {
      this.diamondPoints[0] = new Point(xPos - tileRadius, yPos);
      this.diamondPoints[1] = new Point(xPos, yPos - tileRadius);
      this.diamondPoints[2] = new Point(xPos + tileRadius, yPos);
      this.diamondPoints[3] = new Point(xPos, yPos + tileRadius);
    }

    public void SetOutline(Color c, Graphics g)
    {
      Pen tempPen = new Pen(c);
      tempPen.Width = tileRadius / 4;
      g.DrawPolygon(tempPen, diamondPoints);
      this.Invalidate();
    }

    public void SetPiece(Image img)
    {
      this.BackgroundImage = img;
      this.Invalidate();
    }

    public void RemovePiece()
    {
      this.BackgroundImage = null;
      this.Invalidate();
    }

    public void FillTile(Color color, Graphics g)
    {
      SolidBrush brush = new SolidBrush(color);
      g.FillPolygon(brush, diamondPoints);
      this.BackColor = color;
      this.Invalidate();
    }

    public void ResetTile(Graphics g)
    {
      SolidBrush brush = new SolidBrush(originalTileColor);
      g.FillPolygon(brush, diamondPoints);
      this.BackColor = originalTileColor;
      this.Invalidate();

    }
  }
}
