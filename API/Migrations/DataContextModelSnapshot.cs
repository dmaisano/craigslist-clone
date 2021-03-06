// <auto-generated />
using System;
using API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.1");

            modelBuilder.Entity("API.Entities.AppUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasDefaultValueSql("datetime('now')");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("BLOB");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("BLOB");

                    b.Property<string>("Role")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasDefaultValue("Member");

                    b.Property<DateTime>("UpdatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasDefaultValueSql("datetime('now')");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserName")
                        .IsUnique();

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedOn = new DateTime(2021, 12, 17, 15, 32, 15, 717, DateTimeKind.Local).AddTicks(6863),
                            Email = "admin@domain.net",
                            PasswordHash = new byte[] { 147, 169, 37, 239, 194, 203, 14, 83, 61, 156, 178, 154, 153, 96, 181, 145, 174, 140, 36, 35, 0, 8, 234, 38, 28, 187, 199, 223, 74, 132, 207, 136, 47, 207, 69, 210, 221, 210, 129, 238, 188, 63, 109, 227, 88, 254, 191, 84, 63, 6, 160, 246, 114, 104, 84, 232, 180, 43, 163, 166, 54, 197, 38, 123 },
                            PasswordSalt = new byte[] { 21, 91, 132, 4, 201, 163, 152, 203, 197, 43, 84, 153, 34, 229, 242, 111, 71, 156, 68, 155, 172, 158, 127, 180, 12, 57, 52, 19, 46, 236, 191, 126, 188, 12, 107, 45, 120, 3, 220, 213, 47, 49, 191, 127, 188, 218, 192, 24, 150, 167, 153, 230, 178, 86, 12, 102, 54, 4, 156, 86, 149, 172, 138, 57, 156, 253, 44, 123, 170, 87, 171, 159, 74, 219, 70, 252, 16, 106, 167, 222, 247, 143, 176, 19, 79, 120, 77, 22, 29, 75, 11, 78, 169, 213, 248, 168, 187, 165, 129, 157, 12, 134, 144, 113, 53, 211, 202, 207, 147, 111, 159, 216, 217, 23, 220, 160, 75, 11, 221, 118, 136, 194, 106, 196, 135, 18, 165, 179 },
                            Role = "Admin",
                            UpdatedOn = new DateTime(2021, 12, 17, 15, 32, 15, 717, DateTimeKind.Local).AddTicks(6866),
                            UserName = "admin"
                        },
                        new
                        {
                            Id = 2,
                            CreatedOn = new DateTime(2021, 12, 17, 15, 32, 15, 717, DateTimeKind.Local).AddTicks(6903),
                            Email = "member@domain.net",
                            PasswordHash = new byte[] { 24, 220, 40, 187, 142, 89, 214, 58, 41, 200, 130, 250, 104, 153, 61, 29, 177, 200, 226, 163, 220, 22, 195, 102, 161, 169, 56, 41, 110, 176, 208, 221, 239, 209, 7, 38, 246, 66, 191, 11, 217, 159, 50, 9, 1, 252, 115, 1, 133, 192, 139, 212, 69, 170, 231, 75, 96, 185, 85, 101, 50, 4, 182, 1 },
                            PasswordSalt = new byte[] { 49, 135, 231, 204, 147, 28, 81, 67, 173, 227, 158, 31, 217, 228, 235, 13, 234, 2, 103, 126, 88, 130, 133, 247, 103, 167, 19, 184, 141, 131, 43, 181, 253, 65, 194, 211, 94, 15, 148, 172, 235, 178, 189, 245, 83, 164, 17, 42, 157, 214, 6, 135, 152, 234, 219, 151, 26, 15, 25, 165, 27, 105, 53, 48, 113, 181, 76, 211, 74, 250, 216, 63, 73, 134, 122, 187, 162, 193, 81, 233, 117, 42, 24, 160, 242, 255, 220, 124, 122, 44, 91, 211, 162, 131, 57, 30, 228, 139, 111, 255, 45, 7, 241, 167, 132, 228, 64, 243, 87, 184, 38, 20, 242, 184, 17, 224, 62, 124, 157, 108, 175, 207, 108, 104, 223, 124, 138, 119 },
                            Role = "Member",
                            UpdatedOn = new DateTime(2021, 12, 17, 15, 32, 15, 717, DateTimeKind.Local).AddTicks(6905),
                            UserName = "member"
                        });
                });

            modelBuilder.Entity("API.Entities.ItemCategory", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("TEXT")
                        .UseCollation("NOCASE");

                    b.HasKey("Name");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Name = "Electronics"
                        },
                        new
                        {
                            Name = "Furniture"
                        },
                        new
                        {
                            Name = "Sporting"
                        },
                        new
                        {
                            Name = "Misc."
                        });
                });

            modelBuilder.Entity("API.Entities.ItemImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsMain")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ItemListingId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("OwnerId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PublicId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ItemListingId");

                    b.HasIndex("OwnerId");

                    b.ToTable("ItemImages");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsMain = true,
                            ItemListingId = 1,
                            OwnerId = 1,
                            PublicId = "folding_table_rgrmom",
                            Url = "https://res.cloudinary.com/dub1phgqv/image/upload/v1639551491/folding_table_rgrmom.jpg"
                        },
                        new
                        {
                            Id = 2,
                            IsMain = true,
                            ItemListingId = 2,
                            OwnerId = 1,
                            PublicId = "gtxlx5rfi3b9wmtzakro",
                            Url = "https://res.cloudinary.com/dub1phgqv/image/upload/v1639771116/gtxlx5rfi3b9wmtzakro.jpg"
                        },
                        new
                        {
                            Id = 3,
                            IsMain = true,
                            ItemListingId = 3,
                            OwnerId = 2,
                            PublicId = "qhtucrxynkepvpsgn189",
                            Url = "https://res.cloudinary.com/dub1phgqv/image/upload/v1639772129/qhtucrxynkepvpsgn189.jpg"
                        },
                        new
                        {
                            Id = 4,
                            IsMain = true,
                            ItemListingId = 4,
                            OwnerId = 2,
                            PublicId = "kfbjlfkldkruumqzgrbs",
                            Url = "https://res.cloudinary.com/dub1phgqv/image/upload/v1639761761/kfbjlfkldkruumqzgrbs.jpg"
                        });
                });

            modelBuilder.Entity("API.Entities.ItemListing", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Archived")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasDefaultValue(false);

                    b.Property<string>("CategoryName")
                        .HasColumnType("TEXT")
                        .UseCollation("NOCASE");

                    b.Property<int>("Condition")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasDefaultValueSql("datetime('now')");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<int>("OwnerId")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Price")
                        .HasColumnType("Number");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CategoryName");

                    b.HasIndex("OwnerId");

                    b.ToTable("ItemListings");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Archived = false,
                            CategoryName = "Furniture",
                            Condition = 2,
                            CreatedOn = new DateTime(2021, 12, 17, 15, 32, 15, 717, DateTimeKind.Local).AddTicks(8414),
                            Description = "Lorem ipsum, dolor sit amet consectetur adipisicing elit. Nobis magnam reprehenderit saepe odit ullam, laboriosam, cumque repudiandae nam consequuntur enim labore, accusantium repellendus tempore? Cumque perspiciatis explicabo, cum corrupti provident minus possimus error eos repellendus? Suscipit unde neque alias atque aliquid. Perspiciatis provident dolore obcaecati ipsum tempore ad, reiciendis consequuntur? Expedita alias temporibus, numquam dolore veniam quasi! Alias, rerum quod. Eius perferendis aperiam incidunt, minus totam, dolorem exercitationem a neque explicabo, vitae ipsa provident fugit ea possimus nostrum consectetur magnam non quasi. Accusantium sed voluptatibus delectus quae asperiores eligendi illo consequuntur eum nemo quaerat ad excepturi tempora dolore itaque nisi inventore magni explicabo, suscipit esse doloribus! Molestias animi totam illum doloribus magnam unde est. Blanditiis nisi quos dolorem maiores voluptatem laborum dolor amet, architecto voluptas dignissimos similique assumenda voluptate mollitia veniam eaque officia deleniti tempora ea repellendus. Facere vel pariatur, laborum impedit et maxime, quo molestiae obcaecati doloremque accusantium adipisci?",
                            OwnerId = 1,
                            Price = 50.0,
                            Title = "Round Folding Dining Table"
                        },
                        new
                        {
                            Id = 2,
                            Archived = false,
                            CategoryName = "Electronics",
                            Condition = 1,
                            CreatedOn = new DateTime(2021, 12, 17, 15, 32, 15, 717, DateTimeKind.Local).AddTicks(8426),
                            Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Autem cupiditate eaque aliquid in velit modi sit obcaecati fuga aperiam quidem. A necessitatibus quaerat facilis tenetur iste, ratione mollitia explicabo eos iure dolorem totam odit vel saepe voluptates, culpa obcaecati, excepturi illo. Inventore soluta provident cum vero, voluptas eaque beatae doloribus labore vel deleniti eius ad est autem sequi officiis. Voluptas, magnam atque numquam hic tenetur optio aut culpa maxime minus inventore, recusandae, aliquid magni quo laboriosam odio pariatur animi? Iusto asperiores saepe voluptate quia. Saepe cupiditate architecto perferendis. Natus nulla amet recusandae excepturi quia unde error provident porro vitae saepe veritatis praesentium earum impedit est corrupti facere facilis enim qui, labore mollitia laudantium ullam magnam. Quidem sint illum ducimus molestiae dolor fugit temporibus libero explicabo!",
                            OwnerId = 1,
                            Price = 1119.99,
                            Title = "Brand New Canon EOS 60D"
                        },
                        new
                        {
                            Id = 3,
                            Archived = false,
                            CategoryName = "Sporting",
                            Condition = 5,
                            CreatedOn = new DateTime(2021, 12, 17, 15, 32, 15, 717, DateTimeKind.Local).AddTicks(8428),
                            Description = "'Mint condition'",
                            OwnerId = 2,
                            Price = 330.0,
                            Title = "Vitage Football"
                        },
                        new
                        {
                            Id = 4,
                            Archived = false,
                            CategoryName = "Misc.",
                            Condition = 4,
                            CreatedOn = new DateTime(2021, 12, 17, 15, 32, 15, 717, DateTimeKind.Local).AddTicks(8430),
                            Description = "Dunkin's new roast blend. Product is not same as the image shown. I already drank the coffee...\n\nYou can actually disregard this post.",
                            OwnerId = 2,
                            Price = 6.9900000000000002,
                            Title = "Cup of Coffee"
                        });
                });

            modelBuilder.Entity("API.Entities.ItemImage", b =>
                {
                    b.HasOne("API.Entities.ItemListing", "ItemListing")
                        .WithMany("Images")
                        .HasForeignKey("ItemListingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Entities.AppUser", "Owner")
                        .WithMany("ItemListingImages")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ItemListing");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("API.Entities.ItemListing", b =>
                {
                    b.HasOne("API.Entities.ItemCategory", "Category")
                        .WithMany("ItemListings")
                        .HasForeignKey("CategoryName")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("API.Entities.AppUser", "Owner")
                        .WithMany("ItemListings")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("API.Entities.AppUser", b =>
                {
                    b.Navigation("ItemListingImages");

                    b.Navigation("ItemListings");
                });

            modelBuilder.Entity("API.Entities.ItemCategory", b =>
                {
                    b.Navigation("ItemListings");
                });

            modelBuilder.Entity("API.Entities.ItemListing", b =>
                {
                    b.Navigation("Images");
                });
#pragma warning restore 612, 618
        }
    }
}
