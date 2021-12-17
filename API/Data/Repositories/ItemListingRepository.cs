using API.DTOs;
using API.Services;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;

namespace API.Data.Repositories
{
    public interface IItemListingRepository
    {
        Task<IEnumerable<ItemListingDto>> GetAllItemsAsync(string category = null);
        Task<ItemListingDto> GetItemFromIdAsync(int id);
        Task<ItemListingDto> AddNewItemAsync(AddItemListingDto dto, int userId);
        Task<bool> ArchiveItemAsync(int id, int userId);
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

        public async Task<IEnumerable<ItemListingDto>> GetAllItemsAsync(string category = null)
        {
            if (category == null) return new List<ItemListingDto>();

            var items = _context.ItemListings
                .Include(x => x.Images)
                .Include(x => x.Owner)
                .Where(x => !x.Archived && x.CategoryName == category)
                .AsQueryable();

            items = items.Select(x => new ItemListing
            {
                Id = x.Id,
                Title = x.Title,
                Price = x.Price,
                Description = x.Description,
                Condition = x.Condition,
                Archived = x.Archived,
                CategoryName = x.CategoryName,
                OwnerEmail = x.Owner.Email,
                Images = new List<ItemImage> { x.Images.Where(x => x.IsMain).SingleOrDefault() },
            });

            return await items.Select(x => new ItemListingDto(x)).ToListAsync();
        }

        public async Task<ItemListingDto> GetItemFromIdAsync(int id)
        {
            var item = await _context.ItemListings
                .Where(x => x.Id == id && !x.Archived)
                .Include(x => x.Images)
                .Include(x => x.Owner)
                .SingleOrDefaultAsync();

            if (item == null) return null;

            var itemDto = new ItemListingDto(item);
            itemDto.OwnerEmail = item.Owner.Email;

            return itemDto;
        }

        public async Task<ItemListingDto> AddNewItemAsync(AddItemListingDto dto, int userId)
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

                itemToReturn = new ItemListingDto(itemListing, imagesToReturn);
            }
            catch (Exception)
            {
                transaction.RollbackToSavepoint(savepoint);
            }

            return itemToReturn;
        }

        public async Task<bool> ArchiveItemAsync(int id, int userId)
        {
            var itemToDelete = await _context.ItemListings
                .Where(x => x.Id == id && x.OwnerId == userId)
                .FirstOrDefaultAsync();

            if (itemToDelete == null) return false;

            itemToDelete.Archived = true;
            _context.ItemListings.Update(itemToDelete);

            // ? In an ideal scenario I'm assuming it would be better to omit the "SaveChangesAsync()" and call the unit of work complete method if I'm tracking multiple changes in some sort of use-case
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
