using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace dotnet_ef_simple_rpg_web_api.Migrations
{
    /// <inheritdoc />
    public partial class Seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Users_UserId",
                table: "Characters");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Characters",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "PasswordHash", "PasswordSalt", "Role", "Username" },
                values: new object[,]
                {
                    { 1, new byte[] { 79, 44, 120, 132, 16, 244, 17, 63, 245, 76, 78, 43, 207, 125, 242, 224, 12, 249, 10, 100, 42, 171, 248, 226, 245, 250, 37, 126, 64, 100, 108, 205, 202, 192, 229, 104, 158, 164, 201, 48, 20, 39, 77, 137, 207, 204, 241, 229, 91, 193, 17, 134, 131, 205, 137, 250, 30, 119, 13, 59, 214, 245, 200, 29 }, new byte[] { 255, 61, 59, 145, 198, 157, 163, 173, 148, 123, 3, 172, 30, 116, 240, 69, 137, 234, 28, 107, 168, 242, 32, 165, 210, 204, 7, 133, 215, 85, 58, 14, 37, 250, 66, 102, 146, 190, 25, 242, 26, 189, 26, 33, 69, 40, 175, 107, 120, 173, 197, 1, 93, 72, 139, 205, 233, 72, 67, 178, 33, 49, 137, 211, 53, 197, 173, 163, 174, 114, 125, 178, 95, 48, 192, 31, 144, 95, 248, 128, 36, 46, 65, 32, 33, 51, 53, 124, 234, 109, 116, 182, 104, 95, 120, 5, 66, 24, 182, 169, 221, 104, 17, 250, 89, 4, 187, 167, 186, 210, 21, 201, 174, 178, 179, 216, 73, 182, 227, 151, 206, 113, 44, 10, 240, 130, 251, 111 }, "", "TestUser1" },
                    { 2, new byte[] { 79, 44, 120, 132, 16, 244, 17, 63, 245, 76, 78, 43, 207, 125, 242, 224, 12, 249, 10, 100, 42, 171, 248, 226, 245, 250, 37, 126, 64, 100, 108, 205, 202, 192, 229, 104, 158, 164, 201, 48, 20, 39, 77, 137, 207, 204, 241, 229, 91, 193, 17, 134, 131, 205, 137, 250, 30, 119, 13, 59, 214, 245, 200, 29 }, new byte[] { 255, 61, 59, 145, 198, 157, 163, 173, 148, 123, 3, 172, 30, 116, 240, 69, 137, 234, 28, 107, 168, 242, 32, 165, 210, 204, 7, 133, 215, 85, 58, 14, 37, 250, 66, 102, 146, 190, 25, 242, 26, 189, 26, 33, 69, 40, 175, 107, 120, 173, 197, 1, 93, 72, 139, 205, 233, 72, 67, 178, 33, 49, 137, 211, 53, 197, 173, 163, 174, 114, 125, 178, 95, 48, 192, 31, 144, 95, 248, 128, 36, 46, 65, 32, 33, 51, 53, 124, 234, 109, 116, 182, 104, 95, 120, 5, 66, 24, 182, 169, 221, 104, 17, 250, 89, 4, 187, 167, 186, 210, 21, 201, 174, 178, 179, 216, 73, 182, 227, 151, 206, 113, 44, 10, 240, 130, 251, 111 }, "", "TestUser2" }
                });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "Class", "Defeats", "Defense", "Fights", "HitPoints", "Intelligence", "Name", "Strength", "UserId", "Victories" },
                values: new object[,]
                {
                    { 1, 5, 0, 60, 0, 100, 90, "TestCharacter1", 60, 1, 0 },
                    { 2, 1, 0, 50, 0, 100, 80, "TestCharacter2", 50, 2, 0 },
                    { 3, 1, 0, 50, 0, 100, 80, "TestCharacter3", 50, 2, 0 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Users_UserId",
                table: "Characters",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Users_UserId",
                table: "Characters");

            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Characters",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Users_UserId",
                table: "Characters",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
