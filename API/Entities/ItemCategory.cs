using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    [Table("Categories")]
    public class ItemCategory
    {
        [Key]
        public string Name { get; set; }

        public ICollection<ItemListing> ItemListings { get; set; }
    }
}
