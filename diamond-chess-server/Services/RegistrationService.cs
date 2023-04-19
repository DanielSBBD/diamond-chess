using diamond_chess_server.Models;
using diamond_chess_server.DataLayer.DataAccess;

namespace diamond_chess_server.Services
{
  public static class RegistrationService
  {

    public static async Task<Boolean> RegisterUser(Player newUser) {

      DataAccess dbConnection = new DataAccess();
      string rowsAffected = await dbConnection.RegisterPlayer(newUser);

      return Int16.Parse(rowsAffected) == 1;//handle cases when >1 or <1 rows affected here?

    }

  }
}
