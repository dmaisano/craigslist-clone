using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class FinalizedMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Name = table.Column<string>(type: "TEXT", nullable: false, collation: "NOCASE")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserName = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "BLOB", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "BLOB", nullable: false),
                    Role = table.Column<string>(type: "TEXT", nullable: false, defaultValue: "Member"),
                    CreatedOn = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "datetime('now')"),
                    UpdatedOn = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "datetime('now')")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemListings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<double>(type: "Number", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "datetime('now')"),
                    Condition = table.Column<int>(type: "INTEGER", nullable: false),
                    Archived = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: false),
                    CategoryName = table.Column<string>(type: "TEXT", nullable: true, collation: "NOCASE"),
                    OwnerId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemListings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemListings_Categories_CategoryName",
                        column: x => x.CategoryName,
                        principalTable: "Categories",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemListings_Users_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Url = table.Column<string>(type: "TEXT", nullable: false),
                    PublicId = table.Column<string>(type: "TEXT", nullable: true),
                    IsMain = table.Column<bool>(type: "INTEGER", nullable: false),
                    ItemListingId = table.Column<int>(type: "INTEGER", nullable: false),
                    OwnerId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemImages_ItemListings_ItemListingId",
                        column: x => x.ItemListingId,
                        principalTable: "ItemListings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemImages_Users_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                column: "Name",
                value: "Electronics");

            migrationBuilder.InsertData(
                table: "Categories",
                column: "Name",
                value: "Furniture");

            migrationBuilder.InsertData(
                table: "Categories",
                column: "Name",
                value: "Misc.");

            migrationBuilder.InsertData(
                table: "Categories",
                column: "Name",
                value: "Sporting");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedOn", "Email", "PasswordHash", "PasswordSalt", "Role", "UpdatedOn", "UserName" },
                values: new object[] { 1, new DateTime(2021, 12, 17, 15, 32, 15, 717, DateTimeKind.Local).AddTicks(6863), "admin@domain.net", new byte[] { 147, 169, 37, 239, 194, 203, 14, 83, 61, 156, 178, 154, 153, 96, 181, 145, 174, 140, 36, 35, 0, 8, 234, 38, 28, 187, 199, 223, 74, 132, 207, 136, 47, 207, 69, 210, 221, 210, 129, 238, 188, 63, 109, 227, 88, 254, 191, 84, 63, 6, 160, 246, 114, 104, 84, 232, 180, 43, 163, 166, 54, 197, 38, 123 }, new byte[] { 21, 91, 132, 4, 201, 163, 152, 203, 197, 43, 84, 153, 34, 229, 242, 111, 71, 156, 68, 155, 172, 158, 127, 180, 12, 57, 52, 19, 46, 236, 191, 126, 188, 12, 107, 45, 120, 3, 220, 213, 47, 49, 191, 127, 188, 218, 192, 24, 150, 167, 153, 230, 178, 86, 12, 102, 54, 4, 156, 86, 149, 172, 138, 57, 156, 253, 44, 123, 170, 87, 171, 159, 74, 219, 70, 252, 16, 106, 167, 222, 247, 143, 176, 19, 79, 120, 77, 22, 29, 75, 11, 78, 169, 213, 248, 168, 187, 165, 129, 157, 12, 134, 144, 113, 53, 211, 202, 207, 147, 111, 159, 216, 217, 23, 220, 160, 75, 11, 221, 118, 136, 194, 106, 196, 135, 18, 165, 179 }, "Admin", new DateTime(2021, 12, 17, 15, 32, 15, 717, DateTimeKind.Local).AddTicks(6866), "admin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedOn", "Email", "PasswordHash", "PasswordSalt", "UpdatedOn", "UserName" },
                values: new object[] { 2, new DateTime(2021, 12, 17, 15, 32, 15, 717, DateTimeKind.Local).AddTicks(6903), "member@domain.net", new byte[] { 24, 220, 40, 187, 142, 89, 214, 58, 41, 200, 130, 250, 104, 153, 61, 29, 177, 200, 226, 163, 220, 22, 195, 102, 161, 169, 56, 41, 110, 176, 208, 221, 239, 209, 7, 38, 246, 66, 191, 11, 217, 159, 50, 9, 1, 252, 115, 1, 133, 192, 139, 212, 69, 170, 231, 75, 96, 185, 85, 101, 50, 4, 182, 1 }, new byte[] { 49, 135, 231, 204, 147, 28, 81, 67, 173, 227, 158, 31, 217, 228, 235, 13, 234, 2, 103, 126, 88, 130, 133, 247, 103, 167, 19, 184, 141, 131, 43, 181, 253, 65, 194, 211, 94, 15, 148, 172, 235, 178, 189, 245, 83, 164, 17, 42, 157, 214, 6, 135, 152, 234, 219, 151, 26, 15, 25, 165, 27, 105, 53, 48, 113, 181, 76, 211, 74, 250, 216, 63, 73, 134, 122, 187, 162, 193, 81, 233, 117, 42, 24, 160, 242, 255, 220, 124, 122, 44, 91, 211, 162, 131, 57, 30, 228, 139, 111, 255, 45, 7, 241, 167, 132, 228, 64, 243, 87, 184, 38, 20, 242, 184, 17, 224, 62, 124, 157, 108, 175, 207, 108, 104, 223, 124, 138, 119 }, new DateTime(2021, 12, 17, 15, 32, 15, 717, DateTimeKind.Local).AddTicks(6905), "member" });

            migrationBuilder.InsertData(
                table: "ItemListings",
                columns: new[] { "Id", "CategoryName", "Condition", "CreatedOn", "Description", "OwnerId", "Price", "Title" },
                values: new object[] { 1, "Furniture", 2, new DateTime(2021, 12, 17, 15, 32, 15, 717, DateTimeKind.Local).AddTicks(8414), "Lorem ipsum, dolor sit amet consectetur adipisicing elit. Nobis magnam reprehenderit saepe odit ullam, laboriosam, cumque repudiandae nam consequuntur enim labore, accusantium repellendus tempore? Cumque perspiciatis explicabo, cum corrupti provident minus possimus error eos repellendus? Suscipit unde neque alias atque aliquid. Perspiciatis provident dolore obcaecati ipsum tempore ad, reiciendis consequuntur? Expedita alias temporibus, numquam dolore veniam quasi! Alias, rerum quod. Eius perferendis aperiam incidunt, minus totam, dolorem exercitationem a neque explicabo, vitae ipsa provident fugit ea possimus nostrum consectetur magnam non quasi. Accusantium sed voluptatibus delectus quae asperiores eligendi illo consequuntur eum nemo quaerat ad excepturi tempora dolore itaque nisi inventore magni explicabo, suscipit esse doloribus! Molestias animi totam illum doloribus magnam unde est. Blanditiis nisi quos dolorem maiores voluptatem laborum dolor amet, architecto voluptas dignissimos similique assumenda voluptate mollitia veniam eaque officia deleniti tempora ea repellendus. Facere vel pariatur, laborum impedit et maxime, quo molestiae obcaecati doloremque accusantium adipisci?", 1, 50.0, "Round Folding Dining Table" });

            migrationBuilder.InsertData(
                table: "ItemListings",
                columns: new[] { "Id", "CategoryName", "Condition", "CreatedOn", "Description", "OwnerId", "Price", "Title" },
                values: new object[] { 2, "Electronics", 1, new DateTime(2021, 12, 17, 15, 32, 15, 717, DateTimeKind.Local).AddTicks(8426), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Autem cupiditate eaque aliquid in velit modi sit obcaecati fuga aperiam quidem. A necessitatibus quaerat facilis tenetur iste, ratione mollitia explicabo eos iure dolorem totam odit vel saepe voluptates, culpa obcaecati, excepturi illo. Inventore soluta provident cum vero, voluptas eaque beatae doloribus labore vel deleniti eius ad est autem sequi officiis. Voluptas, magnam atque numquam hic tenetur optio aut culpa maxime minus inventore, recusandae, aliquid magni quo laboriosam odio pariatur animi? Iusto asperiores saepe voluptate quia. Saepe cupiditate architecto perferendis. Natus nulla amet recusandae excepturi quia unde error provident porro vitae saepe veritatis praesentium earum impedit est corrupti facere facilis enim qui, labore mollitia laudantium ullam magnam. Quidem sint illum ducimus molestiae dolor fugit temporibus libero explicabo!", 1, 1119.99, "Brand New Canon EOS 60D" });

            migrationBuilder.InsertData(
                table: "ItemListings",
                columns: new[] { "Id", "CategoryName", "Condition", "CreatedOn", "Description", "OwnerId", "Price", "Title" },
                values: new object[] { 3, "Sporting", 5, new DateTime(2021, 12, 17, 15, 32, 15, 717, DateTimeKind.Local).AddTicks(8428), "'Mint condition'", 2, 330.0, "Vitage Football" });

            migrationBuilder.InsertData(
                table: "ItemListings",
                columns: new[] { "Id", "CategoryName", "Condition", "CreatedOn", "Description", "OwnerId", "Price", "Title" },
                values: new object[] { 4, "Misc.", 4, new DateTime(2021, 12, 17, 15, 32, 15, 717, DateTimeKind.Local).AddTicks(8430), "Dunkin's new roast blend. Product is not same as the image shown. I already drank the coffee...\n\nYou can actually disregard this post.", 2, 6.9900000000000002, "Cup of Coffee" });

            migrationBuilder.InsertData(
                table: "ItemImages",
                columns: new[] { "Id", "IsMain", "ItemListingId", "OwnerId", "PublicId", "Url" },
                values: new object[] { 1, true, 1, 1, "folding_table_rgrmom", "https://res.cloudinary.com/dub1phgqv/image/upload/v1639551491/folding_table_rgrmom.jpg" });

            migrationBuilder.InsertData(
                table: "ItemImages",
                columns: new[] { "Id", "IsMain", "ItemListingId", "OwnerId", "PublicId", "Url" },
                values: new object[] { 2, true, 2, 1, "gtxlx5rfi3b9wmtzakro", "https://res.cloudinary.com/dub1phgqv/image/upload/v1639771116/gtxlx5rfi3b9wmtzakro.jpg" });

            migrationBuilder.InsertData(
                table: "ItemImages",
                columns: new[] { "Id", "IsMain", "ItemListingId", "OwnerId", "PublicId", "Url" },
                values: new object[] { 3, true, 3, 2, "qhtucrxynkepvpsgn189", "https://res.cloudinary.com/dub1phgqv/image/upload/v1639772129/qhtucrxynkepvpsgn189.jpg" });

            migrationBuilder.InsertData(
                table: "ItemImages",
                columns: new[] { "Id", "IsMain", "ItemListingId", "OwnerId", "PublicId", "Url" },
                values: new object[] { 4, true, 4, 2, "kfbjlfkldkruumqzgrbs", "https://res.cloudinary.com/dub1phgqv/image/upload/v1639761761/kfbjlfkldkruumqzgrbs.jpg" });

            migrationBuilder.CreateIndex(
                name: "IX_ItemImages_ItemListingId",
                table: "ItemImages",
                column: "ItemListingId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemImages_OwnerId",
                table: "ItemImages",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemListings_CategoryName",
                table: "ItemListings",
                column: "CategoryName");

            migrationBuilder.CreateIndex(
                name: "IX_ItemListings_OwnerId",
                table: "ItemListings",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserName",
                table: "Users",
                column: "UserName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemImages");

            migrationBuilder.DropTable(
                name: "ItemListings");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
