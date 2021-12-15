using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [Required]
        public ItemCondition Condition { get; set; } = ItemCondition.Fair;

        public ICollection<ItemImage> Images { get; set; }

        // ? I would like to ideally have the PK be an index string "name" for the categories
        // ? For performance I'll just stick to a default auto increment int id
        public int CategoryId { get; set; }
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
