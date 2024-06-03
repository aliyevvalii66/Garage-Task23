using Microsoft.AspNetCore.Mvc;

namespace BigonWebApp.MVC.Controllers
{
    public class ContactusController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
