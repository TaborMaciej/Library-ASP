using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library_project.Migrations
{
    /// <inheritdoc />
    public partial class NewDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IDDanaOsobowa",
                table: "Czytelnicy",
                newName: "IDDanaOsobowe");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IDDanaOsobowe",
                table: "Czytelnicy",
                newName: "IDDanaOsobowa");
        }
    }
}
