using diamond_chess_server.Models;
using diamond_chess_server.DataLayer.DataAccess;

namespace diamond_chess_server.Services
{
  public static class MatchRecordService
  {

    public static async Task<Player> updateRecords(Player player) {

      DataAccess dbConnection = new DataAccess();

      return await dbConnection.GetPlayerHistory(player);

    }

  }
}
