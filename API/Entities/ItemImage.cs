using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    [Table("ItemImages")]
    public class ItemImage
    {
        public int Id { get; set; }

        [Required]
        [Url(ErrorMessage = "Invalid Image URL")]
        public string Url { get; set; }

        public string PublicId { get; set; }

        public bool IsMain { get; set; }

        public int ItemListingId { get; set; }
        public ItemListing ItemListing { get; set; }

        public int OwnerId { get; set; }
        public AppUser Owner { get; set; }
    }
}
