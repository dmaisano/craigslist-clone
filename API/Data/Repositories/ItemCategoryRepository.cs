using AutoMapper;

namespace API.Data.Repositories
{
    public interface IItemCategoryRepository
    {
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
    }
}
