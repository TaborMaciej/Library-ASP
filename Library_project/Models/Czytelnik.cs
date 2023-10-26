using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library_project.Context
{
    public class Czytelnik
    {
        [Key]
        public Guid IDCzytelnik { get; set; }
        [ForeignKey("Osoby")]
        public Guid IDOsoba { get; set; }
        [ForeignKey("DaneLogowania")]
        public Guid IDDanaLogowania { get; set; }

        public List<Osoba> Osoby { get; set; }
        public List<DanaLogowania> DaneLogowania { get; set; }
    }
}
