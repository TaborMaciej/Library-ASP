using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library_project.Models
{
    public class Egzemplarz
    {
        [Key]
        public Guid IDEgzemplarz {  get; set; }
        public bool Dostepnosc {  get; set; }
        public int RokZakupu {  get; set; }
        [ForeignKey("Ksiazki")]
        public Guid IDKsiazka { get; set; }
        public virtual List<WypozyczenieEgzemplarz>? WypozyczenieEgzemplarz { get; set; }

    }
}
