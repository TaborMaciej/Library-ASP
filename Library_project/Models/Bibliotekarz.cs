using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library_project.Models
{
    public class Bibliotekarz
    {
        [Key]
        public Guid IDBibliotekarz { get; set; }
        public int Pensja { get; set; } = 0;
        [ForeignKey("DaneOsobowe")]
        public Guid IDDanaOsobowe { get; set; }
        [ForeignKey("DaneLogowania")]
        public Guid IDDanaLogowania { get; set; }
        public virtual DanaLogowania? DanaLogowania { get; set; }

    }
}
