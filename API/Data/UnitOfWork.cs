using API.Data.Repositories;
using API.Services;
using AutoMapper;

namespace API.Data
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        IItemCategoryRepository ItemCategoryRepository { get; }
        ItemListingRepository ItemListingRepository { get; }
        Task<AppUser> GetUserByIdAsync(int id);
        Task<AppUser> GetUserByUsernameAsync(string username);
        Task<bool> Complete();
        bool HasChanges();
    }

    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IPhotoService _photoService;
        public UnitOfWork(DataContext context, IMapper mapper, IPhotoService photoService)
        {
            _photoService = photoService;
            _mapper = mapper;
            _context = context;
        }

        public IUserRepository UserRepository => new UserRepository(_context, _mapper);

        public IItemCategoryRepository ItemCategoryRepository => new ItemCategoryRepository(_context, _mapper);

        public ItemListingRepository ItemListingRepository => new ItemListingRepository(_context, _mapper, _photoService);

        public async Task<AppUser> GetUserByIdAsync(int id)
        {
            return await this.UserRepository.GetUserByIdAsync(id);
        }

        public async Task<AppUser> GetUserByUsernameAsync(string username)
        {
            return await this.UserRepository.GetUserByUsernameAsync(username);
        }

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
