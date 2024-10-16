using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace blogMVC.ViewComponents.Skill
{
    public class SkillListViewComponent:ViewComponent
    {
        SkillManager serviceManager = new SkillManager(new EfSkillDal());
        public IViewComponentResult Invoke()
        {
            var values = serviceManager.TGetList();
            return View(values);


        }
    
    }
}
