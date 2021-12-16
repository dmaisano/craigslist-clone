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

        public DateTime CreatedOn { get; set; } = DateTime.Now;

        [Required]
        public ItemCondition Condition { get; set; }

        public bool Archived { get; set; } // ? Item could be sold or deleted by the user

        public ICollection<ItemImage> Images { get; set; }

        [NotMapped]
        public string OwnerEmail { get; set; }


        [ForeignKey("CategoryName")]
        public string CategoryName { get; set; }
        public ItemCategory Category { get; set; }

        [ForeignKey("Owner")]
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
