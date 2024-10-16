using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace blogMVC.Areas.Writer.ViewComponents
{
    public class NavbarProfil:ViewComponent
    {
        private readonly UserManager<WriterUser> _userManager;

        public NavbarProfil(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.v1 = values.ImageUrl;

            return View();
        }
    }
}
