using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace blogMVC.Controllers
{
    public class FeatureController : Controller

    {

        FeatureManager FeatureManager = new FeatureManager(new EfFeatureDal());
        public IActionResult Index()
        {
           var values=FeatureManager.TGetById(1);


            return View(values);
        }  
        [HttpPost]
        public IActionResult Index(Feature feature)
        {
            FeatureManager.TUpdate(feature);
            return RedirectToAction("index", "default");


            return View();
        }
    }
}
