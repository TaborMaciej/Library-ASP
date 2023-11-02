using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library_project.Models
{
    public class KsiazkaAutor
    {
        [Key]
        public Guid IDKsiazkaAutor { get; set; }

        [ForeignKey("Osoby")]
        public Guid IDOsoba { get; set; }

        [ForeignKey("Ksiazki")]
        public Guid IDKsiazka { get; set; }

    }
}
