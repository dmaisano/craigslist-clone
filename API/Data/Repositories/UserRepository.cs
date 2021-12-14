using Microsoft.EntityFrameworkCore;

namespace API.Data.Repositories
{
    public interface IUserRepository
    {
        Task<AppUser> AddUserAsync(AppUser user);
        Task<IEnumerable<AppUser>> GetUsersAsync();
        Task<AppUser> GetUserByIdAsync(int id);
        Task<AppUser> GetUserByEmailOrUsernameAsync(string usernameOrEmail);
        Task<bool> UserExistsAsync(string username = null, string email = null);
    }

    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        public UserRepository(DataContext context)
        {
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

        public async Task<IEnumerable<AppUser>> GetUsersAsync()
        {
            return await _context.Users.ToListAsync();
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
