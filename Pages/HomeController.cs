using Microsoft.AspNetCore.Mvc;

namespace ResearchLab.Pages
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
