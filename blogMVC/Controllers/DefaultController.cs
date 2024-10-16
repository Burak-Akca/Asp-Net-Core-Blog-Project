using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace blogMVC.Controllers
{
    [AllowAnonymous]

    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public PartialViewResult HeaderPartial()
        {

            return PartialView();
              } 
    

        [HttpGet]

        public PartialViewResult SendMessage()
        {

            return PartialView();
        }
        [HttpPost]
        public ActionResult SendMessage(Message p)
        {
            MessageManager messageManager = new MessageManager(new EfMessageDal());
            p.Status = true;
            p.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            messageManager.TAdd(p);

            return Redirect("/Default/Index#header-nav");
        }
    }
}
