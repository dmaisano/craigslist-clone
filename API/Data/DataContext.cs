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
                new ItemCategory { Name = "Sporting" },
                new ItemCategory { Name = "Misc." },
            };
            builder.Entity<ItemCategory>()
                .HasData(categories);

            var items = new List<ItemListing>
            {
                new ItemListing {
                    Id = 1,
                    Title = "Round Folding Dining Table",
                    Price = 50.00,
                    Description = "Lorem ipsum, dolor sit amet consectetur adipisicing elit. Nobis magnam reprehenderit saepe odit ullam, laboriosam, cumque repudiandae nam consequuntur enim labore, accusantium repellendus tempore? Cumque perspiciatis explicabo, cum corrupti provident minus possimus error eos repellendus? Suscipit unde neque alias atque aliquid. Perspiciatis provident dolore obcaecati ipsum tempore ad, reiciendis consequuntur? Expedita alias temporibus, numquam dolore veniam quasi! Alias, rerum quod. Eius perferendis aperiam incidunt, minus totam, dolorem exercitationem a neque explicabo, vitae ipsa provident fugit ea possimus nostrum consectetur magnam non quasi. Accusantium sed voluptatibus delectus quae asperiores eligendi illo consequuntur eum nemo quaerat ad excepturi tempora dolore itaque nisi inventore magni explicabo, suscipit esse doloribus! Molestias animi totam illum doloribus magnam unde est. Blanditiis nisi quos dolorem maiores voluptatem laborum dolor amet, architecto voluptas dignissimos similique assumenda voluptate mollitia veniam eaque officia deleniti tempora ea repellendus. Facere vel pariatur, laborum impedit et maxime, quo molestiae obcaecati doloremque accusantium adipisci?",
                    Condition = ItemCondition.Excellent,
                    OwnerId = 1,
                    CategoryName = "Furniture",
                },
                new ItemListing {
                    Id = 2,
                    Title = "Brand New Canon EOS 60D",
                    Price = 1119.99,
                    Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Autem cupiditate eaque aliquid in velit modi sit obcaecati fuga aperiam quidem. A necessitatibus quaerat facilis tenetur iste, ratione mollitia explicabo eos iure dolorem totam odit vel saepe voluptates, culpa obcaecati, excepturi illo. Inventore soluta provident cum vero, voluptas eaque beatae doloribus labore vel deleniti eius ad est autem sequi officiis. Voluptas, magnam atque numquam hic tenetur optio aut culpa maxime minus inventore, recusandae, aliquid magni quo laboriosam odio pariatur animi? Iusto asperiores saepe voluptate quia. Saepe cupiditate architecto perferendis. Natus nulla amet recusandae excepturi quia unde error provident porro vitae saepe veritatis praesentium earum impedit est corrupti facere facilis enim qui, labore mollitia laudantium ullam magnam. Quidem sint illum ducimus molestiae dolor fugit temporibus libero explicabo!",
                    Condition = ItemCondition.LikeNew,
                    OwnerId = 1,
                    CategoryName = "Electronics",
                },
                new ItemListing {
                    Id = 3,
                    Title = "Vitage Football",
                    Price = 330.00,
                    Description = "'Mint condition'",
                    Condition = ItemCondition.Salvage,
                    OwnerId = 2,
                    CategoryName = "Sporting",
                },
                new ItemListing {
                    Id = 4,
                    Title = "Cup of Coffee",
                    Price = 6.99,
                    Description = "Dunkin's new roast blend. Product is not same as the image shown. I already drank the coffee...\n\nYou can actually disregard this post.",
                    Condition = ItemCondition.Fair,
                    OwnerId = 2,
                    CategoryName = "Misc.",
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
                    PublicId = "folding_table_rgrmom",
                    IsMain = true,
                    OwnerId = 1,
                    ItemListingId = 1,
                },
                new ItemImage
                {
                    Id = 2,
                    Url = "https://res.cloudinary.com/dub1phgqv/image/upload/v1639771116/gtxlx5rfi3b9wmtzakro.jpg",
                    PublicId = "gtxlx5rfi3b9wmtzakro",
                    IsMain = true,
                    OwnerId = 1,
                    ItemListingId = 2,
                },
                new ItemImage
                {
                    Id = 3,
                    Url = "https://res.cloudinary.com/dub1phgqv/image/upload/v1639772129/qhtucrxynkepvpsgn189.jpg",
                    PublicId = "qhtucrxynkepvpsgn189",
                    IsMain = true,
                    OwnerId = 2,
                    ItemListingId = 3,
                },
                new ItemImage
                {
                    Id = 4,
                    Url = "https://res.cloudinary.com/dub1phgqv/image/upload/v1639761761/kfbjlfkldkruumqzgrbs.jpg",
                    PublicId = "kfbjlfkldkruumqzgrbs",
                    IsMain = true,
                    OwnerId = 2,
                    ItemListingId = 4,
                },
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
