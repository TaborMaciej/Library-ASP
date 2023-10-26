using Library_project.Models;
using Microsoft.EntityFrameworkCore;

namespace Library_project.Context
{
    public class LibraryContext : DbContext
    {
        public LibraryContext() : base() { }

        public DbSet<Gatunek> Gatunki { get; set; }
        public DbSet<Wydawnictwo> Wydawnictwa{ get; set; }
        public DbSet<Osoba> Osoby { get; set; }
        public DbSet<Ksiazka> Ksiazki { get; set; }
        public DbSet<Egzemplarz> Egzemplarze { get; set; }
        public DbSet<KsiazkaAutor> KsiazkaAutorzy { get; set; }
        public DbSet<WypozyczenieEgzemplarz> WypozyczenieEgzemplarze { get; set; }
        public DbSet<Wypozyczenie> Wypozyczenia { get; set; }

    }
}
