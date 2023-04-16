namespace diamond_chess_server.Models
{
    [Serializable]
    public sealed class LoginDetails
    {
        public string Username { get; set; }

        public byte[] PasswordHash { get; set; }
    }
}
