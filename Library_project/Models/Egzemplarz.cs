﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library_project.Models
{
    public class Egzemplarz
    {
        [Key]
        public Guid IDEgzemplarz {  get; set; }
        [Required(ErrorMessage = "Pole wymagane.")]
        public bool Dostepnosc {  get; set; }
        public int RokZakupu {  get; set; }
        [ForeignKey("Ksiazka")]
        public string? ISBN{ get; set; }
        public virtual Ksiazka? Ksiazka { get; set; }
        public virtual List<WypozyczenieEgzemplarz>? WypozyczenieEgzemplarz { get; set; }
    }
}
