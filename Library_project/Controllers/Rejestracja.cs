using Library_project.Context;
using Library_project.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library_project.Controllers
{
    public class Rejestracja : Controller
    {

        private readonly LibraryContext _context;

        public Rejestracja(LibraryContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Wojewodztwo wojewodztwo, Miasto miasto, Ulica ulica, Adres adres, DanaLogowania danal, DanaOsobowa danao, Osoba osoba)
        {
            if (ModelState.IsValid)
            {
                var existingWojewodztwo = _context.Wojewodztwa.FirstOrDefault(w => w.Nazwa == wojewodztwo.Nazwa);
                if(existingWojewodztwo == null)
                {
                    _context.Wojewodztwa.Add(wojewodztwo);
                    _context.SaveChanges();
                }
                else
                {
                    wojewodztwo = existingWojewodztwo;
                }
              

                miasto.IDWojewodztwo = wojewodztwo.IDWojewodztwo;
                var existingMiasto = _context.Miasta.FirstOrDefault(m => m.Nazwa == miasto.Nazwa && m.IDWojewodztwo == miasto.IDWojewodztwo);
                if (existingMiasto == null)
                {
                    _context.Miasta.Add(miasto);
                    _context.SaveChanges();
                }
                else
                {
                    miasto = existingMiasto;
                }

                ulica.IDMiasto = miasto.IDMiasto;

                var existingUlica = _context.Ulice.FirstOrDefault(u => u.Nazwa == ulica.Nazwa && u.IDMiasto == ulica.IDMiasto);
                if (existingUlica == null)
                {
                    _context.Ulice.Add(ulica);
                    _context.SaveChanges();
                }
                else
                {
                    ulica = existingUlica;
                }


                adres.IDUlica = ulica.IDUlica;

                var existingAdres = _context.Adresy.FirstOrDefault(a => a.IDUlica == adres.IDUlica && a.NumerBudynku == adres.NumerBudynku && a.NumerMieszkania == adres.NumerMieszkania);
                if (existingAdres == null)
                {
                    _context.Adresy.Add(adres);
                    _context.SaveChanges();
                }
                else
                {
                    adres = existingAdres;
                }
           
                danao.IDAdres = adres.IDAdres;

                var existingOsoba = _context.Osoby.FirstOrDefault(a => a.Imie == osoba.Imie && a.Nazwisko == osoba.Nazwisko && a.DataUrodzenia == osoba.DataUrodzenia && a.CzyAutor == osoba.CzyAutor);
                if (existingOsoba == null)
                {
                    _context.Osoby.Add(osoba);
                    _context.SaveChanges();
                }
                else
                {
                    osoba = existingOsoba;
                }
              

                danao.IDOsoba = osoba.IDOsoba;
                var existingdanao = _context.DaneOsobowe.FirstOrDefault(a => a.IDDanaOsobowa == danao.IDDanaOsobowa && a.Pesel == danao.Pesel && a.Telefon == danao.Telefon && a.IDOsoba == danao.IDOsoba && a.IDAdres == danao.IDAdres);
                if (existingAdres == null)
                {
                    _context.DaneOsobowe.Add(danao);
                    _context.SaveChanges();
                }
                else
                {
                    danao = existingdanao;
                }
           

                _context.DaneLogowania.Add(danal);
               _context.SaveChanges();

            

                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public void dodaj()
        {
        }
    }
}
