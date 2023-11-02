using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library_project.Migrations
{
    /// <inheritdoc />
    public partial class smallfixes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bibliotekarze_DaneOsobowe_DanaOsobowaIDDanaOsobowa",
                table: "Bibliotekarze");

            migrationBuilder.DropIndex(
                name: "IX_Bibliotekarze_DanaOsobowaIDDanaOsobowa",
                table: "Bibliotekarze");

            migrationBuilder.DropColumn(
                name: "DanaOsobowaIDDanaOsobowa",
                table: "Bibliotekarze");

            migrationBuilder.CreateIndex(
                name: "IX_Bibliotekarze_IDDanaOsobowe",
                table: "Bibliotekarze",
                column: "IDDanaOsobowe");

            migrationBuilder.AddForeignKey(
                name: "FK_Bibliotekarze_DaneOsobowe_IDDanaOsobowe",
                table: "Bibliotekarze",
                column: "IDDanaOsobowe",
                principalTable: "DaneOsobowe",
                principalColumn: "IDDanaOsobowa",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bibliotekarze_DaneOsobowe_IDDanaOsobowe",
                table: "Bibliotekarze");

            migrationBuilder.DropIndex(
                name: "IX_Bibliotekarze_IDDanaOsobowe",
                table: "Bibliotekarze");

            migrationBuilder.AddColumn<Guid>(
                name: "DanaOsobowaIDDanaOsobowa",
                table: "Bibliotekarze",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bibliotekarze_DanaOsobowaIDDanaOsobowa",
                table: "Bibliotekarze",
                column: "DanaOsobowaIDDanaOsobowa");

            migrationBuilder.AddForeignKey(
                name: "FK_Bibliotekarze_DaneOsobowe_DanaOsobowaIDDanaOsobowa",
                table: "Bibliotekarze",
                column: "DanaOsobowaIDDanaOsobowa",
                principalTable: "DaneOsobowe",
                principalColumn: "IDDanaOsobowa");
        }
    }
}
