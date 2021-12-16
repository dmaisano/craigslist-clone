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
        public DbSet<ItemCategory> Categories { get; set; }
        public DbSet<ItemListing> ItemListings { get; set; }

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

            var passwordHash = new byte[] { };
            var passwordSalt = new byte[] { };

            var seedMembers = new List<MemberDto>
            {
                new MemberDto {
                    Id = 1,
                    Username = "admin",
                    Email = "admin@domain.net",
                    Password = "admin",
                    Role = UserRole.Admin,
                },
                new MemberDto {
                    Id = 2,
                    Username = "member",
                    Email = "member@domain.net",
                    Password = "member",
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
                    Role = m.Role,
                };
            }).ToArray();

            // builder.Entity<ItemListing>()
            //     .Property(e => e.Condition)
            //     .HasConversion(new EnumToStringConverter<ItemCondition>());
            // builder.Entity<ItemListing>()
            //    .Property(e => e.Condition)
            //    .HasDefaultValue(ItemCondition.Fair);

            builder.Entity<ItemCategory>()
                .Property(x => x.Name)
                .UseCollation("NOCASE"); // ? Case-insensitive comparisons

            builder.Entity<ItemListing>()
                .Property(x => x.CategoryName)
                .UseCollation("NOCASE"); // ? Case-insensitive comparisons


            builder.Entity<ItemListing>()
               .Property(e => e.CreatedOn)
               .HasDefaultValueSql("datetime('now')");

            builder.Entity<ItemListing>()
                .Property(e => e.Archived)
                .HasDefaultValue(false);

            builder.Entity<ItemListing>()
                .HasOne(i => i.Category)
                .WithMany(c => c.ItemListings)
                .HasForeignKey(i => i.CategoryName)
                .HasPrincipalKey(c => c.Name)
                .OnDelete(DeleteBehavior.Cascade);

            // ? Reference: https://docs.microsoft.com/en-us/ef/core/modeling/data-seeding
            builder.Entity<AppUser>()
                .HasData(seedUsers);

            var categories = new List<ItemCategory>
            {
                new ItemCategory { Name = "Electronics" },
                new ItemCategory { Name = "Furniture" },
            };
            builder.Entity<ItemCategory>()
                .HasData(categories);

            var items = new List<ItemListing>
            {
                new ItemListing
                {
                    Id = 1,
                    Title = "Round Folding Dining Table",
                    Price = 50.00,
                    Description = "Round folding dining table from Bob's Furniture Store.\nGreat for smaller dining areas/apartments. Smoke-free home.\n\nAsking price - $50.",
                    Condition = ItemCondition.Excellent,
                    OwnerId = 2,
                    CategoryName = "Furniture",
                },
                new ItemListing
                {
                    Id = 2,
                    Title = "Brand New 55\" inch TCL - 4K UHD Smart Roku TV",
                    Price = 330.00,
                    Description = "Absolutely brand new in the box (unopened box) 55 inch TCL 4K UHD Smart Roku TV.\n.Condition: Brand New In the (unopened). Same condition as you get from a store. Price: $330 Cash and Pick up only.",
                    Condition = ItemCondition.New,
                    OwnerId = 2,
                    CategoryName = "Electronics",
                },
            };
            builder.Entity<ItemListing>()
                .HasData(items);

            var images = new List<ItemImage>()
            {
                new ItemImage
                {
                    Id = 1,
                    Url = "https://res.cloudinary.com/dub1phgqv/image/upload/v1639551491/folding_table_rgrmom.jpg",
                    PublicId = "tcl_tv_ufvgvz",
                    IsMain = true,
                    OwnerId = 2,
                    ItemListingId = 1,
                },
                new ItemImage
                {
                    Id = 2,
                    Url = "https://res.cloudinary.com/dub1phgqv/image/upload/v1639551492/tcl_tv_ufvgvz.jpg",
                    PublicId = "folding_table_rgrmom",
                    IsMain = true,
                    OwnerId = 2,
                    ItemListingId = 2,
                }
            };
            builder.Entity<ItemImage>()
                .HasData(images);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }
    }
}
