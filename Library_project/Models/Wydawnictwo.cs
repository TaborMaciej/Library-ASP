using System.ComponentModel.DataAnnotations;

namespace Library_project.Models;

public class Wydawnictwo
{
    [Key]
    public Guid IDWydawnictwo { get; set; }
    public string Nazwa { get; set; } = string.Empty;
    public virtual List<Ksiazka>? Ksiazki { get; set; }
}
