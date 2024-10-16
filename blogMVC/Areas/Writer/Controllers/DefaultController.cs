using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace blogMVC.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Route("Writer/[controller]/[action]/{id?}")]

    [Authorize]

    public class DefaultController : Controller
    {
        AnnouncementManager announcementManager = new AnnouncementManager(new EfAnnouncementDal());
        public IActionResult Index()
        {
            var values=announcementManager.TGetList();
            return View(values);
        }
        public IActionResult AnnouncementDetails(int id)
        {var value=announcementManager.TGetById(id);
            return View(value);
        }
    }
}
