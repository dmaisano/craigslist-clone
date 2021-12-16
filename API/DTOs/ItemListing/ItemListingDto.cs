using System.Text.Json.Serialization;

namespace API.DTOs
{
    public class ItemListingDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public double Price { get; set; }

        public string Description { get; set; }

        public ItemCondition Condition { get; set; }

        public bool Archived { get; set; }

        public string CategoryName { get; set; }

        [JsonIgnore]
        public int OwnderId { get; set; }

        public ICollection<PhotoDto> Images { get; set; }

        public Dictionary<string, string> Errors { get; set; }
    }
}
