using blogMVC.Areas.Writer.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace blogMVC.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Route("Writer/[controller]/[action]")]
    [Authorize]

    public class ProfileController : Controller
    {
        private readonly UserManager<WriterUser> _userManager;

        public ProfileController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var values =await    _userManager.FindByNameAsync(User.Identity.Name);
            UserEditViewModel model = new UserEditViewModel();
            model.Name= values.Name;
            model.Surname= values.Surname;
            model.Username = values.UserName;
            model.PictureUrl = values.ImageUrl;
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserEditViewModel p)
        {
            var user =await    _userManager.FindByNameAsync(User.Identity.Name);  
            if(p.Picture != null)
            {
                var resource=Directory.GetCurrentDirectory();
                Console.WriteLine(resource);
                var extension=Path.GetExtension(p.Picture.FileName);
                Console.WriteLine(extension);

                var imagename =Guid.NewGuid()+extension;
                Console.WriteLine(imagename);

                var savelocation =resource+"/wwwroot/userimage/"+imagename;
                Console.WriteLine(savelocation);

                var stream = new FileStream(savelocation, FileMode.Create);
                await p.Picture.CopyToAsync(stream);
                user.ImageUrl=imagename;

            }
            user.Name=p.Name;
            user.Surname=p.Surname;
            user.UserName = p.Username;
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, p.Password);
            var result=await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return RedirectToAction("index", "Login");
            }

            return View();
        }

    }
}
