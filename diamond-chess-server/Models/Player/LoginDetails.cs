namespace diamond_chess_server.Models
{
    [Serializable]
    public sealed class LoginDetails
    {
        public string Username { get; set; }

        public string Password { get; set; }

        //Not sure if we hash before sending to database.
        public byte[] PasswordHash { get; set; }
    }
}
