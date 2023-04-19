using System.Diagnostics;
using System.Drawing;

namespace DiamondChess
{
	internal class Grid : Panel
	{
		const int gridSize = 8;
		int radius = 0;

		List<PictureBox> pieces = new List<PictureBox>();
		List<PictureBox> whiteInventoryPieces = new List<PictureBox>();
		List<PictureBox> blackInventoryPieces = new List<PictureBox>();
		int whiteInventoryX = 100;
		int whiteInventoryY = 400;
		int blackInventoryX = 1700;
		int blackInventoryY = 400;

		PictureBox[,] piecesArray = new PictureBox[gridSize, gridSize];

		int xCounter = 0;
		int yCounter = 0;

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			int radius = Width / 16;

			Graphics graphics = e.Graphics;
			int widthOffset = 0;
			int heightOffset = 0;
			xCounter = 0;
			yCounter = 0;

			for(int i = 1; i <= gridSize; i++)
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
			ConvertPiecesListToArray();
		}

		private void DrawTile(Graphics graphics, int x, int y, Color color, int radius)
		{
			DrawDiamond(graphics, x, y, color, radius);

			PictureBox tempPicBox = new PictureBox();
			tempPicBox.Size = new Size(radius, radius);
			tempPicBox.BackgroundImageLayout = ImageLayout.Zoom;
			tempPicBox.BackColor = Color.Transparent;
			tempPicBox.BringToFront();
			tempPicBox.Location = new Point(x - radius / 2, y - radius / 2);
			tempPicBox.BackgroundImage = null; 

			pieces.Add(tempPicBox);
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
		}

		public void DrawPiece(Image img, int x, int y)
		{
			piecesArray[x, y].BackgroundImage = img;
			piecesArray[x, y].BringToFront();
			piecesArray[x, y].Refresh();
		}

		void DrawDiamond(Graphics graphics, int x, int y, Color color, int radius)
		{
			Point[] diamondPoints = new Point[4];

			diamondPoints[0] = new Point(x - radius, y);
			diamondPoints[1] = new Point(x, y - radius);
			diamondPoints[2] = new Point(x + radius, y);
			diamondPoints[3] = new Point(x, y + radius);

			SolidBrush brush = new SolidBrush(color);
			graphics.FillPolygon(brush, diamondPoints);
		}

