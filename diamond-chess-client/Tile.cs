using System.Drawing;
using System.Windows.Forms;

namespace DiamondChess
{
	internal class Tile : PictureBox
	{
		int xPos, yPos, tileRadius;
		Color originalTileColor;
		Point[] diamondPoints = new Point[4];

		public Tile(Graphics graphics, int x, int y, Color color, int radius)
		{
			this.xPos = x;
			this.yPos = y;
			this.originalTileColor = color;
			this.tileRadius = radius;
			this.Size = new Size(radius, radius);
			this.BackgroundImageLayout = ImageLayout.Zoom;
			this.BackColor = Color.Transparent;
			this.Location = new Point(x - radius / 2, y - radius / 2);
			SetDiamondPoints();
			FillDiamond(color, graphics);
		}

		void SetDiamondPoints()
		{
			this.diamondPoints[0] = new Point(xPos - tileRadius, yPos);
			this.diamondPoints[1] = new Point(xPos, yPos - tileRadius);
			this.diamondPoints[2] = new Point(xPos + tileRadius, yPos);
			this.diamondPoints[3] = new Point(xPos, yPos + tileRadius);
		}

		void FillDiamond(Color c, Graphics g)
		{
			SolidBrush brush = new SolidBrush(c);
			g.FillPolygon(brush, diamondPoints);
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

		public void HighlightPiece(Color color)
		{
			this.BackColor = color;
			this.Invalidate();
		}
	}
}
