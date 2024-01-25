using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library_project.Models;

public class DanaOsobowa
{
    [Key]
    public Guid IDDanaOsobowa { get; set; }
    [Required(ErrorMessage = "Pole wymagane.")]
    public string Pesel { get; set; } = string.Empty;
    [ForeignKey("Osoba")]
    public Guid IDOsoba { get; set; }
    public virtual Osoba? Osoba { get; set; }
    [ForeignKey("Adres")]
    public Guid IDAdres { get; set; }
    public virtual Adres? Adres { get; set; }
    public int Telefon { get; set; } = 0;

    public virtual Bibliotekarz? Bibliotekarz { get; set; }
    public virtual Czytelnik? Czytelnik { get; set; }

}
