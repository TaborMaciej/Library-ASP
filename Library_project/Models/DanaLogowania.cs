using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library_project.Models
{
    public class DanaLogowania
    {
        [Key]
        public Guid IDDanaLogowania { get; set; }
        public string Haslo { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public List<Bibliotekarz>? Bibliotekarz { get; set; }
        public List<Czytelnik>? Czytelnik { get; set; }
        public List<Admin>? Admin { get; set; }

    }
}
