using Microsoft.AspNetCore.Mvc;

namespace ResearchLab.controller
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
