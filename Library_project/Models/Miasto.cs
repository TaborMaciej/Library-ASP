using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library_project.Models
{
    public class Miasto
    {
        [Key]
        public Guid IDMiasto { get; set; }
        public string Nazwa { get; set; } = string.Empty;
        [ForeignKey("Wojewodztwo")]
        public Guid IDWojewodztwo { get; set; }
        public virtual Wojewodztwo Wojewodztwo { get; set; }
        public virtual List<Ulica>? Ulica { get; set; }

    }
}
