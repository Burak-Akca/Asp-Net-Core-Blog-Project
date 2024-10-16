using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace blogMVC.Controllers
{
    public class AdminMessageController : Controller
    {
        WriterMessageManager messageManager=new WriterMessageManager(new EfWriterMessageDal());
        public IActionResult Inbox()
        {
            string p = "admin@gmail.com";
            var values = messageManager.GetListReceiverMessages(p);

            return View(values);
        }
        public IActionResult Sendbox()
        {
            string p = "admin@gmail.com";
            var values = messageManager.GetListSenderMessages(p);

            return View(values);
        }
        public IActionResult AdminMessageDetails(int id)
        {

            var value = messageManager.TGetById(id);

            return View(value);
        }

        public IActionResult AdminMessageDelete(int id)
        {
            var values = messageManager.TGetById(id);
            messageManager.TDelete(values);
            
            if (values.Receiver == "admin@gmail.com")

            {

                return RedirectToAction("Inbox");

            }

            else

            {

                return RedirectToAction("Sendbox");

            }



        }
        [HttpGet]
        public IActionResult AdminMessageSend()
        {
            ViewBag.v1 = "ekleme";
            ViewBag.v2 = "güncelleme";


            return View();
        }
        [HttpPost]
        public IActionResult AdminMessageSend(WriterMessage p)
        {
            Context c = new Context();

            var usernamesurname = c.Users.Where(x => x.Email == p.Receiver).Select(y => y.Name + " " + y.Surname).FirstOrDefault();
            p.ReceiverName=usernamesurname;
            p.Sender = "admin@gmail.com";
            p.SenderName = "admin";
            p.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            messageManager.TAdd(p);

            return RedirectToAction("Sendbox");

        }
    }
}
