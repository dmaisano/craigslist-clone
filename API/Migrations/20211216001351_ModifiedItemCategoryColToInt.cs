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
                    Condition = table.Column<int>(type: "INTEGER", nullable: false),
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
                values: new object[] { 1, new DateTime(2021, 12, 15, 19, 13, 51, 30, DateTimeKind.Local).AddTicks(2579), new byte[] { 245, 133, 212, 199, 187, 108, 38, 143, 189, 32, 180, 52, 219, 80, 7, 73, 175, 71, 205, 182, 61, 225, 43, 169, 5, 159, 78, 239, 127, 100, 206, 223, 241, 72, 53, 241, 83, 32, 115, 53, 23, 201, 49, 185, 252, 119, 4, 31, 189, 142, 142, 114, 130, 82, 233, 207, 0, 202, 170, 230, 5, 210, 114, 47 }, new byte[] { 66, 227, 166, 49, 50, 118, 58, 229, 56, 43, 242, 11, 226, 68, 160, 104, 231, 128, 130, 11, 83, 148, 136, 219, 136, 131, 203, 110, 4, 184, 30, 61, 185, 170, 40, 246, 32, 98, 36, 234, 74, 213, 166, 124, 45, 165, 42, 234, 28, 191, 125, 10, 97, 21, 126, 201, 41, 206, 102, 215, 126, 30, 42, 165, 28, 5, 214, 188, 188, 154, 144, 85, 45, 248, 175, 87, 66, 27, 59, 80, 110, 200, 2, 200, 192, 36, 227, 31, 238, 228, 243, 43, 115, 99, 179, 246, 232, 38, 124, 162, 132, 200, 128, 41, 216, 106, 184, 105, 86, 4, 153, 210, 134, 171, 179, 249, 232, 234, 200, 130, 89, 215, 189, 4, 41, 129, 22, 229 }, "Admin", new DateTime(2021, 12, 15, 19, 13, 51, 30, DateTimeKind.Local).AddTicks(2581), "admin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedOn", "PasswordHash", "PasswordSalt", "UpdatedOn", "UserName" },
                values: new object[] { 2, new DateTime(2021, 12, 15, 19, 13, 51, 30, DateTimeKind.Local).AddTicks(2615), new byte[] { 37, 144, 251, 171, 150, 188, 155, 154, 222, 40, 250, 122, 189, 182, 155, 28, 115, 52, 19, 144, 248, 80, 152, 9, 203, 100, 53, 102, 132, 87, 125, 199, 211, 39, 207, 169, 193, 25, 17, 30, 80, 156, 16, 30, 15, 41, 99, 188, 20, 85, 34, 76, 119, 31, 87, 166, 154, 7, 94, 189, 43, 225, 228, 189 }, new byte[] { 37, 15, 139, 28, 196, 83, 191, 217, 88, 13, 71, 14, 154, 29, 26, 31, 181, 236, 55, 159, 248, 202, 173, 197, 158, 34, 164, 40, 254, 241, 222, 187, 246, 64, 46, 103, 160, 99, 219, 99, 117, 236, 130, 194, 247, 43, 13, 198, 192, 248, 158, 114, 86, 211, 46, 75, 185, 249, 244, 9, 19, 128, 21, 214, 147, 222, 10, 22, 142, 200, 178, 111, 31, 238, 165, 228, 32, 12, 54, 166, 172, 124, 237, 75, 97, 17, 161, 116, 149, 28, 89, 16, 86, 160, 15, 128, 41, 226, 81, 220, 183, 130, 107, 67, 68, 91, 103, 168, 151, 180, 4, 100, 33, 69, 229, 209, 96, 129, 195, 109, 164, 196, 26, 174, 14, 32, 108, 193 }, new DateTime(2021, 12, 15, 19, 13, 51, 30, DateTimeKind.Local).AddTicks(2617), "member" });

            migrationBuilder.InsertData(
                table: "ItemListings",
                columns: new[] { "Id", "CategoryName", "Condition", "CreatedOn", "Description", "OwnerId", "Price", "Title" },
                values: new object[] { 1, "Furniture", 2, new DateTime(2021, 12, 15, 19, 13, 51, 30, DateTimeKind.Local).AddTicks(3793), "Round folding dining table from Bob's Furniture Store.\nGreat for smaller dining areas/apartments. Smoke-free home.\n\nAsking price - $50.", 2, 50.0, "Round Folding Dining Table" });

            migrationBuilder.InsertData(
                table: "ItemListings",
                columns: new[] { "Id", "CategoryName", "Condition", "CreatedOn", "Description", "OwnerId", "Price", "Title" },
                values: new object[] { 2, "Electronics", 0, new DateTime(2021, 12, 15, 19, 13, 51, 30, DateTimeKind.Local).AddTicks(3806), "Absolutely brand new in the box (unopened box) 55 inch TCL 4K UHD Smart Roku TV.\n.Condition: Brand New In the (unopened). Same condition as you get from a store. Price: $330 Cash and Pick up only.", 2, 330.0, "Brand New 55\" inch TCL - 4K UHD Smart Roku TV" });

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
