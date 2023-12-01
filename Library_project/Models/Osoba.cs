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
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

        public DateTime? DataUrodzenia { get; set; }
        public bool CzyAutor { get; set; } = false;

        public virtual List<DanaOsobowa>? DaneOsobowa { get; set; }
        public virtual List<KsiazkaAutor>? KsiazkaAutorzy { get; set; }
    }
}
