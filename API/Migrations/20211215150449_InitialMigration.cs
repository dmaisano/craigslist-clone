using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class InitialMigration : Migration
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
                    Condition = table.Column<string>(type: "TEXT", nullable: false, defaultValue: "Fair"),
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
                values: new object[] { 1, new DateTime(2021, 12, 15, 10, 4, 49, 581, DateTimeKind.Local).AddTicks(5250), new byte[] { 29, 92, 80, 204, 74, 124, 140, 160, 210, 242, 138, 188, 225, 26, 102, 0, 244, 66, 190, 9, 248, 139, 94, 212, 121, 94, 224, 64, 36, 84, 42, 45, 167, 2, 111, 230, 156, 195, 227, 25, 146, 32, 181, 16, 88, 38, 173, 216, 144, 109, 41, 153, 86, 100, 228, 59, 163, 166, 14, 184, 230, 249, 127, 184 }, new byte[] { 121, 139, 115, 19, 57, 98, 46, 158, 246, 140, 159, 11, 210, 24, 191, 169, 119, 7, 130, 70, 186, 83, 134, 102, 94, 27, 114, 241, 148, 12, 52, 197, 131, 51, 197, 95, 211, 15, 122, 254, 80, 218, 231, 198, 217, 66, 203, 152, 228, 85, 34, 191, 35, 230, 7, 138, 231, 140, 206, 237, 25, 108, 221, 59, 16, 91, 203, 8, 247, 1, 210, 86, 21, 109, 177, 69, 12, 113, 2, 203, 129, 45, 219, 82, 239, 75, 46, 216, 21, 57, 91, 27, 149, 197, 144, 200, 41, 90, 197, 188, 102, 44, 248, 193, 189, 209, 90, 187, 56, 101, 123, 22, 125, 52, 24, 94, 75, 193, 104, 142, 137, 238, 110, 208, 240, 90, 51, 198 }, "Admin", new DateTime(2021, 12, 15, 10, 4, 49, 581, DateTimeKind.Local).AddTicks(5252), "admin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedOn", "PasswordHash", "PasswordSalt", "UpdatedOn", "UserName" },
                values: new object[] { 2, new DateTime(2021, 12, 15, 10, 4, 49, 581, DateTimeKind.Local).AddTicks(5325), new byte[] { 182, 126, 102, 190, 99, 130, 143, 244, 204, 79, 55, 125, 72, 216, 65, 219, 152, 102, 2, 220, 68, 134, 242, 3, 241, 204, 199, 123, 182, 76, 209, 83, 91, 207, 251, 216, 210, 55, 86, 241, 15, 198, 161, 136, 21, 255, 72, 77, 104, 160, 126, 84, 48, 71, 70, 239, 134, 156, 201, 225, 188, 199, 232, 85 }, new byte[] { 236, 234, 241, 89, 142, 30, 179, 104, 99, 164, 109, 207, 14, 21, 40, 139, 2, 126, 236, 247, 93, 47, 137, 25, 169, 223, 215, 148, 89, 209, 68, 26, 242, 90, 52, 139, 244, 55, 202, 185, 11, 22, 98, 54, 53, 38, 255, 249, 164, 55, 123, 150, 132, 67, 64, 66, 170, 19, 207, 168, 106, 142, 228, 194, 221, 167, 147, 79, 174, 6, 87, 98, 170, 169, 243, 133, 206, 76, 39, 227, 233, 212, 87, 157, 58, 231, 85, 26, 128, 109, 47, 11, 238, 109, 119, 144, 102, 140, 220, 244, 230, 61, 240, 224, 154, 236, 0, 62, 229, 173, 181, 181, 56, 45, 51, 229, 117, 191, 59, 209, 155, 46, 180, 4, 231, 157, 178, 38 }, new DateTime(2021, 12, 15, 10, 4, 49, 581, DateTimeKind.Local).AddTicks(5327), "member" });

            migrationBuilder.InsertData(
                table: "ItemListings",
                columns: new[] { "Id", "CategoryName", "Condition", "CreatedOn", "Description", "OwnerId", "Price", "Title" },
                values: new object[] { 1, "Furniture", "Excellent", new DateTime(2021, 12, 15, 10, 4, 49, 581, DateTimeKind.Local).AddTicks(6683), "Round folding dining table from Bob's Furniture Store.\nGreat for smaller dining areas/apartments. Smoke-free home.\n\nAsking price - $50.", 2, 50.0, "Round Folding Dining Table" });

            migrationBuilder.InsertData(
                table: "ItemListings",
                columns: new[] { "Id", "CategoryName", "CreatedOn", "Description", "OwnerId", "Price", "Title" },
                values: new object[] { 2, "Electronics", new DateTime(2021, 12, 15, 10, 4, 49, 581, DateTimeKind.Local).AddTicks(6697), "Absolutely brand new in the box (unopened box) 55 inch TCL 4K UHD Smart Roku TV.\n.Condition: Brand New In the (unopened). Same condition as you get from a store. Price: $330 Cash and Pick up only.", 2, 330.0, "Brand New 55\" inch TCL - 4K UHD Smart Roku TV" });

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
