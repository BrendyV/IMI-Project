using Microsoft.AspNetCore.Mvc;

namespace Imi.Project.Vue.Controllers
{
    public class KindsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateKind()
        {
            return View();
        }
    }
}
