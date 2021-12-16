namespace API.DTOs
{
    public class PhotoDto
    {
        public int Id { get; set; }

        public string Url { get; set; }

        public bool IsMain { get; set; }

        public PhotoDto() { }

        public PhotoDto(ItemImage itemImage)
        {
            Id = itemImage.Id;
            Url = itemImage.Url;
            IsMain = itemImage.IsMain;
        }
    }
}
