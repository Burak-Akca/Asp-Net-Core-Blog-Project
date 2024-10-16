using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace blogMVC.ViewComponents.Dashboard
{
    public class Last5Projects:ViewComponent
    {
        public IViewComponentResult Invoke()
        {

            Context c = new Context();
           var projeler= c.Portfolios.OrderByDescending(x=>x.Name).Take(5).ToList();

            return View(projeler);


        }
    }
}
