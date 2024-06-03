using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BigonWebApp.MVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
