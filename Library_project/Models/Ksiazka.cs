using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library_project.Models;

public class Ksiazka
{
    [Key]
    public string ISBN { get; set; } = string.Empty;
    public string Tytul { get; set; } = string.Empty;
    public int RokWydania { get; set; }
    public int LiczbaStron { get; set; }


        [ForeignKey("Wydawnictwo")]
        public Guid IDWydawnictwo {  get; set; }
        public virtual Wydawnictwo? Wydawnictwo { get; set; }

        [ForeignKey("Gatunek")]
        public Guid IDGatunek { get; set; }
        public virtual Gatunek? Gatunek { get; set; }

        public virtual List<KsiazkaAutor>? KsiazkaAutorzy { get; set; }
        public virtual List<Egzemplarz>? Egzemplarz { get; set; }
}


