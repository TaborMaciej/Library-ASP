using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library_project.Models
{
    public class Adres
    {
        [Key]
        public Guid IDAdres { get; set; }
        [ForeignKey("Miasta")]
        public Guid IDMiasto { get; set; }
        public string NumerBudynku { get; set; } = string.Empty;
        public string NumerMieszkania { get; set; } = string.Empty;

        public Miasto? Miasta { get; set; }
        public List<DanaOsobowa>? DaneOsobowe { get; set; }

    }
}
