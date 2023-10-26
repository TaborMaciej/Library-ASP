using Library_project.Models;
using Microsoft.EntityFrameworkCore;

namespace Library_project.Context
{
    public class LibraryContext : DbContext
    {
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
