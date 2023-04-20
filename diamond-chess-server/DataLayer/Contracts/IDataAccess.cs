namespace diamond_chess_server.DataLayer.Contracts
{
    using diamond_chess_server.Models;

    public interface IDataAccess
    {
        Task<string?> RegisterPlayer(Player playerInfo);

        Task<Player> ValidateLogin(LoginDetails playerLogin);

        Task<string?> InsertMatchHistory(MatchHistory match);

        Task<Player> GetPlayerHistory(Player playerInfo);

    }
}
