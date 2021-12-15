using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class ModifiedItemCategoryColToInt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Name = table.Column<string>(type: "TEXT", nullable: false)
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
                    Condition = table.Column<int>(type: "INTEGER", nullable: false, defaultValue: 4),
                    Archived = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: false),
                    CategoryName = table.Column<string>(type: "TEXT", nullable: true),
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
                table: "Users",
                columns: new[] { "Id", "CreatedOn", "PasswordHash", "PasswordSalt", "Role", "UpdatedOn", "UserName" },
                values: new object[] { 1, new DateTime(2021, 12, 15, 11, 32, 25, 521, DateTimeKind.Local).AddTicks(5706), new byte[] { 50, 24, 41, 28, 187, 34, 179, 77, 172, 7, 255, 22, 110, 186, 98, 226, 227, 248, 77, 64, 96, 207, 236, 15, 32, 95, 203, 133, 42, 249, 250, 100, 196, 46, 39, 126, 111, 241, 174, 64, 13, 166, 121, 102, 13, 69, 137, 112, 83, 195, 66, 54, 253, 131, 58, 53, 244, 119, 245, 3, 102, 160, 142, 71 }, new byte[] { 90, 65, 168, 129, 201, 176, 170, 97, 132, 118, 96, 237, 33, 40, 186, 194, 145, 199, 32, 52, 30, 7, 128, 160, 113, 52, 125, 68, 39, 134, 174, 29, 15, 122, 48, 186, 70, 57, 27, 250, 136, 255, 180, 0, 19, 85, 60, 119, 255, 8, 244, 195, 170, 29, 212, 14, 207, 130, 242, 98, 201, 62, 126, 100, 58, 74, 14, 134, 6, 127, 80, 44, 13, 161, 215, 222, 114, 195, 39, 79, 241, 90, 58, 185, 183, 49, 118, 206, 67, 20, 174, 163, 233, 211, 171, 39, 170, 225, 79, 179, 143, 212, 55, 217, 118, 190, 146, 218, 107, 98, 136, 244, 170, 209, 201, 229, 97, 212, 55, 82, 171, 107, 158, 185, 231, 121, 72, 38 }, "Admin", new DateTime(2021, 12, 15, 11, 32, 25, 521, DateTimeKind.Local).AddTicks(5708), "admin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedOn", "PasswordHash", "PasswordSalt", "UpdatedOn", "UserName" },
                values: new object[] { 2, new DateTime(2021, 12, 15, 11, 32, 25, 521, DateTimeKind.Local).AddTicks(5741), new byte[] { 48, 80, 88, 78, 93, 168, 127, 200, 140, 206, 127, 130, 46, 12, 228, 199, 220, 4, 86, 22, 7, 214, 36, 209, 176, 33, 29, 158, 123, 239, 14, 244, 191, 85, 120, 79, 255, 18, 134, 45, 76, 146, 36, 71, 191, 114, 126, 74, 123, 137, 135, 85, 140, 156, 27, 137, 4, 9, 22, 194, 5, 75, 234, 115 }, new byte[] { 199, 63, 132, 162, 139, 236, 242, 236, 166, 145, 70, 156, 57, 127, 87, 4, 142, 247, 63, 6, 129, 33, 175, 144, 9, 5, 140, 65, 174, 143, 16, 170, 163, 153, 139, 213, 189, 196, 235, 175, 151, 210, 147, 81, 183, 189, 189, 36, 187, 163, 218, 55, 25, 218, 127, 1, 69, 188, 16, 38, 231, 200, 169, 222, 92, 159, 176, 254, 74, 20, 188, 43, 55, 105, 5, 186, 144, 218, 209, 41, 201, 239, 110, 223, 236, 80, 202, 119, 232, 54, 72, 28, 206, 22, 225, 173, 84, 92, 45, 196, 169, 5, 80, 185, 3, 133, 235, 243, 159, 177, 180, 233, 141, 201, 120, 125, 214, 188, 5, 250, 28, 217, 147, 160, 95, 103, 140, 255 }, new DateTime(2021, 12, 15, 11, 32, 25, 521, DateTimeKind.Local).AddTicks(5743), "member" });

            migrationBuilder.InsertData(
                table: "ItemListings",
                columns: new[] { "Id", "CategoryName", "Condition", "CreatedOn", "Description", "OwnerId", "Price", "Title" },
                values: new object[] { 1, "Furniture", 2, new DateTime(2021, 12, 15, 11, 32, 25, 521, DateTimeKind.Local).AddTicks(7127), "Round folding dining table from Bob's Furniture Store.\nGreat for smaller dining areas/apartments. Smoke-free home.\n\nAsking price - $50.", 2, 50.0, "Round Folding Dining Table" });

            migrationBuilder.InsertData(
                table: "ItemListings",
                columns: new[] { "Id", "CategoryName", "CreatedOn", "Description", "OwnerId", "Price", "Title" },
                values: new object[] { 2, "Electronics", new DateTime(2021, 12, 15, 11, 32, 25, 521, DateTimeKind.Local).AddTicks(7139), "Absolutely brand new in the box (unopened box) 55 inch TCL 4K UHD Smart Roku TV.\n.Condition: Brand New In the (unopened). Same condition as you get from a store. Price: $330 Cash and Pick up only.", 2, 330.0, "Brand New 55\" inch TCL - 4K UHD Smart Roku TV" });

            migrationBuilder.InsertData(
                table: "ItemImages",
                columns: new[] { "Id", "IsMain", "ItemListingId", "OwnerId", "PublicId", "Url" },
                values: new object[] { 1, true, 1, 2, "tcl_tv_ufvgvz", "https://res.cloudinary.com/dub1phgqv/image/upload/v1639551491/folding_table_rgrmom.jpg" });

            migrationBuilder.InsertData(
                table: "ItemImages",
                columns: new[] { "Id", "IsMain", "ItemListingId", "OwnerId", "PublicId", "Url" },
                values: new object[] { 2, true, 2, 2, "folding_table_rgrmom", "https://res.cloudinary.com/dub1phgqv/image/upload/v1639551492/tcl_tv_ufvgvz.jpg" });

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
