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
            var email = registerDto.Email.ToLower();

            if (registerDto.Password != registerDto.ConfirmPassword) return BadRequest("Passwords do not match");

            if (await _userRepo.UserExistsAsync(username)) return StatusCode(StatusCodes.Status403Forbidden, new
            {
                error = "User already exists"
            });

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
            var usernameOrEmail = loginDto.UsernameOrEmail.ToLower();
            var user = await _unitOfWork.UserRepository.GetUserByUsernameOrEmail(usernameOrEmail);

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
