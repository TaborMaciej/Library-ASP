using Library_project.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Security.Claims;
using Library_project.Context;

namespace Library_project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly LibraryContext _context;

        public HomeController(ILogger<HomeController> logger, LibraryContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public async Task<IActionResult> Login(String login, String password)
        {
            var adm = _context.Admini.FirstOrDefault(p => p.DanaLogowania.Email == login);
            var czytelnik = _context.Czytelnicy.FirstOrDefault(p => p.DanaLogowania.Email == login);
            var bibliotekarz = _context.Bibliotekarze.FirstOrDefault(p => p.DanaLogowania.Email == login);

            if (adm != null)
            {
                if (adm.DanaLogowania.Haslo == password)
                {
                    var claims = new[]
                    {
                    new Claim(ClaimTypes.Name, adm.DanaLogowania.Email),
                    new Claim(ClaimTypes.Role, "Admin")
                };

                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                    return RedirectToAction("Index", "FrontPage");
                }
            }

            else if (czytelnik != null && czytelnik.DanaLogowania.Haslo == password)
            {
                var claims = new[]
                {
                    new Claim(ClaimTypes.Name, czytelnik.DanaLogowania.Email),
                    new Claim(ClaimTypes.Role, "Czytelnik")
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                return RedirectToAction("Index", "FrontPage");
            }
            else if (bibliotekarz != null && bibliotekarz.DanaLogowania.Haslo == password)
            {
                var claims = new[]
                {
                    new Claim(ClaimTypes.Name, bibliotekarz.DanaLogowania.Email),
                    new Claim(ClaimTypes.Role, "Czytelnik")
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                return RedirectToAction("Index", "FrontPage");
            }

            return View("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}