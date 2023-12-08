using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library_project.Models;

public class WypozyczenieEgzemplarz
{
    [Key]
    public Guid IDWypozyczenieEgzemplarz {  get; set; }
    [Column(TypeName = "Date")]
    public DateTime DataOddania { get; set; }

    [ForeignKey("Wypozyczenie")]
    public Guid IDWypozyczenia { get; set; }
    public virtual Wypozyczenie Wypozyczenie { get; set; }
    [ForeignKey("Egzemplarz")]
    public Guid IDEgzemplarz { get; set; }
    public virtual Egzemplarz Egzemplarz { get; set; }


}
