using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace blogMVC.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Route("Writer/[controller]/[action]")]
    [Authorize]

    public class DashboardController : Controller
    {
        private readonly UserManager<WriterUser> _userManager;

        public DashboardController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);

            Context context = new Context();
            ViewBag.v1 = values.Name + " " + values.Surname;
            ViewBag.v2 = context.WriterMessages.Where(x=>x.Receiver==values.Email).Count();
            ViewBag.v3 = context.Announcements.Count();
            ViewBag.v4 = context.Users.Count();
            ViewBag.v5 = context.Skills.Count();

            //openweather api
            string api = "d52106c90c1e7537d6d25d91562d330f";
            string connection = "https://api.openweathermap.org/data/2.5/weather?q=istanbul&mode=xml&lang=tr&units=metric&&appid="+api;
            XDocument xDocument = XDocument.Load(connection);
            ViewBag.v6 = xDocument.Descendants("temperature").ElementAt(0).Attributes("value").First().Value;
            ViewBag.v7 = xDocument.Descendants("city").ElementAt(0).Attributes("name").First().Value;
            ViewBag.v8 = xDocument.Descendants("country").ElementAt(0).Value;







            //https://api.openweathermap.org/data/2.5/weather?q=istanbul&mode=xml&lang=tr&units=metric&&appid=d52106c90c1e7537d6d25d91562d330f

            return View();
        }
    }
}
