using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library_project.Context
{
    public class Adres
    {
        [Key]
        public Guid IDAdres { get; set; }
        [ForeignKey("Miasta")]
        public Guid IDMiasto { get; set; }
        public string NumerBudynku { get; set; } = string.Empty;
        public string NumerMieszkania { get; set; } = string.Empty;

        public List<Miasto> Miasta { get; set; } 

    }
}
