using Microsoft.AspNetCore.Mvc;

namespace blogMVC.Controllers
{
    public class ErrorPageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        } 
        public IActionResult Error404()
        {
            return View();
        } 

    }
}
