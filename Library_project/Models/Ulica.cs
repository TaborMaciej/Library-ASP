using System.ComponentModel.DataAnnotations;

namespace Library_project.Context
{
    public class Ulica
    {
        [Key]
        public Guid IDUlica { get; set; }
        public string Nazwa { get; set; } = string.Empty;
        public int KodPocztowy { get; set; } = 0;
    }
}
