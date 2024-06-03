using Microsoft.AspNetCore.Mvc;

namespace BigonWebApp.MVC.Controllers
{
    public class AboutusController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
