using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library_project.Migrations
{
    /// <inheritdoc />
    public partial class ChangedTypo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LiczbaStrong",
                table: "Ksiazki",
                newName: "LiczbaStron");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LiczbaStron",
                table: "Ksiazki",
                newName: "LiczbaStrong");
        }
    }
}
