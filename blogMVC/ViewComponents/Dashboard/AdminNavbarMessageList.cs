using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace blogMVC.ViewComponents.Dashboard
{
    public class AdminNavbarMessageList:ViewComponent
    {
        WriterMessageManager messageManager = new WriterMessageManager(new EfWriterMessageDal());
        public IViewComponentResult Invoke()
        {
            string p = "admin@gmail.com";
            var values=messageManager.GetListReceiverMessages(p).OrderByDescending(x => x.WriterMessageId).Take(3).ToList();

         
            return View(values);


        }
    }
}
