using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API.Entities
{
    [Table("ItemListings")] // ? If this was an e-commerce store I would just call this products or something
    public class ItemListing
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [Column(TypeName = "Number")]
        public double Price { get; set; }

        public string Description { get; set; } // ? If a user was really lazy they might omit a description (not recommended), making this optional

        public DateTime CreatedOn { get; set; } = DateTime.Now;

        [Required]
        public ItemCondition Condition { get; set; } = ItemCondition.Fair;

        public ICollection<ItemImage> Images { get; set; }


        public string CategoryName { get; set; }
        public ItemCategory Category { get; set; }

        public int OwnerId { get; set; }
        public AppUser Owner { get; set; }
    }

    public enum ItemCondition
    {
        New,
        LikeNew,
        Excellent,
        Good,
        Fair,
        Salvage,
    }
}
