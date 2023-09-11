using Microsoft.AspNetCore.Mvc;

namespace Imi.Project.Vue.Controllers
{
    public class ContinentsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateContinent()
        {
            return View();
        }
    }
}