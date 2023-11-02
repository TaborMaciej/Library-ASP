using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library_project.Models
{
    public class Admin
    {
        [Key]
        public Guid IDAdmin { get; set; }
        [ForeignKey("DanaLogowania")]
        public Guid IDDanaLogowania { get; set; }
        public virtual DanaLogowania DanaLogowania { get; set; }
    }
}
