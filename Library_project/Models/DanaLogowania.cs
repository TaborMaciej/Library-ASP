using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library_project.Context
{
    public class DanaLogowania
    {
        [Key]
        public Guid IDDanaLogowania { get; set; }
        public string Haslo { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

    }
}
