using Library_project.Models;
using Microsoft.EntityFrameworkCore;

namespace Library_project.Context
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options) { }

        public DbSet<Gatunek> Gatunki { get; set; }
        public DbSet<Wydawnictwo> Wydawnictwa{ get; set; }
        public DbSet<Osoba> Osoby { get; set; }
        public DbSet<Ksiazka> Ksiazki { get; set; }
        public DbSet<Egzemplarz> Egzemplarze { get; set; }
        public DbSet<KsiazkaAutor> KsiazkaAutorzy { get; set; }
        public DbSet<WypozyczenieEgzemplarz> WypozyczenieEgzemplarze { get; set; }
        public DbSet<Wypozyczenie> Wypozyczenia { get; set; }

        public DbSet<DanaLogowania> DaneLogowania { get; set; }
        public DbSet<Adres> Adresy { get; set; }
        public DbSet<Bibliotekarz> Bibliotekarze { get; set; }
        public DbSet<Czytelnik> Czytelnicy { get; set; }
        public DbSet<DanaOsobowa> DaneOsobowe { get; set; }
        public DbSet<Miasto> Miasta { get; set; }
        public DbSet<Ulica> Ulice { get; set; }
        public DbSet<Wojewodztwo> Wojewodztwa { get; set; }
    }
}
