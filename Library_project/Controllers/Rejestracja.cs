﻿using Library_project.Context;
using Library_project.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library_project.Controllers;

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
    public IActionResult Create(Wojewodztwo wojewodztwo, Miasto miasto, Ulica ulica, Adres adres, Osoba osoba, DanaLogowania danalogowania, DanaOsobowa danaosobowa)
    {
        if (ModelState.IsValid)
        {
            var existingWojewodztwo = _context.Wojewodztwa.FirstOrDefault(w => w.Nazwa == wojewodztwo.Nazwa);
            if (existingWojewodztwo == null)
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
                Console.WriteLine("============== Wojewodztwo");
                Console.WriteLine(wojewodztwo.IDWojewodztwo + " " + wojewodztwo.Nazwa);
                Console.WriteLine("============== Miasto");
                Console.WriteLine(miasto.IDMiasto + " " + miasto.Nazwa + " " + miasto.IDWojewodztwo);
                Console.WriteLine("============== Ulica");
                Console.WriteLine(ulica.IDUlica + " " + ulica.Nazwa + " " + ulica.KodPocztowy + " " + ulica.IDMiasto);
                Console.WriteLine("============== Adres");
                Console.WriteLine(adres.IDAdres + " " + adres.NumerBudynku + " " + adres.NumerMieszkania + " " + adres.IDUlica);
                Console.WriteLine("============== Osobowa");
                Console.WriteLine(osoba.IDOsoba + " " + osoba.Imie + " " + osoba.Nazwisko + " " + osoba.DataUrodzenia);
                Console.WriteLine("============== DaneOsobowa");
                Console.WriteLine(danaosobowa.IDDanaOsobowa + " " + danaosobowa.Pesel + " " + danaosobowa.Telefon + " " + danaosobowa.IDOsoba + " " + danaosobowa.IDAdres);
                Console.WriteLine("============== DanaLogowania");
                Console.WriteLine(danalogowania.IDDanaLogowania + " " + danalogowania.Haslo + " " + danalogowania.Email);
                _context.SaveChanges();
            }
            else
            {
                ulica = existingUlica;
            }


            adres.IDUlica = ulica.IDUlica;
            adres.NumerMieszkania = danaosobowa.Pesel;
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

            danaosobowa.IDAdres = adres.IDAdres;

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
            danaosobowa.IDOsoba = osoba.IDOsoba;

            _context.DaneLogowania.Add(danalogowania);
            _context.SaveChanges();


            //Wojewodztwo wojewodztwo, Miasto miasto, Ulica ulica, Adres adres, Osoba osoba, DanaLogowania danalogowania, DanaOsobowa danaosobowa

            var existingdanao = _context.DaneOsobowe.FirstOrDefault(a => a.IDDanaOsobowa == danaosobowa.IDDanaOsobowa && a.Pesel == danaosobowa.Pesel && a.Telefon == danaosobowa.Telefon && a.IDOsoba == danaosobowa.IDOsoba && a.IDAdres == danaosobowa.IDAdres);
            if (existingdanao == null)
            {
                _context.DaneOsobowe.Add(danaosobowa);
                Console.WriteLine("============== Wojewodztwo");
                Console.WriteLine(wojewodztwo.IDWojewodztwo + " " + wojewodztwo.Nazwa);
                Console.WriteLine("============== Miasto");
                Console.WriteLine(miasto.IDMiasto + " " + miasto.Nazwa + " " + miasto.IDWojewodztwo);
                Console.WriteLine("============== Ulica");
                Console.WriteLine(ulica.IDUlica + " " + ulica.Nazwa + " " + ulica.KodPocztowy + " " + ulica.IDMiasto);
                Console.WriteLine("============== Adres");
                Console.WriteLine(adres.IDAdres + " " + adres.NumerBudynku + " " + adres.NumerMieszkania + " " + adres.IDUlica);
                Console.WriteLine("============== Osobowa");
                Console.WriteLine(osoba.IDOsoba + " " + osoba.Imie + " " + osoba.Nazwisko + " " + osoba.DataUrodzenia);
                Console.WriteLine("============== DaneOsobowa");
                Console.WriteLine(danaosobowa.IDDanaOsobowa + " " + danaosobowa.Pesel + " " + danaosobowa.Telefon + " " + danaosobowa.IDOsoba + " " + danaosobowa.IDAdres);
                Console.WriteLine("============== DanaLogowania");
                Console.WriteLine(danalogowania.IDDanaLogowania + " " + danalogowania.Haslo + " " + danalogowania.Email);

                _context.SaveChanges();


            }
            else
            {
                danaosobowa = existingdanao;
            }


          



            return RedirectToAction("Index", "Home");
        }
        return View();
    }
}
