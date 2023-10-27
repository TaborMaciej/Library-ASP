using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library_project.Migrations
{
    /// <inheritdoc />
    public partial class firstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DaneLogowania",
                columns: table => new
                {
                    IDDanaLogowania = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Haslo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DaneLogowania", x => x.IDDanaLogowania);
                });

            migrationBuilder.CreateTable(
                name: "Gatunki",
                columns: table => new
                {
                    IDGatunek = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gatunki", x => x.IDGatunek);
                });

            migrationBuilder.CreateTable(
                name: "Osoby",
                columns: table => new
                {
                    IDOsoba = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Imie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nazwisko = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataUrodzenia = table.Column<DateTime>(type: "Date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Osoby", x => x.IDOsoba);
                });

            migrationBuilder.CreateTable(
                name: "Wojewodztwa",
                columns: table => new
                {
                    IDWojewodztwo = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wojewodztwa", x => x.IDWojewodztwo);
                });

            migrationBuilder.CreateTable(
                name: "Wydawnictwa",
                columns: table => new
                {
                    IDWydawnictwo = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wydawnictwa", x => x.IDWydawnictwo);
                });

            migrationBuilder.CreateTable(
                name: "Miasta",
                columns: table => new
                {
                    IDMiasto = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IDWojewodztwo = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WojewodztwoIDWojewodztwo = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Miasta", x => x.IDMiasto);
                    table.ForeignKey(
                        name: "FK_Miasta_Wojewodztwa_WojewodztwoIDWojewodztwo",
                        column: x => x.WojewodztwoIDWojewodztwo,
                        principalTable: "Wojewodztwa",
                        principalColumn: "IDWojewodztwo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ksiazki",
                columns: table => new
                {
                    ISBN = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Tytul = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RokWydania = table.Column<int>(type: "int", nullable: false),
                    LiczbaStrong = table.Column<int>(type: "int", nullable: false),
                    IDWydawnictwo = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WydawnictwoIDWydawnictwo = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDGatunek = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GatunekIDGatunek = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ksiazki", x => x.ISBN);
                    table.ForeignKey(
                        name: "FK_Ksiazki_Gatunki_GatunekIDGatunek",
                        column: x => x.GatunekIDGatunek,
                        principalTable: "Gatunki",
                        principalColumn: "IDGatunek",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ksiazki_Wydawnictwa_WydawnictwoIDWydawnictwo",
                        column: x => x.WydawnictwoIDWydawnictwo,
                        principalTable: "Wydawnictwa",
                        principalColumn: "IDWydawnictwo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ulice",
                columns: table => new
                {
                    IDUlica = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KodPocztowy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IDMiasto = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MiastoIDMiasto = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ulice", x => x.IDUlica);
                    table.ForeignKey(
                        name: "FK_Ulice_Miasta_MiastoIDMiasto",
                        column: x => x.MiastoIDMiasto,
                        principalTable: "Miasta",
                        principalColumn: "IDMiasto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Egzemplarze",
                columns: table => new
                {
                    IDEgzemplarz = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Dostepnosc = table.Column<bool>(type: "bit", nullable: false),
                    RokZakupu = table.Column<int>(type: "int", nullable: false),
                    IDKsiazka = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KsiazkaISBN = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Egzemplarze", x => x.IDEgzemplarz);
                    table.ForeignKey(
                        name: "FK_Egzemplarze_Ksiazki_KsiazkaISBN",
                        column: x => x.KsiazkaISBN,
                        principalTable: "Ksiazki",
                        principalColumn: "ISBN");
                });

            migrationBuilder.CreateTable(
                name: "KsiazkaAutorzy",
                columns: table => new
                {
                    IDKsiazkaAutor = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDOsoba = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OsobaIDOsoba = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDKsiazka = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KsiazkaISBN = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KsiazkaAutorzy", x => x.IDKsiazkaAutor);
                    table.ForeignKey(
                        name: "FK_KsiazkaAutorzy_Ksiazki_KsiazkaISBN",
                        column: x => x.KsiazkaISBN,
                        principalTable: "Ksiazki",
                        principalColumn: "ISBN",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KsiazkaAutorzy_Osoby_OsobaIDOsoba",
                        column: x => x.OsobaIDOsoba,
                        principalTable: "Osoby",
                        principalColumn: "IDOsoba",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Adresy",
                columns: table => new
                {
                    IDAdres = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDUlica = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NumerBudynku = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumerMieszkania = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UlicaIDUlica = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adresy", x => x.IDAdres);
                    table.ForeignKey(
                        name: "FK_Adresy_Ulice_UlicaIDUlica",
                        column: x => x.UlicaIDUlica,
                        principalTable: "Ulice",
                        principalColumn: "IDUlica");
                });

            migrationBuilder.CreateTable(
                name: "DaneOsobowe",
                columns: table => new
                {
                    IDDanaOsobowa = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Pesel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IDOsoba = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDAdres = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Telefon = table.Column<int>(type: "int", nullable: false),
                    OsobaIDOsoba = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AdresaIDAdres = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DaneOsobowe", x => x.IDDanaOsobowa);
                    table.ForeignKey(
                        name: "FK_DaneOsobowe_Adresy_AdresaIDAdres",
                        column: x => x.AdresaIDAdres,
                        principalTable: "Adresy",
                        principalColumn: "IDAdres");
                    table.ForeignKey(
                        name: "FK_DaneOsobowe_Osoby_OsobaIDOsoba",
                        column: x => x.OsobaIDOsoba,
                        principalTable: "Osoby",
                        principalColumn: "IDOsoba");
                });

            migrationBuilder.CreateTable(
                name: "Bibliotekarze",
                columns: table => new
                {
                    IDBibliotekarz = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Pensja = table.Column<int>(type: "int", nullable: false),
                    IDDanaOsobowe = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDDanaLogowania = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DanaOsobowaIDDanaOsobowa = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DanaLogowaniaIDDanaLogowania = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bibliotekarze", x => x.IDBibliotekarz);
                    table.ForeignKey(
                        name: "FK_Bibliotekarze_DaneLogowania_DanaLogowaniaIDDanaLogowania",
                        column: x => x.DanaLogowaniaIDDanaLogowania,
                        principalTable: "DaneLogowania",
                        principalColumn: "IDDanaLogowania");
                    table.ForeignKey(
                        name: "FK_Bibliotekarze_DaneOsobowe_DanaOsobowaIDDanaOsobowa",
                        column: x => x.DanaOsobowaIDDanaOsobowa,
                        principalTable: "DaneOsobowe",
                        principalColumn: "IDDanaOsobowa");
                });

            migrationBuilder.CreateTable(
                name: "Czytelnicy",
                columns: table => new
                {
                    IDCzytelnik = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDDanaOsobowe = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDDanaLogowania = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DanaOsobowaIDDanaOsobowa = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DanaLogowaniaIDDanaLogowania = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Czytelnicy", x => x.IDCzytelnik);
                    table.ForeignKey(
                        name: "FK_Czytelnicy_DaneLogowania_DanaLogowaniaIDDanaLogowania",
                        column: x => x.DanaLogowaniaIDDanaLogowania,
                        principalTable: "DaneLogowania",
                        principalColumn: "IDDanaLogowania");
                    table.ForeignKey(
                        name: "FK_Czytelnicy_DaneOsobowe_DanaOsobowaIDDanaOsobowa",
                        column: x => x.DanaOsobowaIDDanaOsobowa,
                        principalTable: "DaneOsobowe",
                        principalColumn: "IDDanaOsobowa");
                });

            migrationBuilder.CreateTable(
                name: "Wypozyczenia",
                columns: table => new
                {
                    IDWypozyczenie = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDBibliotekarza = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BibliotekarzIDBibliotekarz = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IDCzytelnika = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CzytelnikIDCzytelnik = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DataOddania = table.Column<DateTime>(type: "Date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wypozyczenia", x => x.IDWypozyczenie);
                    table.ForeignKey(
                        name: "FK_Wypozyczenia_Bibliotekarze_BibliotekarzIDBibliotekarz",
                        column: x => x.BibliotekarzIDBibliotekarz,
                        principalTable: "Bibliotekarze",
                        principalColumn: "IDBibliotekarz");
                    table.ForeignKey(
                        name: "FK_Wypozyczenia_Czytelnicy_CzytelnikIDCzytelnik",
                        column: x => x.CzytelnikIDCzytelnik,
                        principalTable: "Czytelnicy",
                        principalColumn: "IDCzytelnik");
                });

            migrationBuilder.CreateTable(
                name: "WypozyczenieEgzemplarze",
                columns: table => new
                {
                    IDWypozyczenieEgzemplarz = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataOddania = table.Column<DateTime>(type: "Date", nullable: false),
                    IDWypozyczenia = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WypozyczenieIDWypozyczenie = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IDEgzemplarz = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EgzemplarzIDEgzemplarz = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WypozyczenieEgzemplarze", x => x.IDWypozyczenieEgzemplarz);
                    table.ForeignKey(
                        name: "FK_WypozyczenieEgzemplarze_Egzemplarze_EgzemplarzIDEgzemplarz",
                        column: x => x.EgzemplarzIDEgzemplarz,
                        principalTable: "Egzemplarze",
                        principalColumn: "IDEgzemplarz");
                    table.ForeignKey(
                        name: "FK_WypozyczenieEgzemplarze_Wypozyczenia_WypozyczenieIDWypozyczenie",
                        column: x => x.WypozyczenieIDWypozyczenie,
                        principalTable: "Wypozyczenia",
                        principalColumn: "IDWypozyczenie");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adresy_UlicaIDUlica",
                table: "Adresy",
                column: "UlicaIDUlica");

            migrationBuilder.CreateIndex(
                name: "IX_Bibliotekarze_DanaLogowaniaIDDanaLogowania",
                table: "Bibliotekarze",
                column: "DanaLogowaniaIDDanaLogowania");

            migrationBuilder.CreateIndex(
                name: "IX_Bibliotekarze_DanaOsobowaIDDanaOsobowa",
                table: "Bibliotekarze",
                column: "DanaOsobowaIDDanaOsobowa");

            migrationBuilder.CreateIndex(
                name: "IX_Czytelnicy_DanaLogowaniaIDDanaLogowania",
                table: "Czytelnicy",
                column: "DanaLogowaniaIDDanaLogowania");

            migrationBuilder.CreateIndex(
                name: "IX_Czytelnicy_DanaOsobowaIDDanaOsobowa",
                table: "Czytelnicy",
                column: "DanaOsobowaIDDanaOsobowa");

            migrationBuilder.CreateIndex(
                name: "IX_DaneOsobowe_AdresaIDAdres",
                table: "DaneOsobowe",
                column: "AdresaIDAdres");

            migrationBuilder.CreateIndex(
                name: "IX_DaneOsobowe_OsobaIDOsoba",
                table: "DaneOsobowe",
                column: "OsobaIDOsoba");

            migrationBuilder.CreateIndex(
                name: "IX_Egzemplarze_KsiazkaISBN",
                table: "Egzemplarze",
                column: "KsiazkaISBN");

            migrationBuilder.CreateIndex(
                name: "IX_KsiazkaAutorzy_KsiazkaISBN",
                table: "KsiazkaAutorzy",
                column: "KsiazkaISBN");

            migrationBuilder.CreateIndex(
                name: "IX_KsiazkaAutorzy_OsobaIDOsoba",
                table: "KsiazkaAutorzy",
                column: "OsobaIDOsoba");

            migrationBuilder.CreateIndex(
                name: "IX_Ksiazki_GatunekIDGatunek",
                table: "Ksiazki",
                column: "GatunekIDGatunek");

            migrationBuilder.CreateIndex(
                name: "IX_Ksiazki_WydawnictwoIDWydawnictwo",
                table: "Ksiazki",
                column: "WydawnictwoIDWydawnictwo");

            migrationBuilder.CreateIndex(
                name: "IX_Miasta_WojewodztwoIDWojewodztwo",
                table: "Miasta",
                column: "WojewodztwoIDWojewodztwo");

            migrationBuilder.CreateIndex(
                name: "IX_Ulice_MiastoIDMiasto",
                table: "Ulice",
                column: "MiastoIDMiasto");

            migrationBuilder.CreateIndex(
                name: "IX_Wypozyczenia_BibliotekarzIDBibliotekarz",
                table: "Wypozyczenia",
                column: "BibliotekarzIDBibliotekarz");

            migrationBuilder.CreateIndex(
                name: "IX_Wypozyczenia_CzytelnikIDCzytelnik",
                table: "Wypozyczenia",
                column: "CzytelnikIDCzytelnik");

            migrationBuilder.CreateIndex(
                name: "IX_WypozyczenieEgzemplarze_EgzemplarzIDEgzemplarz",
                table: "WypozyczenieEgzemplarze",
                column: "EgzemplarzIDEgzemplarz");

            migrationBuilder.CreateIndex(
                name: "IX_WypozyczenieEgzemplarze_WypozyczenieIDWypozyczenie",
                table: "WypozyczenieEgzemplarze",
                column: "WypozyczenieIDWypozyczenie");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KsiazkaAutorzy");

            migrationBuilder.DropTable(
                name: "WypozyczenieEgzemplarze");

            migrationBuilder.DropTable(
                name: "Egzemplarze");

            migrationBuilder.DropTable(
                name: "Wypozyczenia");

            migrationBuilder.DropTable(
                name: "Ksiazki");

            migrationBuilder.DropTable(
                name: "Bibliotekarze");

            migrationBuilder.DropTable(
                name: "Czytelnicy");

            migrationBuilder.DropTable(
                name: "Gatunki");

            migrationBuilder.DropTable(
                name: "Wydawnictwa");

            migrationBuilder.DropTable(
                name: "DaneLogowania");

            migrationBuilder.DropTable(
                name: "DaneOsobowe");

            migrationBuilder.DropTable(
                name: "Adresy");

            migrationBuilder.DropTable(
                name: "Osoby");

            migrationBuilder.DropTable(
                name: "Ulice");

            migrationBuilder.DropTable(
                name: "Miasta");

            migrationBuilder.DropTable(
                name: "Wojewodztwa");
        }
    }
}
