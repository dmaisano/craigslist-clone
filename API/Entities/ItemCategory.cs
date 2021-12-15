using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    [Table("Categories")]
    public class ItemCategory
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<ItemListing> ItemListings { get; set; }
    }
}
