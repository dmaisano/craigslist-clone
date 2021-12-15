using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class AppUserEntityAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    City = table.Column<string>(type: "TEXT", nullable: false),
                    Role = table.Column<string>(type: "TEXT", nullable: false, defaultValue: "Member"),
                    CreatedOn = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "datetime('now')"),
                    UpdatedOn = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "datetime('now')")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "City", "CreatedOn", "Email", "PasswordHash", "PasswordSalt", "Role", "UpdatedOn", "UserName" },
                values: new object[] { 1, "Holmdel, NJ", new DateTime(2021, 12, 14, 22, 57, 41, 193, DateTimeKind.Local).AddTicks(2655), "admin@domain.com", new byte[] { 28, 253, 211, 79, 196, 54, 48, 162, 27, 234, 31, 99, 62, 52, 22, 167, 54, 251, 97, 235, 178, 34, 100, 184, 220, 178, 96, 33, 151, 255, 254, 219, 147, 216, 47, 176, 241, 71, 72, 17, 233, 2, 103, 245, 72, 101, 99, 115, 200, 159, 54, 9, 235, 202, 79, 5, 253, 58, 244, 5, 80, 13, 210, 42 }, new byte[] { 167, 187, 250, 92, 191, 60, 210, 137, 242, 59, 179, 39, 238, 166, 36, 38, 135, 122, 98, 117, 197, 185, 107, 241, 56, 136, 17, 53, 129, 151, 155, 171, 214, 135, 82, 172, 167, 201, 248, 179, 47, 205, 168, 83, 126, 14, 195, 220, 227, 159, 93, 65, 136, 131, 85, 51, 249, 129, 65, 145, 235, 224, 61, 90, 174, 122, 235, 74, 241, 194, 58, 209, 247, 59, 105, 237, 30, 60, 176, 47, 137, 234, 3, 202, 135, 138, 56, 19, 126, 122, 114, 159, 27, 241, 93, 57, 139, 246, 243, 116, 251, 116, 107, 146, 12, 0, 89, 17, 156, 56, 230, 35, 64, 250, 237, 13, 17, 64, 117, 106, 50, 207, 158, 127, 108, 87, 231, 177 }, "Admin", new DateTime(2021, 12, 14, 22, 57, 41, 193, DateTimeKind.Local).AddTicks(2658), "admin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "City", "CreatedOn", "Email", "PasswordHash", "PasswordSalt", "UpdatedOn", "UserName" },
                values: new object[] { 2, "Holmdel, NJ", new DateTime(2021, 12, 14, 22, 57, 41, 193, DateTimeKind.Local).AddTicks(2695), "member@domain.com", new byte[] { 83, 191, 38, 248, 227, 101, 232, 203, 38, 139, 48, 141, 80, 14, 34, 145, 147, 245, 167, 224, 31, 80, 90, 106, 185, 131, 172, 102, 1, 219, 36, 117, 42, 216, 246, 212, 230, 235, 149, 250, 26, 68, 51, 147, 76, 140, 78, 105, 110, 146, 10, 18, 203, 146, 31, 77, 191, 213, 65, 37, 203, 4, 36, 0 }, new byte[] { 168, 153, 126, 210, 162, 150, 111, 25, 96, 76, 185, 35, 175, 27, 2, 161, 17, 151, 254, 58, 131, 115, 34, 250, 190, 219, 189, 74, 122, 151, 157, 113, 241, 107, 241, 192, 151, 112, 110, 190, 72, 19, 188, 241, 60, 47, 190, 193, 243, 174, 84, 101, 157, 26, 96, 153, 245, 14, 84, 23, 222, 50, 20, 53, 71, 86, 15, 151, 141, 60, 106, 50, 250, 42, 131, 181, 61, 56, 196, 181, 80, 188, 61, 242, 57, 123, 220, 22, 52, 209, 224, 49, 201, 151, 111, 112, 106, 2, 131, 116, 153, 70, 85, 131, 39, 144, 9, 202, 7, 209, 244, 135, 203, 152, 46, 60, 158, 74, 120, 140, 3, 196, 100, 207, 92, 171, 55, 213 }, new DateTime(2021, 12, 14, 22, 57, 41, 193, DateTimeKind.Local).AddTicks(2697), "member" });

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserName",
                table: "Users",
                column: "UserName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
