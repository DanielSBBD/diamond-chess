using System.ComponentModel;

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

    Tile[,] whiteInventoryTiles = new Tile[Constants.InventoryWidth, Constants.InventoryHeight];
    Tile[,] blackInventoryTiles = new Tile[Constants.InventoryWidth, Constants.InventoryHeight];

    int numBlackPiecesTaken = 0;
    int numWhitePiecesTaken = 0;

    public event EventHandler<int> RaiseTurnChangeEvent;

    Tile[,] tileArray = new Tile[Constants.GridSize, Constants.GridSize];
    ColouredPiece?[,] piecesArray = new ColouredPiece?[Constants.GridSize, Constants.GridSize];

    public Dictionary<int, (int x, int y)> PositionDictionary = new Dictionary<int, (int, int)>();
    int xCounter = 0;
    int yCounter = 0;
    int drawTileCounter = 0;
    int whiteInventoryCounter = 0;
    int blackInventoryCounter = 0;

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
          AddToInventory(tileArray[x, y].BackgroundImage, isWhitesTurn);
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
            else
            {
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




    public Grid()
    {
      this.Size = new Size(1552, 840);
      int radius = Width / 32;

      Graphics graphics = this.CreateGraphics();
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

      for (int i = 0; i < Constants.InventoryWidth; i++)
      {
        for (int j = 0; j < Constants.InventoryHeight; j++)
        {
          DrawWhiteInventoryTile(graphics, i, j, radius);
          DrawBlackInventoryTile(graphics, i, j, radius);
        }
      }
      graphics.Dispose();


    }



    protected override void OnPaint(PaintEventArgs e)
    {
      base.OnPaint(e);


      for (int i = 0; i < Constants.GridSize; i++)
      {
        for (int j = 0; j < Constants.GridSize; j++)
        {
          Color tempColour = new Color();
          if ((i + j) % 2 == 0)
          {
            tempColour = Constants.DarkColour;
          }
          else
          {
            tempColour = Constants.LightColour;
          }
          tileArray[i, j].FillTile(tempColour, e.Graphics);
        }

      }

      e.Graphics.Dispose();

    }

    private void DrawTile(Graphics graphics, int xPos, int yPos, Color color, int radius)
    {

      int xCoord = Constants.CoordinateDictionary[drawTileCounter].x;
      int yCoord = Constants.CoordinateDictionary[drawTileCounter].y;
      Tile tempPicBox = new Tile(xPos, yPos, xCoord, yCoord, color, radius);
      tileArray[xCoord, yCoord] = tempPicBox;
      tileArray[xCoord, yCoord].Callback += HandleClick;
      tileArray[xCoord, yCoord].SetPiece(Properties.Resources.Blank);
      Controls.Add(tileArray[xCoord, yCoord]);
      IncrementCounters();
    }

    private void DrawWhiteInventoryTile(Graphics graphics, int xCoord, int yCoord, int radius)
    {

      int xPos = 0;
      int yPos = 0;
      (xPos, yPos) = Constants.InventoryDictionary[(xCoord, yCoord)];
      Tile tempPicBox = new Tile(xPos, yPos, xCoord, yCoord, Color.Transparent, radius);
      whiteInventoryTiles[xCoord, yCoord] = tempPicBox;
      Controls.Add(whiteInventoryTiles[xCoord, yCoord]);
    }
    private void DrawBlackInventoryTile(Graphics graphics, int xCoord, int yCoord, int radius)
    {
      int xPos = 0;
      int yPos = 0;
      (xPos, yPos) = Constants.InventoryDictionary[(xCoord + 3, yCoord)];
      Tile tempPicBox = new Tile(xPos, yPos, xCoord, yCoord, Color.Transparent, radius);
      blackInventoryTiles[xCoord, yCoord] = tempPicBox;
      Controls.Add(blackInventoryTiles[xCoord, yCoord]);
    }

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



    public void AddToInventory(Image img, bool isWhite)
    {
      if (isWhite)
      {
        whiteInventoryTiles[(int)whiteInventoryCounter / Constants.InventoryHeight, whiteInventoryCounter % Constants.InventoryHeight].SetPiece(img);
        whiteInventoryCounter++;
        if (whiteInventoryCounter >= 15)
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
