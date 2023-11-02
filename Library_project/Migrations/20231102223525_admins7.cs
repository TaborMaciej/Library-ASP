using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library_project.Migrations
{
    /// <inheritdoc />
    public partial class admins7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admini_DaneLogowania_DanaLogowaniaIDDanaLogowania",
                table: "Admini");

            migrationBuilder.DropIndex(
                name: "IX_Admini_DanaLogowaniaIDDanaLogowania",
                table: "Admini");

            migrationBuilder.DropColumn(
                name: "DanaLogowaniaIDDanaLogowania",
                table: "Admini");

            migrationBuilder.CreateIndex(
                name: "IX_Admini_IDDanaLogowania",
                table: "Admini",
                column: "IDDanaLogowania");

            migrationBuilder.AddForeignKey(
                name: "FK_Admini_DaneLogowania_IDDanaLogowania",
                table: "Admini",
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

            migrationBuilder.DropIndex(
                name: "IX_Admini_IDDanaLogowania",
                table: "Admini");

            migrationBuilder.AddColumn<Guid>(
                name: "DanaLogowaniaIDDanaLogowania",
                table: "Admini",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Admini_DanaLogowaniaIDDanaLogowania",
                table: "Admini",
                column: "DanaLogowaniaIDDanaLogowania");

            migrationBuilder.AddForeignKey(
                name: "FK_Admini_DaneLogowania_DanaLogowaniaIDDanaLogowania",
                table: "Admini",
                column: "DanaLogowaniaIDDanaLogowania",
                principalTable: "DaneLogowania",
                principalColumn: "IDDanaLogowania");
        }
    }
}
