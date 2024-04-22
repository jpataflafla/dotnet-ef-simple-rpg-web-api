using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dotnet_ef_simple_rpg_web_api.Migrations
{
    /// <inheritdoc />
    public partial class SkillsColumnRename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Damage",
                table: "Skills",
                newName: "Complexity");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Complexity",
                table: "Skills",
                newName: "Damage");
        }
    }
}
