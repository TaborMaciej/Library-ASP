using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library_project.Context
{
    public class DanaOsobowa
    {
        [Key]
        public Guid IDDanaOsobowa { get; set; }
        public string Pesel { get; set; } = string.Empty;
        [ForeignKey("Osoby")]
        public Guid IDOsoba { get; set; }
        [ForeignKey("Adresy")]
        public Guid IDAdres { get; set; }
        public int Telefon { get; set; } = 0;

        public List<Osoba> Osoby { get; set; }
        public List<Adres> Adresy { get; set; }

    }
}
