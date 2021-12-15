using API.Data.Repositories;
using AutoMapper;

namespace API.Data
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        IItemCategoryRepository ItemCategoryRepository { get; }
        ItemListingRepository ItemListingRepository { get; }
        Task<bool> Complete();
        bool HasChanges();
    }

    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public UnitOfWork(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public IUserRepository UserRepository => new UserRepository(_context, _mapper);

        public IItemCategoryRepository ItemCategoryRepository => new ItemCategoryRepository(_context, _mapper);

        public ItemListingRepository ItemListingRepository => new ItemListingRepository(_context, _mapper);

        public async Task<bool> Complete()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public bool HasChanges()
        {
            return _context.ChangeTracker.HasChanges();
        }
    }
}
