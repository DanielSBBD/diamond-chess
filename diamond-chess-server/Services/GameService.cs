using diamond_chess_server.DataLayer.DataAccess;
using diamond_chess_server.Models;
using Microsoft.AspNetCore.Mvc;

namespace diamond_chess_server.Services
{
  public static class GameService
  {
    internal static bool Save(GameState game)
    {
      DataAccess dbConnection = new DataAccess();
      bool result = dbConnection.SaveGame(game);
      return result;
    }

    internal static GameState GetGame(int matchId)
    {
      DataAccess dbConnection = new DataAccess();
      return dbConnection.GetGame(matchId);
    }
  }
}
