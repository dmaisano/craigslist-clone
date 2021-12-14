using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    [Table("Users")]
    public class AppUser
    {
        [Required] public int Id { get; set; }
        [Required] public string UserName { get; set; }
        [Required] [EmailAddress] public string Email { get; set; }
        [Required] public byte[] PasswordHash { get; set; }
        [Required] public byte[] PasswordSalt { get; set; }
        [Required] public string City { get; set; }
        [Required] public UserRole Role { get; set; }
        [Required] public DateTime CreatedOn { get; set; } = DateTime.Now;
        [Required] public DateTime UpdatedOn { get; set; } = DateTime.Now;
    }

    public enum UserRole
    {
        Admin,
        User,
    }
}
