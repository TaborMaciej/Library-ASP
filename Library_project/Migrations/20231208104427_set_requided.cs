using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library_project.Migrations
{
    /// <inheritdoc />
    public partial class set_requided : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Egzemplarze_Ksiazki_ISBN",
                table: "Egzemplarze");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataOddania",
                table: "Wypozyczenia",
                type: "Date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "Date",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ISBN",
                table: "Egzemplarze",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Egzemplarze_Ksiazki_ISBN",
                table: "Egzemplarze",
                column: "ISBN",
                principalTable: "Ksiazki",
                principalColumn: "ISBN");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Egzemplarze_Ksiazki_ISBN",
                table: "Egzemplarze");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataOddania",
                table: "Wypozyczenia",
                type: "Date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "Date");

            migrationBuilder.AlterColumn<string>(
                name: "ISBN",
                table: "Egzemplarze",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Egzemplarze_Ksiazki_ISBN",
                table: "Egzemplarze",
                column: "ISBN",
                principalTable: "Ksiazki",
                principalColumn: "ISBN",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
