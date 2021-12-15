using System.Security.Cryptography;
using System.Text;
using API.Data;
using API.Data.Repositories;
using API.DTOs;
using API.Services;
using API.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepo;
        private readonly ITokenService _tokenService;
        public AccountController(IUnitOfWork unitOfWork, ITokenService tokenService)
        {
            _tokenService = tokenService;
            _unitOfWork = unitOfWork;
            _userRepo = _unitOfWork.UserRepository;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            var username = registerDto.Username.ToLower();
            var email = registerDto.Username.ToLower();

            if (await _userRepo.UserExistsAsync(username, email)) return BadRequest("User already exists");

            var user = new AppUser();
            try
            {
                var secureCreds = PasswordSerialization.HashPassword(registerDto.Password);

                user = new AppUser
                {
                    UserName = username,
                    Email = email,
                    PasswordHash = secureCreds.PasswordHash,
                    PasswordSalt = secureCreds.PasswordSalt,
                    City = registerDto.City,
                    Role = UserRole.Member,
                };

                await _userRepo.AddUserAsync(user);

                if (!await _unitOfWork.Complete()) throw new Exception("Failed to create user");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return new UserDto
            {
                Username = username,
                Token = _tokenService.CreateToken(user),
            };
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await _userRepo.GetUserByEmailOrUsernameAsync(loginDto.UsernameOrEmail);

            if (user == null) return Unauthorized(); // ? I'm being vague here to not give any details to potential phishers

            var passwordMatch = PasswordSerialization.VerifyPassword(
                loginDto.Password,
                user.PasswordHash,
                user.PasswordSalt
            );

            if (!passwordMatch) return Unauthorized();

            return new UserDto
            {
                Username = user.UserName,
                Token = _tokenService.CreateToken(user),
            };
        }
    }
}
