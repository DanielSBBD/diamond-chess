
using diamond_chess_server.Models;
using System.Diagnostics;

namespace DiamondChess
{
	internal class Grid : Panel
	{
		int radius = 0;

		Tile[,] whiteInventoryTiles = new Tile[Constants.InventoryWidth, Constants.InventoryHeight];
		Tile[,] blackInventoryTiles = new Tile[Constants.InventoryWidth, Constants.InventoryHeight];

		Tile[,] tileArray = new Tile[Constants.GridSize, Constants.GridSize];
		Piece?[,] piecesArray = new Piece?[Constants.GridSize, Constants.GridSize];

		public Dictionary<int, (int x, int y)> PositionDictionary = new Dictionary<int, (int, int)>();
		int xCounter = 0;
		int yCounter = 0;
		int drawTileCounter = 0;
		int whiteInventoryCounter = 0;
		int blackInventoryCounter = 0;

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			int radius = Width / 32;

			Graphics graphics = e.Graphics;
			int widthOffset = 0;
			int heightOffset = 0;
			xCounter = 0;
			yCounter = 0;
			drawTileCounter = 0;
			whiteInventoryCounter = 0;
			blackInventoryCounter = 0;	
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


			for (int i = 0; i < Constants.InventoryWidth; i++)
			{
				for (int j = 0; j < Constants.InventoryHeight; j++)
				{
					DrawWhiteInventoryTile(graphics, i, j, radius);
					DrawBlackInventoryTile(graphics, i, j, radius);
				}
			}
		}

		private void DrawTile(Graphics graphics, int xPos, int yPos, Color color, int radius)
		{
			int xCoord = Constants.CoordinateDictionary[drawTileCounter].x;
			int yCoord = Constants.CoordinateDictionary[drawTileCounter].y;
			Tile tempPicBox = new Tile(graphics, xPos, yPos, xCoord, yCoord, color, radius);
			tileArray[xCoord, yCoord] = tempPicBox;
			IncrementCounters();
		}

		private void DrawWhiteInventoryTile(Graphics graphics, int xCoord, int yCoord, int radius)
		{
			int xPos = -1;
			int yPos = -1;
			(xPos, yPos) = Constants.InventoryDictionary[(xCoord, yCoord)];
			Tile tempPicBox = new Tile(graphics, xPos, yPos, xCoord, yCoord, Color.Transparent, radius);
			whiteInventoryTiles[xCoord, yCoord] = tempPicBox;
			Controls.Add(whiteInventoryTiles[xCoord, yCoord]);

		}
		private void DrawBlackInventoryTile(Graphics graphics, int xCoord, int yCoord, int radius)
		{
			int xPos = -1;
			int yPos = -1;
			(xPos, yPos) = Constants.InventoryDictionary[(xCoord+3, yCoord)];
			Tile tempPicBox = new Tile(graphics, xPos, yPos, xCoord, yCoord, Color.Transparent, radius);
			blackInventoryTiles[xCoord, yCoord] = tempPicBox;
			Controls.Add(blackInventoryTiles[xCoord, yCoord]);

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
			tileArray[x, y].SetPiece(img);
			Controls.Add(tileArray[x, y]);
			//string pieceType = Constants.PieceDictionary[img];
			//piecesArray[x, y] = new Bishop(x, y);
		}

		public void TakePiece(Image img, int x, int y, bool isWhite)
		{
			//if (tileArray[x, y].BackgroundImage != null) // JESSE - NOT WORKING
			//{
				AddToInventory(tileArray[x, y].BackgroundImage, isWhite);

			//}

			tileArray[x, y].RemovePiece();
			tileArray[x, y].SetPiece(img);
		}

		public void AddToInventory(Image img, bool isWhite) // JESSE - NOT WORKING
		{
			if (isWhite)
			{
				whiteInventoryTiles[(int)whiteInventoryCounter / Constants.InventoryHeight, whiteInventoryCounter % Constants.InventoryHeight].SetPiece(img);
				whiteInventoryCounter++;
				if(whiteInventoryCounter >= 15)
				{
					whiteInventoryCounter = 0;
				}
			}
			else
			{
				blackInventoryTiles[(int)blackInventoryCounter / Constants.InventoryHeight, blackInventoryCounter % Constants.InventoryHeight].SetPiece(img);
				blackInventoryCounter++;
				if (blackInventoryCounter >= 15)
				{
					blackInventoryCounter = 0;
				}
			}
		}


		public void OutlinePieces(List<int> xList, List<int> yList, List<Color> colorList)
		{
			Graphics graphics = this.CreateGraphics();
			for (int i = 0; i < xList.Count; i++)
			{
				tileArray[xList[i], yList[i]].SetOutline(colorList[i], graphics);
				Controls.Add(tileArray[xList[i], yList[i]]);
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
				tileArray[xList[i], yList[i]].FillTile(colorList[i], graphics);
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
				tileArray[xList[i], yList[i]].ResetTile(graphics);
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
