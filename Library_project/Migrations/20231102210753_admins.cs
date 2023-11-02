using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library_project.Migrations
{
    /// <inheritdoc />
    public partial class admins : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admini",
                columns: table => new
                {
                    IDAdmin = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDDanaLogowania = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DanaLogowaniaIDDanaLogowania = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admini", x => x.IDAdmin);
                    table.ForeignKey(
                        name: "FK_Admini_DaneLogowania_DanaLogowaniaIDDanaLogowania",
                        column: x => x.DanaLogowaniaIDDanaLogowania,
                        principalTable: "DaneLogowania",
                        principalColumn: "IDDanaLogowania");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Admini_DanaLogowaniaIDDanaLogowania",
                table: "Admini",
                column: "DanaLogowaniaIDDanaLogowania");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admini");
        }
    }
}
