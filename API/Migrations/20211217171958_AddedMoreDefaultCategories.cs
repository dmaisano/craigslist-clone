using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class AddedMoreDefaultCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                column: "Name",
                value: "Misc.");

            migrationBuilder.InsertData(
                table: "Categories",
                column: "Name",
                value: "Sporting");

            migrationBuilder.UpdateData(
                table: "ItemListings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2021, 12, 17, 12, 19, 58, 95, DateTimeKind.Local).AddTicks(5052));

            migrationBuilder.UpdateData(
                table: "ItemListings",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2021, 12, 17, 12, 19, 58, 95, DateTimeKind.Local).AddTicks(5064));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "PasswordHash", "PasswordSalt", "UpdatedOn" },
                values: new object[] { new DateTime(2021, 12, 17, 12, 19, 58, 95, DateTimeKind.Local).AddTicks(3657), new byte[] { 58, 209, 167, 71, 186, 101, 146, 55, 198, 238, 197, 70, 131, 250, 81, 169, 98, 105, 221, 203, 182, 37, 226, 241, 93, 251, 234, 53, 208, 13, 248, 140, 39, 210, 173, 167, 251, 23, 16, 235, 18, 248, 11, 62, 207, 140, 245, 30, 217, 45, 158, 116, 107, 30, 242, 243, 46, 191, 254, 144, 112, 48, 193, 40 }, new byte[] { 169, 157, 151, 254, 187, 185, 253, 181, 142, 117, 23, 170, 242, 61, 2, 235, 93, 119, 66, 128, 211, 129, 235, 3, 130, 21, 64, 124, 235, 65, 8, 6, 93, 5, 234, 181, 159, 244, 3, 210, 97, 120, 94, 253, 98, 178, 9, 201, 255, 140, 132, 159, 22, 65, 103, 9, 92, 118, 67, 242, 253, 160, 68, 81, 138, 91, 252, 115, 204, 96, 102, 167, 209, 134, 206, 168, 162, 202, 223, 238, 245, 46, 116, 58, 31, 224, 57, 78, 35, 184, 83, 122, 166, 174, 245, 104, 138, 197, 252, 0, 7, 0, 22, 245, 50, 68, 172, 145, 215, 25, 160, 85, 184, 215, 83, 185, 60, 177, 111, 19, 173, 208, 247, 22, 20, 241, 178, 55 }, new DateTime(2021, 12, 17, 12, 19, 58, 95, DateTimeKind.Local).AddTicks(3660) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "PasswordHash", "PasswordSalt", "UpdatedOn" },
                values: new object[] { new DateTime(2021, 12, 17, 12, 19, 58, 95, DateTimeKind.Local).AddTicks(3719), new byte[] { 7, 81, 174, 206, 23, 170, 183, 33, 154, 232, 29, 38, 240, 114, 153, 103, 147, 14, 205, 129, 182, 71, 110, 232, 98, 7, 255, 18, 215, 207, 5, 36, 45, 6, 7, 148, 249, 168, 79, 90, 172, 120, 14, 146, 25, 63, 6, 99, 136, 255, 249, 190, 214, 234, 1, 160, 52, 214, 154, 49, 109, 36, 110, 100 }, new byte[] { 226, 144, 144, 51, 219, 50, 63, 255, 55, 131, 86, 232, 207, 178, 179, 15, 27, 140, 191, 18, 254, 238, 154, 97, 112, 191, 230, 49, 98, 15, 100, 111, 214, 218, 213, 14, 132, 4, 3, 183, 137, 163, 85, 6, 246, 233, 214, 33, 230, 139, 10, 205, 214, 4, 238, 174, 31, 133, 174, 144, 218, 126, 20, 77, 6, 126, 174, 230, 142, 97, 80, 18, 133, 181, 71, 230, 46, 213, 131, 239, 152, 72, 195, 52, 29, 191, 49, 102, 26, 61, 12, 31, 40, 205, 148, 66, 43, 30, 30, 105, 83, 182, 129, 119, 252, 131, 39, 176, 227, 176, 244, 200, 158, 231, 112, 65, 103, 240, 209, 216, 149, 198, 201, 10, 96, 250, 174, 12 }, new DateTime(2021, 12, 17, 12, 19, 58, 95, DateTimeKind.Local).AddTicks(3720) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Name",
                keyValue: "Misc.");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Name",
                keyValue: "Sporting");

            migrationBuilder.UpdateData(
                table: "ItemListings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2021, 12, 16, 18, 8, 3, 879, DateTimeKind.Local).AddTicks(4920));

            migrationBuilder.UpdateData(
                table: "ItemListings",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2021, 12, 16, 18, 8, 3, 879, DateTimeKind.Local).AddTicks(4933));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "PasswordHash", "PasswordSalt", "UpdatedOn" },
                values: new object[] { new DateTime(2021, 12, 16, 18, 8, 3, 879, DateTimeKind.Local).AddTicks(3575), new byte[] { 115, 19, 131, 155, 13, 221, 232, 38, 212, 195, 231, 45, 159, 181, 149, 222, 91, 195, 208, 98, 156, 26, 148, 102, 80, 198, 71, 175, 198, 167, 59, 15, 234, 220, 140, 178, 222, 194, 232, 199, 193, 148, 248, 60, 172, 198, 158, 164, 75, 227, 231, 121, 30, 165, 57, 141, 232, 138, 115, 172, 247, 252, 66, 76 }, new byte[] { 118, 151, 94, 52, 180, 33, 149, 26, 100, 123, 2, 86, 143, 164, 127, 251, 54, 235, 19, 106, 151, 86, 116, 35, 85, 232, 53, 21, 206, 220, 6, 117, 174, 236, 105, 167, 31, 251, 40, 178, 216, 19, 161, 42, 113, 215, 217, 112, 33, 126, 192, 174, 175, 102, 44, 240, 52, 0, 244, 114, 192, 177, 147, 28, 70, 96, 113, 179, 171, 144, 233, 108, 244, 57, 76, 94, 166, 59, 79, 14, 111, 88, 205, 125, 76, 62, 20, 204, 195, 212, 250, 92, 209, 216, 135, 187, 59, 155, 60, 254, 92, 224, 6, 170, 148, 194, 152, 164, 119, 29, 89, 252, 174, 27, 216, 109, 233, 196, 139, 210, 51, 224, 222, 144, 98, 250, 88, 78 }, new DateTime(2021, 12, 16, 18, 8, 3, 879, DateTimeKind.Local).AddTicks(3577) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "PasswordHash", "PasswordSalt", "UpdatedOn" },
                values: new object[] { new DateTime(2021, 12, 16, 18, 8, 3, 879, DateTimeKind.Local).AddTicks(3610), new byte[] { 76, 239, 71, 202, 199, 5, 201, 168, 244, 106, 204, 47, 169, 116, 193, 207, 172, 92, 152, 44, 145, 210, 101, 65, 244, 71, 57, 20, 97, 112, 22, 135, 229, 103, 205, 160, 38, 16, 175, 68, 175, 188, 208, 6, 251, 67, 80, 98, 165, 120, 224, 208, 141, 100, 104, 184, 146, 123, 252, 74, 146, 8, 71, 24 }, new byte[] { 71, 224, 40, 52, 148, 178, 245, 111, 38, 185, 236, 75, 104, 55, 82, 102, 82, 110, 27, 177, 42, 92, 73, 101, 228, 129, 29, 252, 45, 160, 119, 71, 102, 106, 9, 103, 33, 106, 68, 253, 25, 235, 158, 127, 95, 64, 109, 235, 4, 255, 57, 44, 222, 54, 255, 54, 138, 31, 51, 11, 163, 251, 251, 78, 214, 84, 71, 45, 159, 159, 125, 224, 132, 89, 111, 151, 143, 207, 59, 198, 32, 53, 226, 49, 91, 237, 19, 217, 31, 78, 167, 142, 184, 205, 110, 87, 169, 217, 163, 12, 224, 242, 146, 18, 29, 140, 251, 104, 153, 129, 38, 187, 124, 101, 220, 178, 45, 182, 120, 42, 11, 29, 189, 105, 237, 193, 73, 226 }, new DateTime(2021, 12, 16, 18, 8, 3, 879, DateTimeKind.Local).AddTicks(3611) });
        }
    }
}
