using Microsoft.AspNetCore.Mvc;

namespace blogMVC.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
