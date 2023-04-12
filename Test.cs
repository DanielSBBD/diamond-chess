using System;
namespace DiamondChess
{
  class Test
  {
    static void Main()
    {
      // Define a Pawn
      Pawn p = new Pawn();
      bool?[,] board = new bool?[8, 8];

      // Add an enemy
      board[2, 2] = true;
      // Add an ally
      board[4, 4] = false;

      // Pawn starts in position (0, 0)
      // Recalculate valid moves for pawn
      p.recalculateValidMoves(board);
      // Show valid moves
      Console.WriteLine("Valid moves when in position (0, 0):");
      p.getValidMoves().ForEach(validMove => Console.WriteLine($"({validMove.posX}, {validMove.posY}) {validMove.isOccupied}"));

      // Move pawn in front of enemy
      p.move(1, 1);
      // Recalculate valid moves for pawn
      p.recalculateValidMoves(board);
      // Show valid moves
      Console.WriteLine("Valid moves when in position (1, 1):");
      p.getValidMoves().ForEach(validMove => Console.WriteLine($"({validMove.posX}, {validMove.posY}) {validMove.isOccupied}"));

      // Move pawn in front of ally
      p.move(3, 3);
      // Recalculate valid moves for pawn
      p.recalculateValidMoves(board);
      // Show valid moves
      Console.WriteLine("Valid moves when in position (3, 3):");
      p.getValidMoves().ForEach(validMove => Console.WriteLine($"({validMove.posX}, {validMove.posY}) {validMove.isOccupied}"));
    }
  }
}