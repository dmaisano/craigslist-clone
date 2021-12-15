using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    [Table("Images")]
    public class ItemImage
    {
        public int Id { get; set; }

        [Required]
        [Url(ErrorMessage = "Invalid Image URL")]
        public string PublicUrl { get; set; }

        public int ItemListingId { get; set; }
        public ItemListing ItemListing { get; set; }
    }
}
