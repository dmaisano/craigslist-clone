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
               .HasConversion(
                   new EnumToStringConverter<UserRole>()
               );
            builder.Entity<AppUser>()
               .Property(e => e.Role)
               .HasDefaultValue(UserRole.User);
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
        }
    }
}
