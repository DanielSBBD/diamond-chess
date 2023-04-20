using diamond_chess_server.Models;
using diamond_chess_server.DataLayer.DataAccess;

namespace diamond_chess_server.Services
{
  public static class LoginService
  {

    public static async Task<bool> isValidLogin(LoginDetails userLogin) {

      DataAccess dbConnection = new DataAccess();

      return await dbConnection.ValidateLogin(userLogin);

    }

  }
}
