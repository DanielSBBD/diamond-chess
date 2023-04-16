namespace diamond_chess_server.DataLayer.Contracts
{
    using diamond_chess_server.Models;

    public interface IDataAccess
    {
        string RegisterPlayer(Player playerInfo);

        Player? ValidateLogin(LoginDetails playerLogin);

        string InsertMatchHistory(MatchHistory match);

    }
}
