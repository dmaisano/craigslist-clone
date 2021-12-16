using API.DTOs;
using API.Services;
using AutoMapper;

namespace API.Data.Repositories
{
    public interface IItemListingRepository
    {

    }

    public class ItemListingRepository : IItemListingRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IPhotoService _photoService;
        public ItemListingRepository(DataContext context, IMapper mapper,
            IPhotoService photoService)
        {
            _context = context;
            _mapper = mapper;
            _photoService = photoService;
        }

        public async Task<ItemListingDto> AddNewItem(AddItemListingDto dto, int userId)
        {
            var itemToReturn = new ItemListingDto();
            var imagesToReturn = new List<PhotoDto>();
            var errors = new Dictionary<string, string>();
            using var transaction = await _context.Database.BeginTransactionAsync();
            var savepoint = "";

            try
            {
                var itemListing = new ItemListing
                {
                    Title = dto.Title,
                    Price = dto.Price,
                    Description = dto.Description,
                    Condition = dto.Condition,
                    Images = new List<ItemImage>(),
                    CategoryName = dto.CategoryName,
                    OwnerId = userId,
                };
                await _context.AddAsync(itemListing);
                await _context.SaveChangesAsync();

                savepoint = "BeforeInsertItemImages";
                await transaction.CreateSavepointAsync(savepoint);

                for (int i = 0; i < dto.FileImages.Count; i++)
                {
                    var fileImage = dto.FileImages[i];
                    var result = await _photoService.AddPhotoAsync(fileImage);

                    if (result.Error != null)
                    {
                        errors.Add(fileImage.FileName, result.Error.Message);
                    }

                    var image = new ItemImage
                    {
                        Url = result.Url.AbsoluteUri,
                        PublicId = result.PublicId,
                        IsMain = i == 0,
                        ItemListingId = itemListing.Id,
                        OwnerId = userId,
                    };

                    await _context.AddAsync(image);
                    await _context.SaveChangesAsync();
                    imagesToReturn.Add(_mapper.Map<PhotoDto>(image));

                    savepoint = $"BeforeInsertItemImage{i}";
                    await transaction.CreateSavepointAsync(savepoint);
                }

                await transaction.CommitAsync();

                itemToReturn = new ItemListingDto
                {
                    Id = itemListing.Id,
                    Title = itemListing.Title,
                    Price = itemListing.Price,
                    Description = itemListing.Description,
                    Condition = itemListing.Condition,
                    Archived = itemListing.Archived,
                    CategoryName = itemListing.CategoryName,
                    Images = imagesToReturn,
                };
            }
            catch (Exception)
            {
                transaction.RollbackToSavepoint(savepoint);
            }

            return itemToReturn;
        }
    }
}
