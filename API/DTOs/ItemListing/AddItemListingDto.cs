using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace API.DTOs
{
    public class AddItemListingDto
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public double Price { get; set; }

        public string Description { get; set; }

        [Required]
        public ItemCondition Condition { get; set; }

        public IFormFileCollection FileImages { get; set; }

        [Required]
        public string CategoryName { get; set; }

        [JsonIgnore]
        public int OwnerId { get; set; }
    }
}
