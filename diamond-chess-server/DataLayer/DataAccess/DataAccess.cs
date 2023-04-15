using diamond_chess_server.DataLayer.Contracts;
using diamond_chess_server.Models;
using System.Data.SqlClient;
using System.Numerics;

namespace diamond_chess_server.DataLayer.DataAccess
{
    public class DataAccess : IDataAccess
    {
        private string connection;

        public DataAccess()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            connection = builder.GetSection("ConnectionStrings : DefaultConnection").Value;
        }

        public string InsertMatchHistory(MatchHistory match)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connection))
                {
                    using (SqlCommand cmd = new SqlCommand("uspInsertMatch", con))
                    {
                        cmd.Parameters.AddWithValue("pWhite", match.White);
                        cmd.Parameters.AddWithValue("pBlack", match.Black);
                        cmd.Parameters.AddWithValue("mOutcome", match.Outcome);
                        cmd.Parameters.AddWithValue("mDuration", match.Duration);

                        string insertMatch = cmd.ExecuteNonQuery().ToString();

                        return insertMatch;
                    }
                }
            }
            catch (Exception)
            {
                //TODO: Handle expected exceptions.
                throw;
            }
        }

        public string RegisterPlayer(Player playerInfo)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connection))
                {
                    using (SqlCommand cmd = new SqlCommand("uspRegisterPlayer", con))
                    {
                        cmd.Parameters.AddWithValue("pUsername", playerInfo.playerLogin.Username);
                        cmd.Parameters.AddWithValue("pPassword", playerInfo.playerLogin.Password);
                        cmd.Parameters.AddWithValue("pName", playerInfo.Name);
                        cmd.Parameters.AddWithValue("pSurname", playerInfo.Surname );

                        string registerPlayer = cmd.ExecuteNonQuery().ToString();

                        return registerPlayer;
                    }
                }
            }
            catch (Exception)
            {
                //TODO: Handle expected exceptions.
                throw;
            }
        }

        public Player? ValidateLogin(LoginDetails playerLogin)
        {
            Player player = null;

            try
            {
                using (SqlConnection con = new SqlConnection(connection))
                {
                    using (SqlCommand cmd = new SqlCommand("uspLogin", con))
                    {
                        cmd.Parameters.AddWithValue("pUsername", playerLogin.Username);
                        cmd.Parameters.AddWithValue("pPassword", playerLogin.Password);

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                if (reader is not null)
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
            catch (Exception)
            {
                //TODO: Handle expected exceptions.
                throw;
            }
            return player;
            
        }
    }
}
