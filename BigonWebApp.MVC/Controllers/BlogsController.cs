using Microsoft.AspNetCore.Mvc;

namespace BigonWebApp.MVC.Controllers
{
    public class BlogsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
