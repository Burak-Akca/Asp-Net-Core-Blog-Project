using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace blogMVC.Controllers
{
    public class SocialMediaController : Controller
    {
        SocialMediaManager manager = new SocialMediaManager(new EfSocialMediaDal());
        public IActionResult Index()
        {
            var values=manager.TGetList();
            return View(values);
        }
        public IActionResult AddSocialMedia()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddSocialMedia(SocialMedia socialMedia)
        {
            socialMedia.Status = true;
             manager.TAdd(socialMedia);
            return RedirectToAction("index");
        } 
        public IActionResult DeleteSocialMedia(int id)
        {
            var value=manager.TGetById(id);
            manager.TDelete(value);
            return RedirectToAction("index");
        } 
        
        public IActionResult EditSocialMedia(int id)
        {
            var value=manager.TGetById(id);
            return View(value);
        }


        [HttpPost]

        public IActionResult EditSocialMedia(SocialMedia socialMedia)
        {
            
            manager.TUpdate(socialMedia);
            return RedirectToAction("index");
        }

    }
}
