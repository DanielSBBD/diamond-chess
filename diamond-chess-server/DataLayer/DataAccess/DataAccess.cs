using diamond_chess_server.DataLayer.Contracts;
using diamond_chess_server.Models;
using System.Data;
using System.Data.SqlClient;

namespace diamond_chess_server.DataLayer.DataAccess
{
  public class DataAccess : IDataAccess
    {
        public string connection;

        public DataAccess()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            connection = builder.GetConnectionString("DefaultConnection");
            if (!TestConnection.IsValidConnection(new SqlConnection(connection)).Result)
            {
                connection = builder.GetConnectionString("AlternativeConnection");
            }
        }

        public async Task<Player> GetPlayerHistory(Player playerInfo)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connection))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT Wins, Draws, Losses FROM vPlayerScores WHERE player_id = @pId ", con))
                    {
                        con.Open();
                        cmd.Parameters.AddWithValue("@pId", playerInfo.Id);

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (await reader.ReadAsync())
                            {
                                if (reader is not null)
                                {
                                    playerInfo.numWins = Convert.ToInt32(reader["Wins"]);
                                    playerInfo.numDraws = Convert.ToInt32(reader["Draws"]);
                                    playerInfo.numLosses = Convert.ToInt32(reader["Losses"]);
                                }
                                else
                                {
                                    playerInfo.numWins = 0;
                                    playerInfo.numDraws = 0;
                                    playerInfo.numLosses = 0;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                string errorMessage = "Error: " + e.Message.ToString();
                Console.WriteLine(errorMessage);
            }
            return playerInfo;
        }

        public async Task<string?> InsertMatchHistory(MatchHistory match)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connection))
                {
                    using (SqlCommand cmd = new SqlCommand("uspInsertMatch", con))
                    {
                        con.Open();
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@pWhite", match.White.Id);
                        cmd.Parameters.AddWithValue("@pBlack", match.Black.Id);
                        cmd.Parameters.AddWithValue("@mOutcome", match.Outcome);
                        cmd.Parameters.AddWithValue("@mDuration", match.Duration);

                        var responseMessage = cmd.Parameters.Add("@responseMessage", SqlDbType.VarChar, 250);
                        responseMessage.Direction = ParameterDirection.Output;

                        await cmd.ExecuteNonQueryAsync();
                        return responseMessage.Value.ToString();
                    }
                }
            }
            catch (Exception e)
            {
                string errorMessage = "Error: " + e.Message.ToString();
                Console.WriteLine(errorMessage);
                return errorMessage;
            }
        }

        public async Task<string?> RegisterPlayer(Player playerInfo)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connection))
                {
                    using (SqlCommand cmd = new SqlCommand("uspRegisterPlayer", con))
                    {
                        con.Open();
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@pUsername", playerInfo.playerLogin.Username);
                        cmd.Parameters.AddWithValue("@pPassword", BitConverter.ToString(playerInfo.playerLogin.PasswordHash));
                        cmd.Parameters.AddWithValue("@pName", playerInfo.Name);
                        cmd.Parameters.AddWithValue("@pSurname", playerInfo.Surname );

                        var responseMessage = cmd.Parameters.Add("@responseMessage", SqlDbType.VarChar, 250);
                        responseMessage.Direction = ParameterDirection.Output;

                        await cmd.ExecuteNonQueryAsync();
                        return responseMessage.Value.ToString();
                    }
                }
            }
            catch (Exception e)
            {
                string errorMessage = "Error: " + e.Message.ToString();
                Console.WriteLine(errorMessage);
                return errorMessage;
            }
        }

        public async Task<Player> ValidateLogin(LoginDetails playerLogin)
        {
            Player player = new Player();

            try
            {
                using (SqlConnection con = new SqlConnection(connection))
                {
                    using (SqlCommand cmd = new SqlCommand("uspLogin", con))
                    {
                        con.Open();
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@pUsername", playerLogin.Username);
                        cmd.Parameters.AddWithValue("@pPassword", BitConverter.ToString(playerLogin.PasswordHash));

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (await reader.ReadAsync())
                            {
                                if (reader["player_id"] is not null)
                                {
                                    player.Id = Convert.ToInt32(reader["player_id"]);
                                    player.Name = reader["player_name"] as string;
                                    player.Surname = reader["player_surname"] as string;

                                }
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                string errorMessage = "Error: " + e.Message.ToString();
                Console.WriteLine(errorMessage);
            }
            return player;

        }
    }
}
