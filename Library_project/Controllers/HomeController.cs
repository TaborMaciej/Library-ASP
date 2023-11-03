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
    //[ApiController]
   // [Route("[controller]/[action]")]
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
        public async Task<IActionResult> Login(string login, string password)
        {
            var adm = _context.Admini.FirstOrDefault(p => p.DanaLogowania.Email == login);
            var czytelnik = _context.Czytelnicy.FirstOrDefault(p => p.DanaLogowania.Email == login);
            var bibliotekarz = _context.Bibliotekarze.FirstOrDefault(p => p.DanaLogowania.Email == login);
  
            if (adm != null)
            {
                var haslo = _context.Admini.FirstOrDefault(p => p.DanaLogowania.Haslo == password);
                if (haslo != null)
                {
                    var claims = new[]
                    {
                    new Claim(ClaimTypes.Name, "Admin"),
                    new Claim(ClaimTypes.Role, "Admin")
                    };

                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                    return RedirectToAction("Index", "FrontPage");
                }
            }

            else if (czytelnik != null )
            {

                var haslo = _context.Czytelnicy.FirstOrDefault(p => p.DanaLogowania.Haslo == password);
                if (haslo != null)
                {
                    var claims = new[]
                    {
                    new Claim(ClaimTypes.Name, "Czytelnik"),
                    new Claim(ClaimTypes.Role, "Czytelnik")
                };

                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                    return RedirectToAction("Index", "FrontPage");
                }
            }
            else if (bibliotekarz != null)
            {

                var haslo = _context.Bibliotekarze.FirstOrDefault(p => p.DanaLogowania.Haslo == password);
                if (haslo != null)
                {
                    var claims = new[]
                {
                    new Claim(ClaimTypes.Name, "Bibliotekarz"),
                    new Claim(ClaimTypes.Role, "Bibliotekarz")
                };

                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                    return RedirectToAction("Index", "FrontPage");
                }
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