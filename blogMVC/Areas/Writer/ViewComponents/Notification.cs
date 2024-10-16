using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Security.Permissions;

namespace blogMVC.Areas.Writer.ViewComponents
{
    public class Notification:ViewComponent
    {
        AnnouncementManager announcementManager = new AnnouncementManager(new EfAnnouncementDal());
        public IViewComponentResult Invoke()
        {
            var values = announcementManager.TGetList();

            return View(values);
        }
    }
}
