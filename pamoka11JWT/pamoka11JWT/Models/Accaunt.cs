namespace pamoka11JWT.Models
{
    public class Accaunt
    {
        public int id { get; set; }
        public string Username { get; set; }    
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Role { get; set; }    
    }
}
