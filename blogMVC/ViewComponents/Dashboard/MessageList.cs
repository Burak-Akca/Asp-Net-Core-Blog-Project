using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace blogMVC.ViewComponents.Dashboard
{
    public class MessageList:ViewComponent
    {
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        public IViewComponentResult Invoke()
        {

            var values = messageManager.TGetList().Take(5).ToList();
            return View(values);


        }
    }
}
