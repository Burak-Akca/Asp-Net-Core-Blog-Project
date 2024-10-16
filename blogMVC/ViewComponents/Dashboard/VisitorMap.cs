using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace blogMVC.ViewComponents.Dashboard
{
    public class VisitorMap:ViewComponent
    {
        public IViewComponentResult Invoke()
        {


            return View();


        }
    }
}
