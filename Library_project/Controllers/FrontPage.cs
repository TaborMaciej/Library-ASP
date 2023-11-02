using Microsoft.AspNetCore.Mvc;

namespace Library_project.Controllers
{
    public class FrontPage : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
