using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library_project.Models;

public class Czytelnik
{
    [Key]
    public Guid IDCzytelnik { get; set; }
    [ForeignKey("DanaOsobowa")]
    public Guid IDDanaOsobowe{ get; set; }
    public virtual DanaOsobowa? DanaOsobowa { get; set; }
    [ForeignKey("DanaLogowania")]
    public Guid IDDanaLogowania { get; set; }
    public virtual DanaLogowania? DanaLogowania { get; set; }

}
