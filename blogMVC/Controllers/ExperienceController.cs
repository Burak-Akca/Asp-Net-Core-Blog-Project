using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace blogMVC.Controllers
{
    [Authorize(Roles ="Admin")]
    public class ExperienceController : Controller
    {

        ExperienceManager experienceManager = new ExperienceManager(new EfExperienceDal());

        public IActionResult Index()
        {
            var values = experienceManager.TGetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddExperience()
        {
            return View();
        }  
        [HttpPost]
        public IActionResult AddExperience(Experience experience)
        {
            experienceManager.TAdd(experience);
            return RedirectToAction("index");
        }




        public IActionResult DeleteExperience(int id)
        {
            var values = experienceManager.TGetById(id);
            experienceManager.TDelete(values);
            return RedirectToAction("index");



        }
        public IActionResult EditExperience(int id)
        {

            var skill = experienceManager.TGetById(id);
            return View(skill);
        }
        [HttpPost]
        public IActionResult EditExperience(Experience experience)
        {

            experienceManager.TUpdate(experience);
            return RedirectToAction("index");
        }

    }
}
