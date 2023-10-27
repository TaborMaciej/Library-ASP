using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library_project.Models
{
    public class Adres
    {
        [Key]
        public Guid IDAdres { get; set; }
        [ForeignKey("Ulice")]
        public Guid IDUlica { get; set; }
        public string NumerBudynku { get; set; } = string.Empty;
        public string NumerMieszkania { get; set; } = string.Empty;

        public Ulica? Ulica { get; set; }
        public List<DanaOsobowa>? DanaOsobowe { get; set; }

    }
}
