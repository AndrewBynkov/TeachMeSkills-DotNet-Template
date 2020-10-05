using Microsoft.AspNetCore.Mvc;

namespace TeachMeSkills.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
