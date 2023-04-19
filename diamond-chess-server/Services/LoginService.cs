using diamond_chess_server.Models;
using diamond_chess_server.DataLayer.DataAccess;

namespace diamond_chess_server.Services
{
  public static class LoginService
  {

    public static async Task<Boolean> isValidLogin(LoginDetails userLogin) {

      DataAccess dbConnection = new DataAccess();
      Player potentialUser = await dbConnection.ValidateLogin(userLogin);

      return potentialUser != null;//return Player instead? handle error here?

    }

  }
}
