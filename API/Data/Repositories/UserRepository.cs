using API.DTOs;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Repositories
{
    public interface IUserRepository
    {
        Task<AppUser> AddUserAsync(AppUser user);
        Task<IEnumerable<MemberDto>> GetMembersAsync();
        Task<AppUser> GetUserByIdAsync(int id);
        Task<AppUser> GetUserByUsernameAsync(string username);
        Task<bool> UserExistsAsync(string username = null);
    }

    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public UserRepository(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<AppUser> AddUserAsync(AppUser user)
        {
            user.UserName = user.UserName.ToLower(); // ? normalizing username
            await _context.Users.AddAsync(user);
            return user;
        }

        public async Task<AppUser> GetUserByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<AppUser> GetUserByUsernameAsync(string username)
        {
            username = username.ToLower();
            return await _context.Users
                .SingleOrDefaultAsync(x => x.UserName == username);
        }

        // ? I could overload this method and provide optional params for narrowing search results and reduce overfetching
        public async Task<IEnumerable<MemberDto>> GetMembersAsync()
        {
            return await _context.Users
                .OrderByDescending(x => x.Id)
                .ProjectTo<MemberDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<bool> UserExistsAsync(string username = null)
        {
            if (username == null) return false;

            return await _context.Users.AnyAsync(x => x.UserName == username);
        }
    }
}
