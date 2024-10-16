using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace blogMVC.Controllers
{
    public class SkillController : Controller
    {
        SkillManager skillManager=new SkillManager(new EfSkillDal());
        public IActionResult Index()
        {

            ViewBag.v1 = "ekleme";
            ViewBag.v2 = "güncelleme";
            var values=   skillManager.TGetList();


            return View(values  );
        }
        [HttpGet]
        public IActionResult AddSkill()
        {
            ViewBag.v1 = "ekleme";
            ViewBag.v2 = "güncelleme";


            return View();
        }
        [HttpPost]
        public IActionResult AddSkill(Skill skill)
        {
            skillManager.TAdd(skill);
           
            return RedirectToAction("index");

        }
        public IActionResult DeleteSkill(int id)
        {
            var values=skillManager.TGetById(id);
            skillManager.TDelete(values);
            return RedirectToAction("index");



        }
        public IActionResult EditSkill(int id)
        {

            var skill = skillManager.TGetById(id);
            return View(skill);
        }
        [HttpPost]
        public IActionResult EditSkill( Skill skill)
        {

             skillManager.TUpdate(skill);
            return RedirectToAction("index");
        }

    }
}
