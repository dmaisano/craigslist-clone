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
        Task<AppUser> GetUserByEmailOrUsernameAsync(string usernameOrEmail);
        Task<bool> UserExistsAsync(string username = null, string email = null);
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

        public async Task<AppUser> GetUserByEmailOrUsernameAsync(string usernameOrEmail)
        {
            usernameOrEmail = usernameOrEmail.ToLower();
            return await _context.Users
                .SingleOrDefaultAsync(x => x.UserName == usernameOrEmail || x.Email == usernameOrEmail);
        }

        // ? I could overload this method and provide optional params for narrowing search results and reduce overfetching
        public async Task<IEnumerable<MemberDto>> GetMembersAsync()
        {
            return await _context.Users
                .OrderByDescending(x => x.Id)
                .ProjectTo<MemberDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<bool> UserExistsAsync(string username = null, string email = null)
        {
            var userQuery = _context.Users.AsQueryable();

            if (username != null)
            {
                username = username.ToLower();
                var queryResult = await userQuery.AnyAsync(x => x.UserName == username);

                if (queryResult) return true;
            }

            if (email != null)
            {
                email = username.ToLower();
                var queryResult = await userQuery.AnyAsync(x => x.Email == email);

                if (queryResult) return true;
            }

            return false;
        }
    }
}
