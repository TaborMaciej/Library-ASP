using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Library_project.Models;

public class Wojewodztwo
{
    [Key]
    public Guid IDWojewodztwo { get; set; }
    [DisplayName("Wojewodztwo")]
    public string Nazwa { get; set; } = string.Empty;


    public virtual List<Miasto>? Miasta { get; set; }
}
