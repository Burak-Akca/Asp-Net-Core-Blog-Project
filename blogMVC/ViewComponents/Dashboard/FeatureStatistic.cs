using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace blogMVC.ViewComponents.Dashboard
{
    public class FeatureStatistic : ViewComponent
    {
        public IViewComponentResult Invoke()
        {

            Context c=new Context();
           ViewBag.v1= c.Skills.Count();
            ViewBag.v2=c.Messages.Where(x=>x.Status==false).Count();
            ViewBag.v3 = c.Messages.Where(x => x.Status == true).Count();
            ViewBag.v4 = c.Experiences.Count();

            return View();


        }
    }

}
