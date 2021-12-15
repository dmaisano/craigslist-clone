using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    [Table("Users")]
    public class AppUser
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public byte[] PasswordHash { get; set; }

        [Required]
        public byte[] PasswordSalt { get; set; }

        // ? For a small demo, having a field like City seems like a hassle to keep track of. Trying to keep functionality as minimal as possible
        // [Required]
        // public string City { get; set; }

        [Required]
        public UserRole Role { get; set; } = UserRole.Member;

        [Required]
        public DateTime CreatedOn { get; set; } = DateTime.Now;

        [Required]
        public DateTime UpdatedOn { get; set; } = DateTime.Now;

        public ICollection<ItemListing> ItemListings { get; set; }

        public ICollection<ItemImage> ItemListingImages { get; set; }
    }

    public enum UserRole
    {
        Member,
        Admin,
    }
}
