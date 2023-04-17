using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace DiamondChess
{
	internal class Grid : Panel
	{
		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			int radius = Width / 16;

			Graphics graphics = e.Graphics;
			int widthOffset = 0;
			int heightOffset = 0;

			for(int i = 1; i <= 8; i++)
			{
				widthOffset = Width / 2 - radius * (i-1);
				heightOffset = radius * i;

				for (int j = 1; j <= i; j++)
				{
					Color tempColour = new Color();
					if (i%2==0)
					{
						tempColour = Constants.DarkColour;
					}
					else
					{
						tempColour = Constants.LightColour;
					}

					DrawTile(graphics, widthOffset, heightOffset, tempColour, radius);
					widthOffset += radius * 2;
				}
			}

			for (int i = 7; i >= 1; i--)
			{
				widthOffset = Width / 2 - radius * (i-1);
				heightOffset += radius;

				for (int j = 1; j <= i; j++)
				{
					Color tempColour = new Color();
					if (i % 2 == 0)
					{
						tempColour = Constants.DarkColour;
					}
					else
					{
						tempColour = Constants.LightColour;
					}

					DrawTile(graphics, widthOffset, heightOffset, tempColour, radius);
					widthOffset += radius * 2;
				}
			}
		}

		private void DrawTile(Graphics graphics, int x, int y, Color color, int radius)
		{
			Point[] diamondPoints = new Point[4];
			diamondPoints[0] = new Point(x - radius, y);
			diamondPoints[1] = new Point(x, y - radius);
			diamondPoints[2] = new Point(x + radius, y);
			diamondPoints[3] = new Point(x, y + radius);

			SolidBrush brush = new SolidBrush(color);
			graphics.FillPolygon(brush, diamondPoints);
		}
	}
}
