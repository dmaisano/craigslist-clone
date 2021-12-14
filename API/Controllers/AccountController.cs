using System.Security.Cryptography;
using System.Text;
using API.Data;
using API.Data.Repositories;
using API.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepo;
        public AccountController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _userRepo = _unitOfWork.UserRepository;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            var username = registerDto.Username.ToLower();
            var email = registerDto.Username.ToLower();

            if (await _userRepo.UserExistsAsync(username, email)) return BadRequest("User already exists");

            try
            {
                // ? Hash and salt the user's creds
                using var hmac = new HMACSHA512();
                var user = new AppUser
                {
                    UserName = username,
                    Email = email,
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
                    PasswordSalt = hmac.Key,
                    City = registerDto.City,
                    Role = UserRole.User,
                };

                await _userRepo.AddUserAsync(user);
                var savedChanges = await _unitOfWork.Complete();

                if (!savedChanges)
                {
                    throw new Exception("Failed to create user");
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return new UserDto
            {
                Username = username,
                Token = "NOT IMPLEMENTED",
            };
        }
    }
}
