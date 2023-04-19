using System.Diagnostics;
using System.Drawing;

namespace DiamondChess
{
	internal class Grid : Panel
	{
		int radius = 0;

		List<PictureBox> whiteInventoryPieces = new List<PictureBox>();
		List<PictureBox> blackInventoryPieces = new List<PictureBox>();
		int whiteInventoryX = 100;
		int whiteInventoryY = 400;
		int blackInventoryX = 1700;
		int blackInventoryY = 400;

		Tile[,] piecesArray = new Tile[Constants.GridSize, Constants.GridSize];
		public Dictionary<int, (int x, int y)> PositionDictionary = new Dictionary<int, (int, int)>();

		int xCounter = 0;
		int yCounter = 0;
		int drawTileCounter = 0;

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			int radius = Width / 16;

			Graphics graphics = e.Graphics;
			int widthOffset = 0;
			int heightOffset = 0;
			xCounter = 0;
			yCounter = 0;
			drawTileCounter = 0;
			PositionDictionary = new Dictionary<int, (int, int)>();

			for (int i = 1; i <= Constants.GridSize; i++)
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
					PositionDictionary.Add(drawTileCounter, (widthOffset, heightOffset));
					widthOffset += radius * 2;
				}
			}
		}

		private void DrawTile(Graphics graphics, int x, int y, Color color, int radius)
		{
			Tile tempPicBox = new Tile(graphics, x, y, color, radius);
			piecesArray[Constants.CoordinateDictionary[drawTileCounter].x, Constants.CoordinateDictionary[drawTileCounter].y] = tempPicBox;
			IncrementCounters();
		}

		void IncrementCounters()
		{
			xCounter++;
			if(xCounter > 7)
			{
				xCounter = 0;
				yCounter++;
			}
			drawTileCounter++;
		}

		public void DrawPiece(Image img, int x, int y)
		{
			piecesArray[x, y].SetPiece(img);
			Controls.Add(piecesArray[x, y]);
		}

		public void TakePiece(Image img, int x, int y, bool isBlack)
		{
			if (piecesArray[x, y].BackgroundImage != null) // JESSE - NOT WORKING
			{
				//if (isBlack)
				//{
				//	AddToWhiteInventory(piecesArray[x, y].BackgroundImage);
				//}
				//else
				//{
				//	AddToBlackInventory(piecesArray[x, y].BackgroundImage);
				//}
			}			

			piecesArray[x, y].RemovePiece();
			piecesArray[x, y].SetPiece(img);
		}

		public void AddToWhiteInventory(Image img) // JESSE - NOT WORKING
		{
			whiteInventoryPieces.Add(new PictureBox());
			whiteInventoryPieces[^1].Size = new Size(radius, radius);
			whiteInventoryPieces[^1].BackgroundImageLayout = ImageLayout.Zoom;
			whiteInventoryPieces[^1].BackColor = Color.Transparent;
			whiteInventoryPieces[^1].Location = new Point(whiteInventoryX, whiteInventoryY);
			Controls.Add(blackInventoryPieces[^1]);

			whiteInventoryPieces[^1].BackgroundImage = img;
			whiteInventoryPieces[^1].BringToFront();
			whiteInventoryPieces[^1].Refresh();
			whiteInventoryY += 100;
		}

		public void AddToBlackInventory(Image img) // JESSE - NOT WORKING
		{
			blackInventoryPieces.Add(new PictureBox());
			blackInventoryPieces[^1].Size = new Size(100, 100);
			blackInventoryPieces[^1].BackgroundImageLayout = ImageLayout.Zoom;
			blackInventoryPieces[^1].BackColor = Color.Transparent;
			blackInventoryPieces[^1].Location = new Point(blackInventoryX, blackInventoryY);
			Controls.Add(blackInventoryPieces[^1]);

			blackInventoryPieces[^1].BackgroundImage = img;
			blackInventoryPieces[^1].BringToFront();
			blackInventoryPieces[^1].Refresh();
			blackInventoryY += 100;
		}




		public void OutlinePieces(List<int> xList, List<int> yList, List<Color> colorList)
		{
			Graphics graphics = this.CreateGraphics();
			for (int i = 0; i < xList.Count; i++)
			{
				piecesArray[xList[i], yList[i]].SetOutline(colorList[i], graphics);
				Controls.Add(piecesArray[xList[i], yList[i]]);
			}
			graphics.Dispose();
		}



		List<int> lastHighlightedX = new List<int>();
		List<int> lastHighlightedY = new List<int>();
		public void HighlightPieces(List<int> xList, List<int> yList, List<Color> colorList)
		{
			Graphics graphics = this.CreateGraphics();
			ResetHighlightedPieces();
			lastHighlightedX = xList;
			lastHighlightedY = yList;

			for(int i = 0; i < xList.Count; i++)
			{
				piecesArray[xList[i], yList[i]].FillTile(colorList[i], graphics);
			}
			graphics.Dispose();
		}

		public void ResetHighlightedPieces()
		{
			RemoveHighlights(lastHighlightedX, lastHighlightedY);
		}

		public void RemoveHighlights(List<int> xList, List<int> yList)
		{
			Graphics graphics = this.CreateGraphics();
			lastHighlightedX = new List<int>();
			lastHighlightedY = new List<int>();

			for (int i = 0; i < xList.Count; i++)
			{
				piecesArray[xList[i], yList[i]].ResetTile(graphics);
			}
			graphics.Dispose();
		}

		public void RedrawStartPositions()
		{
			// BLACK PIECES
			DrawPiece(Properties.Resources.B_King, 7, 7);
			DrawPiece(Properties.Resources.B_Queen, 6, 6);
			DrawPiece(Properties.Resources.B_Rook, 7, 6);
			DrawPiece(Properties.Resources.B_Rook, 6, 7);
			DrawPiece(Properties.Resources.B_Bishop, 5, 7);
			DrawPiece(Properties.Resources.B_Bishop, 6, 5);
			DrawPiece(Properties.Resources.B_Knight, 7, 5);
			DrawPiece(Properties.Resources.B_Knight, 5, 6);

			DrawPiece(Properties.Resources.B_Pawn, 7, 4);
			DrawPiece(Properties.Resources.B_Pawn, 6, 4);
			DrawPiece(Properties.Resources.B_Pawn, 5, 4);
			DrawPiece(Properties.Resources.B_Pawn, 4, 4);
			DrawPiece(Properties.Resources.B_Pawn, 5, 5);
			DrawPiece(Properties.Resources.B_Pawn, 4, 5);
			DrawPiece(Properties.Resources.B_Pawn, 4, 6);
			DrawPiece(Properties.Resources.B_Pawn, 4, 7);
		

			// WHITE PIECES
			DrawPiece(Properties.Resources.W_King, 0, 0);
			DrawPiece(Properties.Resources.W_Queen, 1, 1);
			DrawPiece(Properties.Resources.W_Rook, 1, 0);
			DrawPiece(Properties.Resources.W_Rook, 0, 1);
			DrawPiece(Properties.Resources.W_Bishop, 2, 0);
			DrawPiece(Properties.Resources.W_Bishop, 1, 2);
			DrawPiece(Properties.Resources.W_Knight, 2, 1);
			DrawPiece(Properties.Resources.W_Knight, 0, 2);

			DrawPiece(Properties.Resources.W_Pawn, 3, 0);
			DrawPiece(Properties.Resources.W_Pawn, 3, 1);
			DrawPiece(Properties.Resources.W_Pawn, 3, 2);
			DrawPiece(Properties.Resources.W_Pawn, 3, 3);
			DrawPiece(Properties.Resources.W_Pawn, 2, 2);
			DrawPiece(Properties.Resources.W_Pawn, 2, 3);
			DrawPiece(Properties.Resources.W_Pawn, 1, 3);
			DrawPiece(Properties.Resources.W_Pawn, 0, 3);
		}
	}
}
