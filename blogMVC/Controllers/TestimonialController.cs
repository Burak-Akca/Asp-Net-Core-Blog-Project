using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace blogMVC.Controllers
{
    public class TestimonialController : Controller
    {
        TestimonialManager testimonialManager = new TestimonialManager(new EfTestimonialDal());
        public IActionResult Index()
        {
          var values=  testimonialManager.TGetList();
            return View(values);
        }   public IActionResult DeleteTestimonial(int id)
        {
            var value= testimonialManager.TGetById(id);
            testimonialManager.TDelete(value);
            return RedirectToAction("Index");
        }

        public IActionResult EditTestimonial(int id)
        {

            var value = testimonialManager.TGetById(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult EditTestimonial(Testimonial testimonial)
        {

            testimonialManager.TUpdate(testimonial);
            return RedirectToAction("index");
        }

        [HttpGet]
        public IActionResult AddTestimonial()
        {

            return View();
        }

        [HttpPost]
        public IActionResult AddTestimonial(Testimonial testimonial)
        {

            testimonialManager.TAdd(testimonial);
            return RedirectToAction("index");
        }
    }
}
