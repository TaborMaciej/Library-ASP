using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library_project.Models
{
    public class Wypozyczenie
    {
        [Key]
        public Guid? IDWypozyczenie { get; set; }
        [ForeignKey("Bibliotekarze")]
        public Guid? IDBibliotekarza { get; set; }
        public virtual Bibliotekarz? Bibliotekarz { get; set; }
        [ForeignKey("Czytelnicy")]
        public Guid? IDCzytelnika { get; set; }
        public virtual Czytelnik? Czytelnik { get; set; }
        [Column(TypeName = "Date")]
        public DateTime? DataOddania { get; set; }
        public virtual List<WypozyczenieEgzemplarz>? WypozyczenieEgzemplarz { get; set; }
    }
}
