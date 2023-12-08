using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library_project.Models;

public class KsiazkaAutor
{
    [Key]
    public Guid IDKsiazkaAutor { get; set; }

    [ForeignKey("Osoba")]
    public Guid IDOsoba { get; set; }

    public virtual Osoba? Osoba { get; set; }

    [ForeignKey("Ksiazka")]
    public string ISBN { get; set; }

    public virtual Ksiazka? Ksiazka { get; set; }

}
