using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library_project.Context
{
    public class Bibliotekarz
    {
        [Key]
        public Guid IDBibliotekarz { get; set; }
        public int Pensja { get; set; } = 0;
        [ForeignKey("Osoby")]
        public Guid IDOsoba { get; set; }
        [ForeignKey("DaneLogowania")]
        public Guid IDDanaLogowania { get; set; }

        public List<Osoba> Osoby { get; set; }
        public List<DanaLogowania> DaneLogowania { get; set; }

    }
}
