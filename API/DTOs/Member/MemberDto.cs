using System.Text.Json.Serialization;

namespace API.DTOs
{
    public class MemberDto
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        [JsonIgnore]
        public string Password { get; set; }

        [JsonIgnore]
        public UserRole Role { get; set; } = UserRole.Member;

        public DateTime CreatedOn { get; set; } = DateTime.Now;

        public DateTime UpdatedOn { get; set; } = DateTime.Now;
    }
}
