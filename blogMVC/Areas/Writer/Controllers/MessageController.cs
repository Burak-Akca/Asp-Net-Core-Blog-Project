using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace blogMVC.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Route("Writer/[controller]/[action]/{id?}")]
    [Authorize]
    public class MessageController : Controller

    {

        private readonly UserManager<WriterUser> _userManager;



        WriterMessageManager _writerMessageManager = new WriterMessageManager(new EfWriterMessageDal());

        public MessageController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> ReceiverMessage(string p)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            p=values.Email;
            var messageList=_writerMessageManager.GetListReceiverMessages(p);
            return View(messageList);
        } 
        
        public async Task<IActionResult> SenderMessage(string p)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            p=values.Email;
            var messageList=_writerMessageManager.GetListSenderMessages(p);
            return View(messageList);
        }
        public IActionResult MessageDetails(int id)
        {
            var value=_writerMessageManager.TGetById(id);
                return View(value);
        }  
        public IActionResult SenderMessageDetails(int id)
        {
            var value=_writerMessageManager.TGetById(id);
                return View(value);
        }
        public  IActionResult SendMessage()
        {

            return View();


        }
        [HttpPost]
        public  async Task<IActionResult> SendMessage(WriterMessage p)
        {


            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            string mail = values.Email;
            p.Date=Convert.ToDateTime(DateTime.Now.ToShortDateString());
            p.Sender = mail;
            string name = values.Name + " " + values.Surname;
            p.SenderName = name;
            Context c = new Context();
            var usernamesurname = c.Users.Where(x => x.Email == p.Receiver).Select(y=>y.Name+" "+y.Surname).FirstOrDefault();
            p.ReceiverName=usernamesurname;
            _writerMessageManager.TAdd(p);
            return RedirectToAction("SenderMessage");

        }
    }
}
