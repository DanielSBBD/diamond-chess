using diamond_chess_server.Models;
using System;
namespace DiamondChess
{
  class Test
  {
    static void Main()
    {
      // Define the board
      bool?[,] board = new bool?[8, 8];
      // Add the piece to be tested
      Knight r = new Knight(3, 3);
      // Add an enemy
      board[2, 2] = true;
      // Add an ally
      board[4, 4] = false;

      // Test the piece
      r.GetValidMoves(board).ForEach(validMove => Console.WriteLine($"({validMove.posX}, {validMove.posY}) {validMove.isOccupied}"));
    }
  }
}