namespace DiamondChess
{
  public static class Constants
  {
    public static Color DarkColour { get; } = Color.FromArgb(41, 76, 96);
    public static Color LightColour { get; } = Color.FromArgb(173, 182, 196);

    public static int GridSize { get; } = 8;

    public static Dictionary<int, (int x, int y)> CoordinateDictionary = new Dictionary<int, (int x, int y)>()
    {
      {63, (0, 0)},
      {62 , (0, 1)},
      {60 , (0, 2)},
      {57 , (0, 3)},
      {53 , (0, 4)},
      {48 , (0, 5)},
      {42 , (0, 6)},
      {35 , (0, 7)},
      {61 , (1, 0)},
      {59 , (1, 1)},
      {56 , (1, 2)},
      {52 , (1, 3)},
      {47 , (1, 4)},
      {41 , (1, 5)},
      {34 , (1, 6)},
      {27 , (1, 7)},
      {58 , (2, 0)},
      {55 , (2, 1)},
      {51 , (2, 2)},
      {46 , (2, 3)},
      {40 , (2, 4)},
      {33 , (2, 5)},
      {26 , (2, 6)},
      {20 , (2, 7)},
      {54 , (3, 0)},
      {50 , (3, 1)},
      {45 , (3, 2)},
      {39 , (3, 3)},
      {32 , (3, 4)},
      {25 , (3, 5)},
      {19 , (3, 6)},
      {14 , (3, 7)},
      {49 , (4, 0)},
      {44 , (4, 1)},
      {38 , (4, 2)},
      {31 , (4, 3)},
      {24 , (4, 4)},
      {18 , (4, 5)},
      {13 , (4, 6)},
      {9 , (4, 7)},
      {43 , (5, 0)},
      {37 , (5, 1)},
      {30 , (5, 2)},
      {23 , (5, 3)},
      {17 , (5, 4)},
      {12 , (5, 5)},
      {8 , (5, 6)},
      {5 , (5, 7)},
      {36 , (6, 0)},
      {29 , (6, 1)},
      {22 , (6, 2)},
      {16 , (6, 3)},
      {11 , (6, 4)},
      {7 , (6, 5)},
      {4 , (6, 6)},
      {2 , (6, 7)},
      {28 , (7, 0)},
      {21 , (7, 1)},
      {15 , (7, 2)},
      {10 , (7, 3)},
      {6 , (7, 4)},
      {3 , (7, 5)},
      {1 , (7, 6)},
      {0 , (7, 7)},
    };

    public delegate Piece pieceMaker(int x, int y);

    public static Pawn PawnMaker(int x, int y)
    {
      return new Pawn(x, y);
    }
    public static Rook RookMaker(int x, int y)
    {
      return new Rook(x, y);
    }
    public static Bishop BishopMaker(int x, int y)
    {
      return new Bishop(x, y);
    }
    public static Knight KnightMaker(int x, int y)
    {
      return new Knight(x, y);
    }
    public static Queen QueenMaker(int x, int y)
    {
      return new Queen(x, y);
    }
    public static King KingMaker(int x, int y)
    {
      return new King(x, y);
    }

    public static Dictionary<string, (Image, pieceMaker)> PieceDictionary = new Dictionary<string, (Image, pieceMaker)>()
    {
      {"W_Bishop", (Properties.Resources.W_Bishop, BishopMaker) },
      {"W_King", (Properties.Resources.W_King, KingMaker) },
      {"W_Knight", (Properties.Resources.W_Knight, KnightMaker) },
      {"W_Pawn", (Properties.Resources.W_Pawn, PawnMaker) },
      {"W_Queen", (Properties.Resources.W_Queen, QueenMaker) },
      {"W_Rook", (Properties.Resources.W_Rook, RookMaker) },
      {"B_Bishop", (Properties.Resources.B_Bishop, BishopMaker) },
      {"B_King", (Properties.Resources.B_King, KingMaker) },
      {"B_Knight", (Properties.Resources.B_Knight, KnightMaker) },
      {"B_Pawn", (Properties.Resources.B_Pawn, PawnMaker) },
      {"B_Queen", (Properties.Resources.B_Queen, QueenMaker) },
      {"B_Rook", (Properties.Resources.B_Rook, RookMaker) },
    };
  }
}
