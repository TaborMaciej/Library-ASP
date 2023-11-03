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
        public DbSet<Admin> Admini { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>()
                .Property(p => p.IDAdmin)
                .HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<Adres>()
                .Property(c => c.IDAdres)
                .HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<Bibliotekarz>()
                .Property(c => c.IDBibliotekarz)
                .HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<Czytelnik>()
                .Property(c => c.IDCzytelnik)
                .HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<DanaLogowania>()
                .Property(c => c.IDDanaLogowania)
                .HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<DanaOsobowa>()
                .Property(c => c.IDDanaOsobowa)
                .HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<Egzemplarz>()
                .Property(c => c.IDEgzemplarz)
                .HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<Gatunek>()
                .Property(c => c.IDGatunek)
                .HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<Ksiazka>()
                .Property(c => c.ISBN)
                .HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<KsiazkaAutor>()
                .Property(c => c.IDKsiazkaAutor)
                .HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<Miasto>()
                .Property(c => c.IDMiasto)
                .HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<Osoba>()
                .Property(c => c.IDOsoba)
                .HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<Ulica>()
                .Property(c => c.IDUlica)
                .HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<Wojewodztwo>()
                .Property(c => c.IDWojewodztwo)
                .HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<Wydawnictwo>()
                .Property(c => c.IDWydawnictwo)
                .HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<Wypozyczenie>()
                .Property(c => c.IDWypozyczenie)
                .HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<WypozyczenieEgzemplarz>()
                .Property(c => c.IDWypozyczenieEgzemplarz)
                .HasDefaultValueSql("NEWID()");

        }
    }
}
