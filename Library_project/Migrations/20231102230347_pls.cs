using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library_project.Migrations
{
    /// <inheritdoc />
    public partial class pls : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admini_DaneLogowania_IDDanaLogowania",
                table: "Admini");

            migrationBuilder.DropForeignKey(
                name: "FK_Bibliotekarze_DaneLogowania_IDDanaLogowania",
                table: "Bibliotekarze");

            migrationBuilder.DropForeignKey(
                name: "FK_Czytelnicy_DaneLogowania_IDDanaLogowania",
                table: "Czytelnicy");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DaneLogowania",
                table: "DaneLogowania");

            migrationBuilder.RenameTable(
                name: "DaneLogowania",
                newName: "DanaLogowania");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DanaLogowania",
                table: "DanaLogowania",
                column: "IDDanaLogowania");

            migrationBuilder.AddForeignKey(
                name: "FK_Admini_DanaLogowania_IDDanaLogowania",
                table: "Admini",
                column: "IDDanaLogowania",
                principalTable: "DanaLogowania",
                principalColumn: "IDDanaLogowania",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bibliotekarze_DanaLogowania_IDDanaLogowania",
                table: "Bibliotekarze",
                column: "IDDanaLogowania",
                principalTable: "DanaLogowania",
                principalColumn: "IDDanaLogowania",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Czytelnicy_DanaLogowania_IDDanaLogowania",
                table: "Czytelnicy",
                column: "IDDanaLogowania",
                principalTable: "DanaLogowania",
                principalColumn: "IDDanaLogowania",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admini_DanaLogowania_IDDanaLogowania",
                table: "Admini");

            migrationBuilder.DropForeignKey(
                name: "FK_Bibliotekarze_DanaLogowania_IDDanaLogowania",
                table: "Bibliotekarze");

            migrationBuilder.DropForeignKey(
                name: "FK_Czytelnicy_DanaLogowania_IDDanaLogowania",
                table: "Czytelnicy");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DanaLogowania",
                table: "DanaLogowania");

            migrationBuilder.RenameTable(
                name: "DanaLogowania",
                newName: "DaneLogowania");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DaneLogowania",
                table: "DaneLogowania",
                column: "IDDanaLogowania");

            migrationBuilder.AddForeignKey(
                name: "FK_Admini_DaneLogowania_IDDanaLogowania",
                table: "Admini",
                column: "IDDanaLogowania",
                principalTable: "DaneLogowania",
                principalColumn: "IDDanaLogowania",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bibliotekarze_DaneLogowania_IDDanaLogowania",
                table: "Bibliotekarze",
                column: "IDDanaLogowania",
                principalTable: "DaneLogowania",
                principalColumn: "IDDanaLogowania",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Czytelnicy_DaneLogowania_IDDanaLogowania",
                table: "Czytelnicy",
                column: "IDDanaLogowania",
                principalTable: "DaneLogowania",
                principalColumn: "IDDanaLogowania",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
