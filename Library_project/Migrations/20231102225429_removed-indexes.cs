using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library_project.Migrations
{
    /// <inheritdoc />
    public partial class removedindexes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bibliotekarze_DaneLogowania_DanaLogowaniaIDDanaLogowania",
                table: "Bibliotekarze");

            migrationBuilder.DropForeignKey(
                name: "FK_Czytelnicy_DaneLogowania_DanaLogowaniaIDDanaLogowania",
                table: "Czytelnicy");

            migrationBuilder.DropForeignKey(
                name: "FK_Czytelnicy_DaneOsobowe_DanaOsobowaIDDanaOsobowa",
                table: "Czytelnicy");

            migrationBuilder.DropForeignKey(
                name: "FK_DaneOsobowe_Adresy_AdresIDAdres",
                table: "DaneOsobowe");

            migrationBuilder.DropForeignKey(
                name: "FK_DaneOsobowe_Osoby_OsobaIDOsoba",
                table: "DaneOsobowe");

            migrationBuilder.DropForeignKey(
                name: "FK_Egzemplarze_Ksiazki_KsiazkaISBN",
                table: "Egzemplarze");

            migrationBuilder.DropForeignKey(
                name: "FK_KsiazkaAutorzy_Ksiazki_KsiazkaISBN",
                table: "KsiazkaAutorzy");

            migrationBuilder.DropForeignKey(
                name: "FK_KsiazkaAutorzy_Osoby_OsobaIDOsoba",
                table: "KsiazkaAutorzy");

            migrationBuilder.DropForeignKey(
                name: "FK_Ksiazki_Gatunki_GatunekIDGatunek",
                table: "Ksiazki");

            migrationBuilder.DropForeignKey(
                name: "FK_Ksiazki_Wydawnictwa_WydawnictwoIDWydawnictwo",
                table: "Ksiazki");

            migrationBuilder.DropForeignKey(
                name: "FK_Miasta_Wojewodztwa_WojewodztwoIDWojewodztwo",
                table: "Miasta");

            migrationBuilder.DropForeignKey(
                name: "FK_Ulice_Miasta_MiastoIDMiasto",
                table: "Ulice");

            migrationBuilder.DropForeignKey(
                name: "FK_WypozyczenieEgzemplarze_Egzemplarze_EgzemplarzIDEgzemplarz",
                table: "WypozyczenieEgzemplarze");

            migrationBuilder.DropForeignKey(
                name: "FK_WypozyczenieEgzemplarze_Wypozyczenia_WypozyczenieIDWypozyczenie",
                table: "WypozyczenieEgzemplarze");

            migrationBuilder.DropIndex(
                name: "IX_WypozyczenieEgzemplarze_EgzemplarzIDEgzemplarz",
                table: "WypozyczenieEgzemplarze");

            migrationBuilder.DropIndex(
                name: "IX_WypozyczenieEgzemplarze_WypozyczenieIDWypozyczenie",
                table: "WypozyczenieEgzemplarze");

            migrationBuilder.DropIndex(
                name: "IX_Ulice_MiastoIDMiasto",
                table: "Ulice");

            migrationBuilder.DropIndex(
                name: "IX_Miasta_WojewodztwoIDWojewodztwo",
                table: "Miasta");

            migrationBuilder.DropIndex(
                name: "IX_Ksiazki_GatunekIDGatunek",
                table: "Ksiazki");

            migrationBuilder.DropIndex(
                name: "IX_Ksiazki_WydawnictwoIDWydawnictwo",
                table: "Ksiazki");

            migrationBuilder.DropIndex(
                name: "IX_KsiazkaAutorzy_KsiazkaISBN",
                table: "KsiazkaAutorzy");

            migrationBuilder.DropIndex(
                name: "IX_KsiazkaAutorzy_OsobaIDOsoba",
                table: "KsiazkaAutorzy");

            migrationBuilder.DropIndex(
                name: "IX_Egzemplarze_KsiazkaISBN",
                table: "Egzemplarze");

            migrationBuilder.DropIndex(
                name: "IX_DaneOsobowe_AdresIDAdres",
                table: "DaneOsobowe");

            migrationBuilder.DropIndex(
                name: "IX_DaneOsobowe_OsobaIDOsoba",
                table: "DaneOsobowe");

            migrationBuilder.DropIndex(
                name: "IX_Czytelnicy_DanaLogowaniaIDDanaLogowania",
                table: "Czytelnicy");

            migrationBuilder.DropIndex(
                name: "IX_Czytelnicy_DanaOsobowaIDDanaOsobowa",
                table: "Czytelnicy");

            migrationBuilder.DropIndex(
                name: "IX_Bibliotekarze_DanaLogowaniaIDDanaLogowania",
                table: "Bibliotekarze");

            migrationBuilder.DropColumn(
                name: "EgzemplarzIDEgzemplarz",
                table: "WypozyczenieEgzemplarze");

            migrationBuilder.DropColumn(
                name: "WypozyczenieIDWypozyczenie",
                table: "WypozyczenieEgzemplarze");

            migrationBuilder.DropColumn(
                name: "MiastoIDMiasto",
                table: "Ulice");

            migrationBuilder.DropColumn(
                name: "WojewodztwoIDWojewodztwo",
                table: "Miasta");

            migrationBuilder.DropColumn(
                name: "GatunekIDGatunek",
                table: "Ksiazki");

            migrationBuilder.DropColumn(
                name: "WydawnictwoIDWydawnictwo",
                table: "Ksiazki");

            migrationBuilder.DropColumn(
                name: "IDKsiazka",
                table: "KsiazkaAutorzy");

            migrationBuilder.DropColumn(
                name: "KsiazkaISBN",
                table: "KsiazkaAutorzy");

            migrationBuilder.DropColumn(
                name: "OsobaIDOsoba",
                table: "KsiazkaAutorzy");

            migrationBuilder.DropColumn(
                name: "IDKsiazka",
                table: "Egzemplarze");

            migrationBuilder.DropColumn(
                name: "KsiazkaISBN",
                table: "Egzemplarze");

            migrationBuilder.DropColumn(
                name: "AdresIDAdres",
                table: "DaneOsobowe");

            migrationBuilder.DropColumn(
                name: "OsobaIDOsoba",
                table: "DaneOsobowe");

            migrationBuilder.DropColumn(
                name: "DanaLogowaniaIDDanaLogowania",
                table: "Czytelnicy");

            migrationBuilder.DropColumn(
                name: "DanaOsobowaIDDanaOsobowa",
                table: "Czytelnicy");

            migrationBuilder.DropColumn(
                name: "DanaLogowaniaIDDanaLogowania",
                table: "Bibliotekarze");

            migrationBuilder.AddColumn<string>(
                name: "ISBN",
                table: "KsiazkaAutorzy",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ISBN",
                table: "Egzemplarze",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_WypozyczenieEgzemplarze_IDEgzemplarz",
                table: "WypozyczenieEgzemplarze",
                column: "IDEgzemplarz");

            migrationBuilder.CreateIndex(
                name: "IX_WypozyczenieEgzemplarze_IDWypozyczenia",
                table: "WypozyczenieEgzemplarze",
                column: "IDWypozyczenia");

            migrationBuilder.CreateIndex(
                name: "IX_Wypozyczenia_IDBibliotekarza",
                table: "Wypozyczenia",
                column: "IDBibliotekarza");

            migrationBuilder.CreateIndex(
                name: "IX_Wypozyczenia_IDCzytelnika",
                table: "Wypozyczenia",
                column: "IDCzytelnika");

            migrationBuilder.CreateIndex(
                name: "IX_Ulice_IDMiasto",
                table: "Ulice",
                column: "IDMiasto");

            migrationBuilder.CreateIndex(
                name: "IX_Miasta_IDWojewodztwo",
                table: "Miasta",
                column: "IDWojewodztwo");

            migrationBuilder.CreateIndex(
                name: "IX_Ksiazki_IDGatunek",
                table: "Ksiazki",
                column: "IDGatunek");

            migrationBuilder.CreateIndex(
                name: "IX_Ksiazki_IDWydawnictwo",
                table: "Ksiazki",
                column: "IDWydawnictwo");

            migrationBuilder.CreateIndex(
                name: "IX_KsiazkaAutorzy_IDOsoba",
                table: "KsiazkaAutorzy",
                column: "IDOsoba");

            migrationBuilder.CreateIndex(
                name: "IX_KsiazkaAutorzy_ISBN",
                table: "KsiazkaAutorzy",
                column: "ISBN");

            migrationBuilder.CreateIndex(
                name: "IX_Egzemplarze_ISBN",
                table: "Egzemplarze",
                column: "ISBN");

            migrationBuilder.CreateIndex(
                name: "IX_DaneOsobowe_IDAdres",
                table: "DaneOsobowe",
                column: "IDAdres");

            migrationBuilder.CreateIndex(
                name: "IX_DaneOsobowe_IDOsoba",
                table: "DaneOsobowe",
                column: "IDOsoba");

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
                name: "IX_Adresy_IDUlica",
                table: "Adresy",
                column: "IDUlica");

            migrationBuilder.AddForeignKey(
                name: "FK_Adresy_Ulice_IDUlica",
                table: "Adresy",
                column: "IDUlica",
                principalTable: "Ulice",
                principalColumn: "IDUlica",
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

            migrationBuilder.AddForeignKey(
                name: "FK_Czytelnicy_DaneOsobowe_IDDanaOsobowe",
                table: "Czytelnicy",
                column: "IDDanaOsobowe",
                principalTable: "DaneOsobowe",
                principalColumn: "IDDanaOsobowa",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DaneOsobowe_Adresy_IDAdres",
                table: "DaneOsobowe",
                column: "IDAdres",
                principalTable: "Adresy",
                principalColumn: "IDAdres",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DaneOsobowe_Osoby_IDOsoba",
                table: "DaneOsobowe",
                column: "IDOsoba",
                principalTable: "Osoby",
                principalColumn: "IDOsoba",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Egzemplarze_Ksiazki_ISBN",
                table: "Egzemplarze",
                column: "ISBN",
                principalTable: "Ksiazki",
                principalColumn: "ISBN",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KsiazkaAutorzy_Ksiazki_ISBN",
                table: "KsiazkaAutorzy",
                column: "ISBN",
                principalTable: "Ksiazki",
                principalColumn: "ISBN",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KsiazkaAutorzy_Osoby_IDOsoba",
                table: "KsiazkaAutorzy",
                column: "IDOsoba",
                principalTable: "Osoby",
                principalColumn: "IDOsoba",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ksiazki_Gatunki_IDGatunek",
                table: "Ksiazki",
                column: "IDGatunek",
                principalTable: "Gatunki",
                principalColumn: "IDGatunek",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ksiazki_Wydawnictwa_IDWydawnictwo",
                table: "Ksiazki",
                column: "IDWydawnictwo",
                principalTable: "Wydawnictwa",
                principalColumn: "IDWydawnictwo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Miasta_Wojewodztwa_IDWojewodztwo",
                table: "Miasta",
                column: "IDWojewodztwo",
                principalTable: "Wojewodztwa",
                principalColumn: "IDWojewodztwo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ulice_Miasta_IDMiasto",
                table: "Ulice",
                column: "IDMiasto",
                principalTable: "Miasta",
                principalColumn: "IDMiasto",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Wypozyczenia_Bibliotekarze_IDBibliotekarza",
                table: "Wypozyczenia",
                column: "IDBibliotekarza",
                principalTable: "Bibliotekarze",
                principalColumn: "IDBibliotekarz");

            migrationBuilder.AddForeignKey(
                name: "FK_Wypozyczenia_Czytelnicy_IDCzytelnika",
                table: "Wypozyczenia",
                column: "IDCzytelnika",
                principalTable: "Czytelnicy",
                principalColumn: "IDCzytelnik");

            migrationBuilder.AddForeignKey(
                name: "FK_WypozyczenieEgzemplarze_Egzemplarze_IDEgzemplarz",
                table: "WypozyczenieEgzemplarze",
                column: "IDEgzemplarz",
                principalTable: "Egzemplarze",
                principalColumn: "IDEgzemplarz",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WypozyczenieEgzemplarze_Wypozyczenia_IDWypozyczenia",
                table: "WypozyczenieEgzemplarze",
                column: "IDWypozyczenia",
                principalTable: "Wypozyczenia",
                principalColumn: "IDWypozyczenie",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adresy_Ulice_IDUlica",
                table: "Adresy");

            migrationBuilder.DropForeignKey(
                name: "FK_Bibliotekarze_DaneLogowania_IDDanaLogowania",
                table: "Bibliotekarze");

            migrationBuilder.DropForeignKey(
                name: "FK_Czytelnicy_DaneLogowania_IDDanaLogowania",
                table: "Czytelnicy");

            migrationBuilder.DropForeignKey(
                name: "FK_Czytelnicy_DaneOsobowe_IDDanaOsobowe",
                table: "Czytelnicy");

            migrationBuilder.DropForeignKey(
                name: "FK_DaneOsobowe_Adresy_IDAdres",
                table: "DaneOsobowe");

            migrationBuilder.DropForeignKey(
                name: "FK_DaneOsobowe_Osoby_IDOsoba",
                table: "DaneOsobowe");

            migrationBuilder.DropForeignKey(
                name: "FK_Egzemplarze_Ksiazki_ISBN",
                table: "Egzemplarze");

            migrationBuilder.DropForeignKey(
                name: "FK_KsiazkaAutorzy_Ksiazki_ISBN",
                table: "KsiazkaAutorzy");

            migrationBuilder.DropForeignKey(
                name: "FK_KsiazkaAutorzy_Osoby_IDOsoba",
                table: "KsiazkaAutorzy");

            migrationBuilder.DropForeignKey(
                name: "FK_Ksiazki_Gatunki_IDGatunek",
                table: "Ksiazki");

            migrationBuilder.DropForeignKey(
                name: "FK_Ksiazki_Wydawnictwa_IDWydawnictwo",
                table: "Ksiazki");

            migrationBuilder.DropForeignKey(
                name: "FK_Miasta_Wojewodztwa_IDWojewodztwo",
                table: "Miasta");

            migrationBuilder.DropForeignKey(
                name: "FK_Ulice_Miasta_IDMiasto",
                table: "Ulice");

            migrationBuilder.DropForeignKey(
                name: "FK_Wypozyczenia_Bibliotekarze_IDBibliotekarza",
                table: "Wypozyczenia");

            migrationBuilder.DropForeignKey(
                name: "FK_Wypozyczenia_Czytelnicy_IDCzytelnika",
                table: "Wypozyczenia");

            migrationBuilder.DropForeignKey(
                name: "FK_WypozyczenieEgzemplarze_Egzemplarze_IDEgzemplarz",
                table: "WypozyczenieEgzemplarze");

            migrationBuilder.DropForeignKey(
                name: "FK_WypozyczenieEgzemplarze_Wypozyczenia_IDWypozyczenia",
                table: "WypozyczenieEgzemplarze");

            migrationBuilder.DropIndex(
                name: "IX_WypozyczenieEgzemplarze_IDEgzemplarz",
                table: "WypozyczenieEgzemplarze");

            migrationBuilder.DropIndex(
                name: "IX_WypozyczenieEgzemplarze_IDWypozyczenia",
                table: "WypozyczenieEgzemplarze");

            migrationBuilder.DropIndex(
                name: "IX_Wypozyczenia_IDBibliotekarza",
                table: "Wypozyczenia");

            migrationBuilder.DropIndex(
                name: "IX_Wypozyczenia_IDCzytelnika",
                table: "Wypozyczenia");

            migrationBuilder.DropIndex(
                name: "IX_Ulice_IDMiasto",
                table: "Ulice");

            migrationBuilder.DropIndex(
                name: "IX_Miasta_IDWojewodztwo",
                table: "Miasta");

            migrationBuilder.DropIndex(
                name: "IX_Ksiazki_IDGatunek",
                table: "Ksiazki");

            migrationBuilder.DropIndex(
                name: "IX_Ksiazki_IDWydawnictwo",
                table: "Ksiazki");

            migrationBuilder.DropIndex(
                name: "IX_KsiazkaAutorzy_IDOsoba",
                table: "KsiazkaAutorzy");

            migrationBuilder.DropIndex(
                name: "IX_KsiazkaAutorzy_ISBN",
                table: "KsiazkaAutorzy");

            migrationBuilder.DropIndex(
                name: "IX_Egzemplarze_ISBN",
                table: "Egzemplarze");

            migrationBuilder.DropIndex(
                name: "IX_DaneOsobowe_IDAdres",
                table: "DaneOsobowe");

            migrationBuilder.DropIndex(
                name: "IX_DaneOsobowe_IDOsoba",
                table: "DaneOsobowe");

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
                name: "IX_Adresy_IDUlica",
                table: "Adresy");

            migrationBuilder.DropColumn(
                name: "ISBN",
                table: "KsiazkaAutorzy");

            migrationBuilder.DropColumn(
                name: "ISBN",
                table: "Egzemplarze");

            migrationBuilder.AddColumn<Guid>(
                name: "EgzemplarzIDEgzemplarz",
                table: "WypozyczenieEgzemplarze",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "WypozyczenieIDWypozyczenie",
                table: "WypozyczenieEgzemplarze",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "MiastoIDMiasto",
                table: "Ulice",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "WojewodztwoIDWojewodztwo",
                table: "Miasta",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "GatunekIDGatunek",
                table: "Ksiazki",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "WydawnictwoIDWydawnictwo",
                table: "Ksiazki",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IDKsiazka",
                table: "KsiazkaAutorzy",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "KsiazkaISBN",
                table: "KsiazkaAutorzy",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "OsobaIDOsoba",
                table: "KsiazkaAutorzy",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IDKsiazka",
                table: "Egzemplarze",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "KsiazkaISBN",
                table: "Egzemplarze",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "AdresIDAdres",
                table: "DaneOsobowe",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "OsobaIDOsoba",
                table: "DaneOsobowe",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DanaLogowaniaIDDanaLogowania",
                table: "Czytelnicy",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DanaOsobowaIDDanaOsobowa",
                table: "Czytelnicy",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DanaLogowaniaIDDanaLogowania",
                table: "Bibliotekarze",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WypozyczenieEgzemplarze_EgzemplarzIDEgzemplarz",
                table: "WypozyczenieEgzemplarze",
                column: "EgzemplarzIDEgzemplarz");

            migrationBuilder.CreateIndex(
                name: "IX_WypozyczenieEgzemplarze_WypozyczenieIDWypozyczenie",
                table: "WypozyczenieEgzemplarze",
                column: "WypozyczenieIDWypozyczenie");

            migrationBuilder.CreateIndex(
                name: "IX_Ulice_MiastoIDMiasto",
                table: "Ulice",
                column: "MiastoIDMiasto");

            migrationBuilder.CreateIndex(
                name: "IX_Miasta_WojewodztwoIDWojewodztwo",
                table: "Miasta",
                column: "WojewodztwoIDWojewodztwo");

            migrationBuilder.CreateIndex(
                name: "IX_Ksiazki_GatunekIDGatunek",
                table: "Ksiazki",
                column: "GatunekIDGatunek");

            migrationBuilder.CreateIndex(
                name: "IX_Ksiazki_WydawnictwoIDWydawnictwo",
                table: "Ksiazki",
                column: "WydawnictwoIDWydawnictwo");

            migrationBuilder.CreateIndex(
                name: "IX_KsiazkaAutorzy_KsiazkaISBN",
                table: "KsiazkaAutorzy",
                column: "KsiazkaISBN");

            migrationBuilder.CreateIndex(
                name: "IX_KsiazkaAutorzy_OsobaIDOsoba",
                table: "KsiazkaAutorzy",
                column: "OsobaIDOsoba");

            migrationBuilder.CreateIndex(
                name: "IX_Egzemplarze_KsiazkaISBN",
                table: "Egzemplarze",
                column: "KsiazkaISBN");

            migrationBuilder.CreateIndex(
                name: "IX_DaneOsobowe_AdresIDAdres",
                table: "DaneOsobowe",
                column: "AdresIDAdres");

            migrationBuilder.CreateIndex(
                name: "IX_DaneOsobowe_OsobaIDOsoba",
                table: "DaneOsobowe",
                column: "OsobaIDOsoba");

            migrationBuilder.CreateIndex(
                name: "IX_Czytelnicy_DanaLogowaniaIDDanaLogowania",
                table: "Czytelnicy",
                column: "DanaLogowaniaIDDanaLogowania");

            migrationBuilder.CreateIndex(
                name: "IX_Czytelnicy_DanaOsobowaIDDanaOsobowa",
                table: "Czytelnicy",
                column: "DanaOsobowaIDDanaOsobowa");

            migrationBuilder.CreateIndex(
                name: "IX_Bibliotekarze_DanaLogowaniaIDDanaLogowania",
                table: "Bibliotekarze",
                column: "DanaLogowaniaIDDanaLogowania");

            migrationBuilder.AddForeignKey(
                name: "FK_Bibliotekarze_DaneLogowania_DanaLogowaniaIDDanaLogowania",
                table: "Bibliotekarze",
                column: "DanaLogowaniaIDDanaLogowania",
                principalTable: "DaneLogowania",
                principalColumn: "IDDanaLogowania");

            migrationBuilder.AddForeignKey(
                name: "FK_Czytelnicy_DaneLogowania_DanaLogowaniaIDDanaLogowania",
                table: "Czytelnicy",
                column: "DanaLogowaniaIDDanaLogowania",
                principalTable: "DaneLogowania",
                principalColumn: "IDDanaLogowania");

            migrationBuilder.AddForeignKey(
                name: "FK_Czytelnicy_DaneOsobowe_DanaOsobowaIDDanaOsobowa",
                table: "Czytelnicy",
                column: "DanaOsobowaIDDanaOsobowa",
                principalTable: "DaneOsobowe",
                principalColumn: "IDDanaOsobowa");

            migrationBuilder.AddForeignKey(
                name: "FK_DaneOsobowe_Adresy_AdresIDAdres",
                table: "DaneOsobowe",
                column: "AdresIDAdres",
                principalTable: "Adresy",
                principalColumn: "IDAdres");

            migrationBuilder.AddForeignKey(
                name: "FK_DaneOsobowe_Osoby_OsobaIDOsoba",
                table: "DaneOsobowe",
                column: "OsobaIDOsoba",
                principalTable: "Osoby",
                principalColumn: "IDOsoba");

            migrationBuilder.AddForeignKey(
                name: "FK_Egzemplarze_Ksiazki_KsiazkaISBN",
                table: "Egzemplarze",
                column: "KsiazkaISBN",
                principalTable: "Ksiazki",
                principalColumn: "ISBN");

            migrationBuilder.AddForeignKey(
                name: "FK_KsiazkaAutorzy_Ksiazki_KsiazkaISBN",
                table: "KsiazkaAutorzy",
                column: "KsiazkaISBN",
                principalTable: "Ksiazki",
                principalColumn: "ISBN");

            migrationBuilder.AddForeignKey(
                name: "FK_KsiazkaAutorzy_Osoby_OsobaIDOsoba",
                table: "KsiazkaAutorzy",
                column: "OsobaIDOsoba",
                principalTable: "Osoby",
                principalColumn: "IDOsoba");

            migrationBuilder.AddForeignKey(
                name: "FK_Ksiazki_Gatunki_GatunekIDGatunek",
                table: "Ksiazki",
                column: "GatunekIDGatunek",
                principalTable: "Gatunki",
                principalColumn: "IDGatunek");

            migrationBuilder.AddForeignKey(
                name: "FK_Ksiazki_Wydawnictwa_WydawnictwoIDWydawnictwo",
                table: "Ksiazki",
                column: "WydawnictwoIDWydawnictwo",
                principalTable: "Wydawnictwa",
                principalColumn: "IDWydawnictwo");

            migrationBuilder.AddForeignKey(
                name: "FK_Miasta_Wojewodztwa_WojewodztwoIDWojewodztwo",
                table: "Miasta",
                column: "WojewodztwoIDWojewodztwo",
                principalTable: "Wojewodztwa",
                principalColumn: "IDWojewodztwo");

            migrationBuilder.AddForeignKey(
                name: "FK_Ulice_Miasta_MiastoIDMiasto",
                table: "Ulice",
                column: "MiastoIDMiasto",
                principalTable: "Miasta",
                principalColumn: "IDMiasto");

            migrationBuilder.AddForeignKey(
                name: "FK_WypozyczenieEgzemplarze_Egzemplarze_EgzemplarzIDEgzemplarz",
                table: "WypozyczenieEgzemplarze",
                column: "EgzemplarzIDEgzemplarz",
                principalTable: "Egzemplarze",
                principalColumn: "IDEgzemplarz");

            migrationBuilder.AddForeignKey(
                name: "FK_WypozyczenieEgzemplarze_Wypozyczenia_WypozyczenieIDWypozyczenie",
                table: "WypozyczenieEgzemplarze",
                column: "WypozyczenieIDWypozyczenie",
                principalTable: "Wypozyczenia",
                principalColumn: "IDWypozyczenie");
        }
    }
}
