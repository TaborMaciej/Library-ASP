using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library_project.Models
{
    public class WypozyczenieEgzemplarz
    {
        [Key]
        public Guid IDWypozyczenieEgzemplarz {  get; set; }
        [Column(TypeName = "Date")]
        public DateTime DataOddania { get; set; }

        [ForeignKey("Wypozyczenia")]
        public Guid IDWypozyczenia { get; set; }
        [ForeignKey("Egzemplarze")]
        public Guid IDEgzemplarz { get; set; }


    }
}
