using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class AddedEmailColOnUsers : Migration
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
                table: "Users",
                columns: new[] { "Id", "CreatedOn", "Email", "PasswordHash", "PasswordSalt", "Role", "UpdatedOn", "UserName" },
                values: new object[] { 1, new DateTime(2021, 12, 16, 18, 8, 3, 879, DateTimeKind.Local).AddTicks(3575), "admin@domain.net", new byte[] { 115, 19, 131, 155, 13, 221, 232, 38, 212, 195, 231, 45, 159, 181, 149, 222, 91, 195, 208, 98, 156, 26, 148, 102, 80, 198, 71, 175, 198, 167, 59, 15, 234, 220, 140, 178, 222, 194, 232, 199, 193, 148, 248, 60, 172, 198, 158, 164, 75, 227, 231, 121, 30, 165, 57, 141, 232, 138, 115, 172, 247, 252, 66, 76 }, new byte[] { 118, 151, 94, 52, 180, 33, 149, 26, 100, 123, 2, 86, 143, 164, 127, 251, 54, 235, 19, 106, 151, 86, 116, 35, 85, 232, 53, 21, 206, 220, 6, 117, 174, 236, 105, 167, 31, 251, 40, 178, 216, 19, 161, 42, 113, 215, 217, 112, 33, 126, 192, 174, 175, 102, 44, 240, 52, 0, 244, 114, 192, 177, 147, 28, 70, 96, 113, 179, 171, 144, 233, 108, 244, 57, 76, 94, 166, 59, 79, 14, 111, 88, 205, 125, 76, 62, 20, 204, 195, 212, 250, 92, 209, 216, 135, 187, 59, 155, 60, 254, 92, 224, 6, 170, 148, 194, 152, 164, 119, 29, 89, 252, 174, 27, 216, 109, 233, 196, 139, 210, 51, 224, 222, 144, 98, 250, 88, 78 }, "Admin", new DateTime(2021, 12, 16, 18, 8, 3, 879, DateTimeKind.Local).AddTicks(3577), "admin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedOn", "Email", "PasswordHash", "PasswordSalt", "UpdatedOn", "UserName" },
                values: new object[] { 2, new DateTime(2021, 12, 16, 18, 8, 3, 879, DateTimeKind.Local).AddTicks(3610), "member@domain.net", new byte[] { 76, 239, 71, 202, 199, 5, 201, 168, 244, 106, 204, 47, 169, 116, 193, 207, 172, 92, 152, 44, 145, 210, 101, 65, 244, 71, 57, 20, 97, 112, 22, 135, 229, 103, 205, 160, 38, 16, 175, 68, 175, 188, 208, 6, 251, 67, 80, 98, 165, 120, 224, 208, 141, 100, 104, 184, 146, 123, 252, 74, 146, 8, 71, 24 }, new byte[] { 71, 224, 40, 52, 148, 178, 245, 111, 38, 185, 236, 75, 104, 55, 82, 102, 82, 110, 27, 177, 42, 92, 73, 101, 228, 129, 29, 252, 45, 160, 119, 71, 102, 106, 9, 103, 33, 106, 68, 253, 25, 235, 158, 127, 95, 64, 109, 235, 4, 255, 57, 44, 222, 54, 255, 54, 138, 31, 51, 11, 163, 251, 251, 78, 214, 84, 71, 45, 159, 159, 125, 224, 132, 89, 111, 151, 143, 207, 59, 198, 32, 53, 226, 49, 91, 237, 19, 217, 31, 78, 167, 142, 184, 205, 110, 87, 169, 217, 163, 12, 224, 242, 146, 18, 29, 140, 251, 104, 153, 129, 38, 187, 124, 101, 220, 178, 45, 182, 120, 42, 11, 29, 189, 105, 237, 193, 73, 226 }, new DateTime(2021, 12, 16, 18, 8, 3, 879, DateTimeKind.Local).AddTicks(3611), "member" });

            migrationBuilder.InsertData(
                table: "ItemListings",
                columns: new[] { "Id", "CategoryName", "Condition", "CreatedOn", "Description", "OwnerId", "Price", "Title" },
                values: new object[] { 1, "Furniture", 2, new DateTime(2021, 12, 16, 18, 8, 3, 879, DateTimeKind.Local).AddTicks(4920), "Round folding dining table from Bob's Furniture Store.\nGreat for smaller dining areas/apartments. Smoke-free home.\n\nAsking price - $50.", 2, 50.0, "Round Folding Dining Table" });

            migrationBuilder.InsertData(
                table: "ItemListings",
                columns: new[] { "Id", "CategoryName", "Condition", "CreatedOn", "Description", "OwnerId", "Price", "Title" },
                values: new object[] { 2, "Electronics", 0, new DateTime(2021, 12, 16, 18, 8, 3, 879, DateTimeKind.Local).AddTicks(4933), "Absolutely brand new in the box (unopened box) 55 inch TCL 4K UHD Smart Roku TV.\n.Condition: Brand New In the (unopened). Same condition as you get from a store. Price: $330 Cash and Pick up only.", 2, 330.0, "Brand New 55\" inch TCL - 4K UHD Smart Roku TV" });

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
