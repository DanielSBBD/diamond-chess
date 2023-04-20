using System.Data.SqlClient;

namespace diamond_chess_server.DataLayer
{
    public class TestConnection
    {
        private static async Task<bool> TestDBConnection(SqlConnection conn)
        {
            using (conn)
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT 1", conn);

                    cmd.ExecuteScalar();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }

            }
        }

        public static async Task<bool> IsValidConnection(SqlConnection conn)
        {
            var testCon = TestDBConnection(conn);

            if (await Task.WhenAny(testCon, Task.Delay(1500)) == testCon)
            {
                // the task completed within 1.5 seconds
                return true;
            }
            else
            {
                // the task did not complete within 1.5 seconds
                return false; // set the result to a default value
            }

            return false;
        }
    }
}
