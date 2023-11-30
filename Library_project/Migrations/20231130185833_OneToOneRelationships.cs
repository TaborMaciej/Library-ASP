using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library_project.Migrations
{
    /// <inheritdoc />
    public partial class OneToOneRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropIndex(
                name: "IX_Czytelnicy_IDDanaLogowania",
                table: "Czytelnicy");

            migrationBuilder.DropIndex(
                name: "IX_Czytelnicy_IDDanaOsobowe",
                table: "Czytelnicy");

            migrationBuilder.DropIndex(
                name: "IX_Bibliotekarze_IDDanaLogowania",
                table: "Bibliotekarze");

            migrationBuilder.DropIndex(
                name: "IX_Bibliotekarze_IDDanaOsobowe",
                table: "Bibliotekarze");

            migrationBuilder.DropIndex(
                name: "IX_Admini_IDDanaLogowania",
                table: "Admini");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DanaLogowania",
                table: "DanaLogowania");

            migrationBuilder.RenameTable(
                name: "DanaLogowania",
                newName: "DaneLogowania");

            migrationBuilder.AddColumn<bool>(
                name: "CzyAutor",
                table: "Osoby",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DaneLogowania",
                table: "DaneLogowania",
                column: "IDDanaLogowania");

            migrationBuilder.CreateIndex(
                name: "IX_Czytelnicy_IDDanaLogowania",
                table: "Czytelnicy",
                column: "IDDanaLogowania",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Czytelnicy_IDDanaOsobowe",
                table: "Czytelnicy",
                column: "IDDanaOsobowe",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bibliotekarze_IDDanaLogowania",
                table: "Bibliotekarze",
                column: "IDDanaLogowania",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bibliotekarze_IDDanaOsobowe",
                table: "Bibliotekarze",
                column: "IDDanaOsobowe",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Admini_IDDanaLogowania",
                table: "Admini",
                column: "IDDanaLogowania",
                unique: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropIndex(
                name: "IX_Czytelnicy_IDDanaLogowania",
                table: "Czytelnicy");

            migrationBuilder.DropIndex(
                name: "IX_Czytelnicy_IDDanaOsobowe",
                table: "Czytelnicy");

            migrationBuilder.DropIndex(
                name: "IX_Bibliotekarze_IDDanaLogowania",
                table: "Bibliotekarze");

            migrationBuilder.DropIndex(
                name: "IX_Bibliotekarze_IDDanaOsobowe",
                table: "Bibliotekarze");

            migrationBuilder.DropIndex(
                name: "IX_Admini_IDDanaLogowania",
                table: "Admini");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DaneLogowania",
                table: "DaneLogowania");

            migrationBuilder.DropColumn(
                name: "CzyAutor",
                table: "Osoby");

            migrationBuilder.RenameTable(
                name: "DaneLogowania",
                newName: "DanaLogowania");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DanaLogowania",
                table: "DanaLogowania",
                column: "IDDanaLogowania");

            migrationBuilder.CreateIndex(
                name: "IX_Czytelnicy_IDDanaLogowania",
                table: "Czytelnicy",
                column: "IDDanaLogowania");

            migrationBuilder.CreateIndex(
                name: "IX_Czytelnicy_IDDanaOsobowe",
                table: "Czytelnicy",
                column: "IDDanaOsobowe");

            migrationBuilder.CreateIndex(
                name: "IX_Bibliotekarze_IDDanaLogowania",
                table: "Bibliotekarze",
                column: "IDDanaLogowania");

            migrationBuilder.CreateIndex(
                name: "IX_Bibliotekarze_IDDanaOsobowe",
                table: "Bibliotekarze",
                column: "IDDanaOsobowe");

            migrationBuilder.CreateIndex(
                name: "IX_Admini_IDDanaLogowania",
                table: "Admini",
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
    }
}
