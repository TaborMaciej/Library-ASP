using Library_project.Models;

namespace Library_project.Views
{
    public class ModelPomocniczyDoRejestracji
    {
        public Wojewodztwo Wojewodztwo { get; set; }
        public Miasto Miasto { get; set; }
        public Ulica Ulica { get; set; }
        public Adres Adres { get; set; }
        public DanaLogowania DanaLogowania { get; set; }
        public DanaOsobowa DanaOsobowa { get; set; }
        public Osoba Osoba { get; set; }
    }
}
