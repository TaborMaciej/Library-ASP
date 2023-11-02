using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library_project.Models
{
    public class Czytelnik
    {
        [Key]
        public Guid IDCzytelnik { get; set; }
        [ForeignKey("DaneOsobowa")]
        public Guid IDDanaOsobowe{ get; set; }
        [ForeignKey("DaneLogowania")]
        public Guid IDDanaLogowania { get; set; }

    }
}
