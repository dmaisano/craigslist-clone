namespace API.Model
{
    public class SerializedPassword
    {
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}