		public void RemovePiece(int x, int y)
		{
			if (piecesArray[x, y].BackgroundImage != null) // JESSE - NOT WORKING
			{
				if (piecesArray[x, y].BackgroundImage.ToString().Substring(0, 1) == "B")
				{
					AddToWhiteInventory(piecesArray[x, y].BackgroundImage);
				}
				else
				{
					AddToBlackInventory(piecesArray[x, y].BackgroundImage);
				}
			}			

			piecesArray[x, y].BackgroundImage = null;
			piecesArray[x, y].BringToFront();
			piecesArray[x, y].Refresh();
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

		List<int> lastHighlightedX = new List<int>();
		List<int> lastHighlightedY = new List<int>();
		public void HighlightPieces(List<int> xPos, List<int> yPos)
		{
			ResetHighlightedPieces();
			lastHighlightedX = xPos;
			lastHighlightedY = yPos;

			for(int i = 0; i < xPos.Count; i++)
			{
				if(i == 0)
				{
					HighlightPiece(xPos[i], yPos[i], Color.Red);
				}
				else
				{
					HighlightPiece(xPos[i], yPos[i], Color.Pink);
				}
			}
		}

		public void ResetHighlightedPieces()
		{
			for(int i = 0; i < lastHighlightedX.Count; i++)
			{
				RemoveHighlight(lastHighlightedX[i], lastHighlightedY[i]);
			}
		}

		public void HighlightPiece(int x, int y, Color color)
		{
			piecesArray[x, y].BackColor = color;
			piecesArray[x, y].BringToFront();
			piecesArray[x, y].Refresh();
		}

		public void RemoveHighlight(int x, int y)
		{
			piecesArray[x, y].BackColor = Color.Transparent;
			piecesArray[x, y].BringToFront();
			piecesArray[x, y].Refresh();
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

		// PLEASE DON'T LOOK HERE THIS IS JUST AWFUL :( 
		// Yes I'm ashamed, yes there's a MUCH better way to do this, no I don't know what it is, yes it was later 
		void ConvertPiecesListToArray()
		{
			piecesArray[0, 0] = pieces[63];
			Controls.Add(piecesArray[0, 0]);

			piecesArray[0, 1] = pieces[62];
			Controls.Add(piecesArray[0, 1]);

			piecesArray[0, 2] = pieces[60];
			Controls.Add(piecesArray[0, 2]);

			piecesArray[0, 3] = pieces[57];
			Controls.Add(piecesArray[0, 3]);

			piecesArray[0, 4] = pieces[53];
			Controls.Add(piecesArray[0, 4]);

			piecesArray[0, 5] = pieces[48];
			Controls.Add(piecesArray[0, 5]);

			piecesArray[0, 6] = pieces[42];
			Controls.Add(piecesArray[0, 6]);

			piecesArray[0, 7] = pieces[35];
			Controls.Add(piecesArray[0, 7]);

			piecesArray[1, 0] = pieces[61];
			Controls.Add(piecesArray[1, 0]);

			piecesArray[1, 1] = pieces[59];
			Controls.Add(piecesArray[1, 1]);

			piecesArray[1, 2] = pieces[56];
			Controls.Add(piecesArray[1, 2]);

			piecesArray[1, 3] = pieces[52];
			Controls.Add(piecesArray[1, 3]);

			piecesArray[1, 4] = pieces[47];
			Controls.Add(piecesArray[1, 4]);

			piecesArray[1, 5] = pieces[41];
			Controls.Add(piecesArray[1, 5]);

			piecesArray[1, 6] = pieces[34];
			Controls.Add(piecesArray[1, 6]);

			piecesArray[1, 7] = pieces[27];
			Controls.Add(piecesArray[1, 7]);

			piecesArray[2, 0] = pieces[58];
			Controls.Add(piecesArray[2, 0]);

			piecesArray[2, 1] = pieces[55];
			Controls.Add(piecesArray[2, 1]);

			piecesArray[2, 2] = pieces[51];
			Controls.Add(piecesArray[2, 2]);

			piecesArray[2, 3] = pieces[46];
			Controls.Add(piecesArray[2, 3]);

			piecesArray[2, 4] = pieces[40];
			Controls.Add(piecesArray[2, 4]);

			piecesArray[2, 5] = pieces[33];
			Controls.Add(piecesArray[2, 5]);

			piecesArray[2, 6] = pieces[26];
			Controls.Add(piecesArray[2, 6]);

			piecesArray[2, 7] = pieces[20];
			Controls.Add(piecesArray[2, 7]);

			piecesArray[3, 0] = pieces[54];
			Controls.Add(piecesArray[3, 0]);

			piecesArray[3, 1] = pieces[50];
			Controls.Add(piecesArray[3, 1]);

			piecesArray[3, 2] = pieces[45];
			Controls.Add(piecesArray[3, 2]);

			piecesArray[3, 3] = pieces[39];
			Controls.Add(piecesArray[3, 3]);

			piecesArray[3, 4] = pieces[32];
			Controls.Add(piecesArray[3, 4]);

			piecesArray[3, 5] = pieces[25];
			Controls.Add(piecesArray[3, 5]);

			piecesArray[3, 6] = pieces[19];
			Controls.Add(piecesArray[3, 6]);

			piecesArray[3, 7] = pieces[14];
			Controls.Add(piecesArray[3, 7]);

			piecesArray[4, 0] = pieces[49];
			Controls.Add(piecesArray[4, 0]);

			piecesArray[4, 1] = pieces[44];
			Controls.Add(piecesArray[4, 1]);

			piecesArray[4, 2] = pieces[38];
			Controls.Add(piecesArray[4, 2]);

			piecesArray[4, 3] = pieces[31];
			Controls.Add(piecesArray[4, 3]);

			piecesArray[4, 4] = pieces[24];
			Controls.Add(piecesArray[4, 4]);

			piecesArray[4, 5] = pieces[18];
			Controls.Add(piecesArray[4, 5]);

			piecesArray[4, 6] = pieces[13];
			Controls.Add(piecesArray[4, 6]);

			piecesArray[4, 7] = pieces[9];
			Controls.Add(piecesArray[4, 7]);

			piecesArray[5, 0] = pieces[43];
			Controls.Add(piecesArray[5, 0]);

			piecesArray[5, 1] = pieces[37];
			Controls.Add(piecesArray[5, 1]);

			piecesArray[5, 2] = pieces[30];
			Controls.Add(piecesArray[5, 2]);

			piecesArray[5, 3] = pieces[23];
			Controls.Add(piecesArray[5, 3]);

			piecesArray[5, 4] = pieces[17];
			Controls.Add(piecesArray[5, 4]);

			piecesArray[5, 5] = pieces[12];
			Controls.Add(piecesArray[5, 5]);

			piecesArray[5, 6] = pieces[8];
			Controls.Add(piecesArray[5, 6]); 
			
			piecesArray[5, 7] = pieces[5];
			Controls.Add(piecesArray[5, 7]);

			piecesArray[6, 0] = pieces[36];
			Controls.Add(piecesArray[6, 0]);

			piecesArray[6, 1] = pieces[29];
			Controls.Add(piecesArray[6, 1]);
		
			piecesArray[6, 2] = pieces[22];
			Controls.Add(piecesArray[6, 2]);

			piecesArray[6, 3] = pieces[16];
			Controls.Add(piecesArray[6, 3]);

			piecesArray[6, 4] = pieces[11];
			Controls.Add(piecesArray[6, 4]);

			piecesArray[6, 5] = pieces[7];
			Controls.Add(piecesArray[6, 5]);

			piecesArray[6, 6] = pieces[4];
			Controls.Add(piecesArray[6, 6]);

			piecesArray[6, 7] = pieces[2];
			Controls.Add(piecesArray[6, 7]);

			piecesArray[7, 0] = pieces[28];
			Controls.Add(piecesArray[7, 0]);

			piecesArray[7, 1] = pieces[21];
			Controls.Add(piecesArray[7, 1]);

			piecesArray[7, 2] = pieces[15];
			Controls.Add(piecesArray[7, 2]);

			piecesArray[7, 3] = pieces[10];
			Controls.Add(piecesArray[7, 3]);

			piecesArray[7, 4] = pieces[6];
			Controls.Add(piecesArray[7, 4]);

			piecesArray[7, 5] = pieces[3];
			Controls.Add(piecesArray[7, 5]);

			piecesArray[7, 6] = pieces[1];
			Controls.Add(piecesArray[7, 6]); 
			
			piecesArray[7, 7] = pieces[0];
			Controls.Add(piecesArray[7, 7]);
		}
	}
}
