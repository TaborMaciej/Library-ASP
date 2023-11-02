using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library_project.Models
{
    public class Ulica
    {
        [Key]
        public Guid IDUlica { get; set; }
        public string Nazwa { get; set; } = string.Empty;
        public string KodPocztowy { get; set; } = string.Empty;
        [ForeignKey("Miasto")]
        public Guid IDMiasto { get; set; }
        public virtual Miasto Miasto { get; set; }
    }
}
