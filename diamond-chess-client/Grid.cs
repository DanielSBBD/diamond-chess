namespace DiamondChess
{
  public struct ColouredPiece
  {
    public Piece piece;
    public bool isWhite;

    public ColouredPiece(Piece p, bool w)
    {
      piece = p;
      isWhite = w;
    }
  }

  internal class Grid : Panel
  {
    int radius = 0;

    //Tile[,] whiteInventoryTiles = new Tile[2, Constants.GridSize];
    //Tile[,] blackInventoryTiles = new Tile[2, Constants.GridSize];

    int whiteInventoryX = 100;
    int whiteInventoryY = 400;
    int blackInventoryX = 1700;
    int blackInventoryY = 400;

    int numBlackPiecesTaken = 0;
    int numWhitePiecesTaken = 0;

    public event EventHandler<int> RaiseTurnChangeEvent;

    Tile[,] tileArray = new Tile[Constants.GridSize, Constants.GridSize];
    ColouredPiece?[,] piecesArray = new ColouredPiece?[Constants.GridSize, Constants.GridSize];

    public Dictionary<int, (int x, int y)> PositionDictionary = new Dictionary<int, (int, int)>();
    int xCounter = 0;
    int yCounter = 0;
    int drawTileCounter = 0;

    bool isWhitesTurn = true;
    (int, int) selectedPiece = (8, 8);

    public void HandleClick(int x, int y)
    {
      // If you're clicking a piece
      if (piecesArray[x, y] is not null)
      {
        // If you're taking a piece
        if (tileArray[x, y].isHighlighted)
        {
          // Remember me
          Image tileImage = tileArray[selectedPiece.Item1, selectedPiece.Item2].BackgroundImage;
          ColouredPiece colouredPiece = piecesArray[selectedPiece.Item1, selectedPiece.Item2].Value;
          // Kill old
          tileArray[selectedPiece.Item1, selectedPiece.Item2].RemovePiece();
          piecesArray[selectedPiece.Item1, selectedPiece.Item2] = null;
          // Kill target
          tileArray[x, y].RemovePiece();
          piecesArray[x, y] = null;
          // Add new
          tileArray[x, y].SetPiece(tileImage);
          colouredPiece.piece.Move(x, y);
          piecesArray[x, y] = colouredPiece;
          selectedPiece = (8, 8);
          // Reset highlights
          ResetHighlightedPieces();

          if (isWhitesTurn)
          {
            numBlackPiecesTaken++;
          }
          else
          {
            numWhitePiecesTaken++;
          }

          if (RaiseTurnChangeEvent != null)
          {
            if (numBlackPiecesTaken >= 16)
            {
              RaiseTurnChangeEvent(this, 1);
            }
            else if (numWhitePiecesTaken >= 16)
            {
              RaiseTurnChangeEvent(this, -1);
            }
            else {
              RaiseTurnChangeEvent(this, 0);
            }
          }

          // Switch turn
          isWhitesTurn = !isWhitesTurn;
        }
        else
        {
          // If you're selecting a piece
          if (x != selectedPiece.Item1 || y != selectedPiece.Item2)
          {
            selectedPiece = (x, y);
            bool?[,] b = new bool?[8, 8];
            Piece thisPiece = piecesArray[x, y].Value.piece;
            bool isThisPieceWhite = piecesArray[x, y].Value.isWhite;

            if ((isWhitesTurn && isThisPieceWhite) || (!isWhitesTurn && !isThisPieceWhite))
            {
              for (int i = 0; i < 8; i++)
              {
                for (int j = 0; j < 8; j++)
                {
                  if (piecesArray[i, j] is not null)
                  {
                    if (isThisPieceWhite)
                    {
                      b[i, j] = !piecesArray[i, j].Value.isWhite;
                    }
                    else
                    {
                      b[i, j] = piecesArray[i, j].Value.isWhite;
                    }
                  }
                }
              }

              HighlightPieces(thisPiece.GetValidMoves(b, isThisPieceWhite).Select((target, index) => (
                target.posX, target.posY, target.isOccupied ? Color.Red : Color.Green
              )).ToList());
            }

          }
          else // If you are unselecting a piece
          {
            selectedPiece = (8, 8);
            ResetHighlightedPieces();
          }
        }
      }
      // If you're moving a piece
      if (tileArray[x, y].isHighlighted)
      {
        // Remember me
        Image tileImage = tileArray[selectedPiece.Item1, selectedPiece.Item2].BackgroundImage;
        ColouredPiece colouredPiece = piecesArray[selectedPiece.Item1, selectedPiece.Item2].Value;
        // Kill old
        tileArray[selectedPiece.Item1, selectedPiece.Item2].RemovePiece();
        piecesArray[selectedPiece.Item1, selectedPiece.Item2] = null;
        // Add new
        tileArray[x, y].SetPiece(tileImage);
        colouredPiece.piece.Move(x, y);
        piecesArray[x, y] = colouredPiece;
        selectedPiece = (8, 8);
        // Reset highlights
        ResetHighlightedPieces();
        // Switch turn
        isWhitesTurn = !isWhitesTurn;
        if (RaiseTurnChangeEvent != null)
        {
            RaiseTurnChangeEvent(this, 0);
        }
      }
    }

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
        widthOffset = Width / 2 - radius * (i - 1);
        heightOffset = radius * i;

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

      for (int i = 7; i >= 1; i--)
      {
        widthOffset = Width / 2 - radius * (i - 1);
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

      //for(int i = 0; i < Constants.GridSize; i++)
      //{
      //	for(int j =  0; j < whiteInventoryTiles.Length; j++)
      //	{


      //	}
      //}
    }

    private void DrawTile(Graphics graphics, int xPos, int yPos, Color color, int radius)
    {
      int xCoord = Constants.CoordinateDictionary[drawTileCounter].x;
      int yCoord = Constants.CoordinateDictionary[drawTileCounter].y;
      Tile tempPicBox = new Tile(graphics, xPos, yPos, xCoord, yCoord, color, radius);
      tileArray[xCoord, yCoord] = tempPicBox;
      tileArray[xCoord, yCoord].Callback += HandleClick;
      tileArray[xCoord, yCoord].SetPiece(Properties.Resources.Blank);
      Controls.Add(tileArray[xCoord, yCoord]);
      IncrementCounters();
    }

    //private void DrawInventoryTile(Graphics graphics, int xCoord, int yCoord, Color color, int radius)
    //{
    //	Tile tempPicBox = new Tile(graphics, xCoord, yCoord, xCoord, yCoord, color, radius);
    //	tileArray[xCoord, yCoord] = tempPicBox;
    //	IncrementCounters();
    //}



    void IncrementCounters()
    {
      xCounter++;
      if (xCounter > 7)
      {
        xCounter = 0;
        yCounter++;
      }
      drawTileCounter++;
    }

    public void DrawPiece(String pieceName, int x, int y)
    {
      Image img = Constants.PieceDictionary[pieceName].Item1;
      tileArray[x, y].SetPiece(img);
      Controls.Add(tileArray[x, y]);
      piecesArray[x, y] = new ColouredPiece(Constants.PieceDictionary[pieceName].Item2(x, y), pieceName.Substring(0, 1) == "W" ? true : false);
    }

    public void TakePiece(Image img, int x, int y, bool isBlack)
    {
      if (tileArray[x, y].BackgroundImage != null) // JESSE - NOT WORKING
      {
        //if (isBlack)
        //{
        //	AddToWhiteInventory(tileArray[x, y].BackgroundImage);
        //}
        //else
        //{
        //	AddToBlackInventory(tileArray[x, y].BackgroundImage);
        //}
      }

      tileArray[x, y].RemovePiece();
      tileArray[x, y].SetPiece(img);
    }

    //public void AddToWhiteInventory(Image img) // JESSE - NOT WORKING
    //{
    //	whiteInventoryPieces.Add(new PictureBox());
    //	whiteInventoryPieces[^1].Size = new Size(radius, radius);
    //	whiteInventoryPieces[^1].BackgroundImageLayout = ImageLayout.Zoom;
    //	whiteInventoryPieces[^1].BackColor = Color.Transparent;
    //	whiteInventoryPieces[^1].Location = new Point(whiteInventoryX, whiteInventoryY);
    //	Controls.Add(blackInventoryPieces[^1]);

    //	whiteInventoryPieces[^1].BackgroundImage = img;
    //	whiteInventoryPieces[^1].BringToFront();
    //	whiteInventoryPieces[^1].Refresh();
    //	whiteInventoryY += 100;
    //}

    //public void AddToBlackInventory(Image img) // JESSE - NOT WORKING
    //{
    //	blackInventoryPieces.Add(new PictureBox());
    //	blackInventoryPieces[^1].Size = new Size(100, 100);
    //	blackInventoryPieces[^1].BackgroundImageLayout = ImageLayout.Zoom;
    //	blackInventoryPieces[^1].BackColor = Color.Transparent;
    //	blackInventoryPieces[^1].Location = new Point(blackInventoryX, blackInventoryY);
    //	Controls.Add(blackInventoryPieces[^1]);

    //	blackInventoryPieces[^1].BackgroundImage = img;
    //	blackInventoryPieces[^1].BringToFront();
    //	blackInventoryPieces[^1].Refresh();
    //	blackInventoryY += 100;
    //}




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



    List<(int, int, Color)> lastHighlighted = new List<(int, int, Color)>();
    public void HighlightPieces(List<(int, int, Color)> highlightList)
    {
      Graphics graphics = this.CreateGraphics();
      ResetHighlightedPieces();
      lastHighlighted = highlightList;

      for (int i = 0; i < highlightList.Count; i++)
      {
        tileArray[highlightList[i].Item1, highlightList[i].Item2].FillTile(highlightList[i].Item3, graphics);
        tileArray[highlightList[i].Item1, highlightList[i].Item2].isHighlighted = true;
      }
      graphics.Dispose();
    }

    public void ResetHighlightedPieces()
    {
      RemoveHighlights(lastHighlighted);
    }

    public void RemoveHighlights(List<(int, int, Color)> lastList)
    {
      Graphics graphics = this.CreateGraphics();
      lastHighlighted = new List<(int, int, Color)>();

      for (int i = 0; i < lastList.Count; i++)
      {
        tileArray[lastList[i].Item1, lastList[i].Item2].ResetTile(graphics);
        tileArray[lastList[i].Item1, lastList[i].Item2].isHighlighted = false;
      }
      graphics.Dispose();
    }

    public void RedrawStartPositions()
    {

      numBlackPiecesTaken = 0;
      numWhitePiecesTaken = 0;

      // BLACK PIECES
      DrawPiece("B_King", 7, 7);
      DrawPiece("B_Queen", 6, 6);
      DrawPiece("B_Bishop", 7, 6);
      DrawPiece("B_Bishop", 6, 7);
      DrawPiece("B_Rook", 5, 7);
      DrawPiece("B_Rook", 6, 5);
      DrawPiece("B_Knight", 7, 5);
      DrawPiece("B_Knight", 5, 6);

      DrawPiece("B_Pawn", 7, 4);
      DrawPiece("B_Pawn", 6, 4);
      DrawPiece("B_Pawn", 5, 4);
      DrawPiece("B_Pawn", 4, 4);
      DrawPiece("B_Pawn", 5, 5);
      DrawPiece("B_Pawn", 4, 5);
      DrawPiece("B_Pawn", 4, 6);
      DrawPiece("B_Pawn", 4, 7);


      // WHITE PIECES
      DrawPiece("W_King", 0, 0);
      DrawPiece("W_Queen", 1, 1);
      DrawPiece("W_Bishop", 1, 0);
      DrawPiece("W_Bishop", 0, 1);
      DrawPiece("W_Rook", 2, 0);
      DrawPiece("W_Rook", 1, 2);
      DrawPiece("W_Knight", 2, 1);
      DrawPiece("W_Knight", 0, 2);

      DrawPiece("W_Pawn", 3, 0);
      DrawPiece("W_Pawn", 3, 1);
      DrawPiece("W_Pawn", 3, 2);
      DrawPiece("W_Pawn", 3, 3);
      DrawPiece("W_Pawn", 2, 2);
      DrawPiece("W_Pawn", 2, 3);
      DrawPiece("W_Pawn", 1, 3);
      DrawPiece("W_Pawn", 0, 3);
    }
  }
}
