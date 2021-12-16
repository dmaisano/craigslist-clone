using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class AddNoCaseCollationOnItemCategory : Migration
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
                table: "Users",
                columns: new[] { "Id", "CreatedOn", "PasswordHash", "PasswordSalt", "Role", "UpdatedOn", "UserName" },
                values: new object[] { 1, new DateTime(2021, 12, 16, 17, 0, 0, 406, DateTimeKind.Local).AddTicks(5525), new byte[] { 196, 32, 71, 122, 246, 143, 232, 113, 64, 37, 240, 183, 70, 133, 29, 238, 46, 97, 71, 235, 77, 137, 48, 86, 179, 170, 82, 114, 146, 61, 130, 227, 172, 90, 76, 28, 57, 190, 190, 62, 92, 251, 177, 39, 234, 191, 7, 96, 150, 38, 194, 3, 110, 143, 148, 90, 56, 174, 104, 68, 141, 228, 223, 153 }, new byte[] { 231, 227, 4, 21, 219, 198, 202, 38, 67, 26, 92, 236, 88, 252, 160, 144, 53, 39, 216, 80, 44, 197, 232, 170, 119, 30, 69, 189, 30, 25, 151, 147, 72, 189, 241, 72, 178, 228, 95, 65, 194, 171, 234, 239, 133, 148, 24, 59, 126, 199, 151, 237, 73, 241, 226, 32, 200, 101, 47, 88, 106, 64, 13, 217, 221, 153, 81, 245, 165, 129, 165, 55, 180, 194, 244, 189, 159, 162, 236, 206, 93, 116, 50, 210, 202, 186, 38, 242, 20, 147, 155, 236, 214, 139, 189, 131, 23, 146, 79, 177, 101, 212, 77, 186, 242, 155, 11, 107, 148, 90, 28, 138, 2, 168, 69, 85, 212, 195, 233, 184, 14, 191, 124, 202, 151, 84, 244, 233 }, "Admin", new DateTime(2021, 12, 16, 17, 0, 0, 406, DateTimeKind.Local).AddTicks(5527), "admin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedOn", "PasswordHash", "PasswordSalt", "UpdatedOn", "UserName" },
                values: new object[] { 2, new DateTime(2021, 12, 16, 17, 0, 0, 406, DateTimeKind.Local).AddTicks(5559), new byte[] { 176, 163, 75, 188, 234, 178, 128, 235, 117, 123, 24, 10, 123, 13, 11, 37, 213, 116, 235, 5, 191, 5, 90, 133, 228, 15, 120, 210, 85, 144, 161, 200, 40, 91, 22, 1, 219, 184, 170, 45, 8, 145, 207, 230, 88, 21, 106, 121, 143, 255, 221, 112, 104, 96, 209, 111, 42, 246, 166, 63, 37, 38, 63, 117 }, new byte[] { 48, 240, 81, 69, 17, 40, 40, 117, 47, 198, 130, 192, 227, 200, 73, 99, 255, 138, 114, 10, 59, 25, 40, 181, 161, 114, 133, 118, 213, 3, 56, 120, 74, 125, 228, 33, 36, 87, 135, 61, 217, 142, 225, 46, 39, 151, 173, 47, 236, 139, 157, 212, 138, 65, 234, 76, 103, 17, 21, 6, 155, 130, 223, 120, 136, 134, 170, 232, 212, 200, 217, 222, 190, 131, 151, 135, 34, 52, 163, 48, 140, 132, 131, 119, 99, 232, 181, 233, 252, 153, 38, 43, 14, 53, 119, 94, 172, 5, 118, 7, 150, 66, 109, 112, 6, 69, 93, 79, 147, 240, 160, 189, 36, 110, 54, 236, 143, 145, 84, 170, 159, 172, 255, 145, 190, 29, 122, 57 }, new DateTime(2021, 12, 16, 17, 0, 0, 406, DateTimeKind.Local).AddTicks(5561), "member" });

            migrationBuilder.InsertData(
                table: "ItemListings",
                columns: new[] { "Id", "CategoryName", "Condition", "CreatedOn", "Description", "OwnerId", "Price", "Title" },
                values: new object[] { 1, "Furniture", 2, new DateTime(2021, 12, 16, 17, 0, 0, 406, DateTimeKind.Local).AddTicks(6848), "Round folding dining table from Bob's Furniture Store.\nGreat for smaller dining areas/apartments. Smoke-free home.\n\nAsking price - $50.", 2, 50.0, "Round Folding Dining Table" });

            migrationBuilder.InsertData(
                table: "ItemListings",
                columns: new[] { "Id", "CategoryName", "Condition", "CreatedOn", "Description", "OwnerId", "Price", "Title" },
                values: new object[] { 2, "Electronics", 0, new DateTime(2021, 12, 16, 17, 0, 0, 406, DateTimeKind.Local).AddTicks(6860), "Absolutely brand new in the box (unopened box) 55 inch TCL 4K UHD Smart Roku TV.\n.Condition: Brand New In the (unopened). Same condition as you get from a store. Price: $330 Cash and Pick up only.", 2, 330.0, "Brand New 55\" inch TCL - 4K UHD Smart Roku TV" });

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
