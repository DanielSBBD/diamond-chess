using diamond_chess_server.Models;
using diamond_chess_server.DataLayer.DataAccess;

namespace diamond_chess_server.Services
{
  public static class RegistrationService
  {

    public static async Task<bool> RegisterUser(Player newUser) {

      DataAccess dbConnection = new DataAccess();
      string rowsAffected = await dbConnection.RegisterPlayer(newUser);

      return rowsAffected == "Successfully registed player.";

    }

  }
}
