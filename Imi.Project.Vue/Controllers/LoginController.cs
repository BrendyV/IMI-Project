using Microsoft.AspNetCore.Mvc;

namespace Imi.Project.Vue.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}