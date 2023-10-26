using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library_project.Context
{
    public class Miasto
    {
        [Key]
        public Guid IDMiasto { get; set; }
        public string Nazwa { get; set; } = string.Empty;
        [ForeignKey("Wojewodztwa")]
        public Guid IDWojewodztwo { get; set; }
        [ForeignKey("Ulice")]
        public Guid IDUlica { get; set; }


        public List<Wojewodztwo> Wojewodztwa { get; set; }
        public List<Ulica> Ulice { get; set; }

    }
}
