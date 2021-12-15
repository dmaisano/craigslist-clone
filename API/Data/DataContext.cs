using API.DTOs;
using API.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<AppUser> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AppUser>()
               .Property(e => e.Role)
               .HasConversion(new EnumToStringConverter<UserRole>());
            builder.Entity<AppUser>()
               .Property(e => e.Role)
               .HasDefaultValue(UserRole.Member);

            builder.Entity<AppUser>()
               .Property(e => e.CreatedOn)
               .HasDefaultValueSql("datetime('now')");
            builder.Entity<AppUser>()
               .Property(e => e.UpdatedOn)
               .HasDefaultValueSql("datetime('now')");

            builder.Entity<AppUser>()
                .HasIndex(e => e.UserName)
                .IsUnique();
            builder.Entity<AppUser>()
                .HasIndex(e => e.Email)
                .IsUnique();

            var passwordHash = new byte[] { };
            var passwordSalt = new byte[] { };

            var seedMembers = new List<MemberDto>
            {
                new MemberDto {
                    Id = 1,
                    Username = "admin",
                    Email = "admin@domain.com",
                    Password = "admin",
                    City = "Holmdel, NJ",
                    Role = UserRole.Admin,
                },
                new MemberDto {
                    Id = 2,
                    Username = "member",
                    Email = "member@domain.com",
                    Password = "member",
                    City = "Holmdel, NJ",
                }
            };

            var seedUsers = seedMembers.Select(m =>
            {
                var secureCreds = PasswordSerialization.HashPassword(m.Password);

                return new AppUser
                {
                    Id = m.Id,
                    UserName = m.Username,
                    Email = m.Email,
                    PasswordHash = secureCreds.PasswordHash,
                    PasswordSalt = secureCreds.PasswordSalt,
                    City = m.City,
                    Role = m.Role,
                };
            }).ToArray();

            builder.Entity<AppUser>()
                .HasData(seedUsers);
        }
    }
}
