using API.DTOs;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Repositories
{
    public interface IItemCategoryRepository
    {
        Task<IEnumerable<ItemCategoryDto>> GetAllCategories();
    }

    public class ItemCategoryRepository : IItemCategoryRepository
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public ItemCategoryRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ItemCategoryDto>> GetAllCategories()
        {
            return await _context.Categories
                .ProjectTo<ItemCategoryDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }
    }
}
