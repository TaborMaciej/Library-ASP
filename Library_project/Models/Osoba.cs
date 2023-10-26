using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library_project.Models
{
    public class Osoba
    {
        [Key]
        public Guid? IDOsoba { get; set; }
        public string Imie { get; set; } = string.Empty;
        public string Nazwisko { get; set; } = string.Empty;
        [Column(TypeName="Date")]
        public DateTime? DataUrodzenia { get; set; }

        public virtual List<DanaOsobowa>? DaneOsobowa { get; set; }
        public virtual List<KsiazkaAutor>? KsiazkaAutorzy { get; set; }
    }
}
