using diamond_chess_server.Models;
using diamond_chess_server.DataLayer.DataAccess;

namespace diamond_chess_server.Services
{
  public static class LoginService
  {

    public static Boolean isValidLogin(LoginDetails userLogin) {

      DataAccess dbConnection = new DataAccess();
      Player potentialUser = dbConnection.ValidateLogin(userLogin);

      return potentialUser != null;//return Player instead? handle error here?

    }

  }
}
