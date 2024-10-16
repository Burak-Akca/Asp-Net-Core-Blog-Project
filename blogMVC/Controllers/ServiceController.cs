using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace blogMVC.Controllers
{
    public class ServiceController : Controller
    {

        ServiceManager serviceManager = new ServiceManager(new EfServiceDal());
        
        public IActionResult Index()
        {
          var values=  serviceManager.TGetList();
            return View(values);
        }





        [HttpGet]
        public IActionResult AddService()
        {


            return View();
        }
        [HttpPost]
        public IActionResult AddService(Service service)
        {



            ServiceValidator validations = new ServiceValidator();
            ValidationResult validationResult = validations.Validate(service);
            if (validationResult.IsValid)
            {
                serviceManager.TAdd(service);

                return RedirectToAction("index");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);

                }
            }
            return View();
        }
        public IActionResult DeleteService(int id)
        {
            var values = serviceManager.TGetById(id);
            serviceManager.TDelete(values);
            return RedirectToAction("index");



        }
        public IActionResult EditService(int id)
        {

            var portfolio = serviceManager.TGetById(id);
            return View(portfolio);
        }
        [HttpPost]
        public IActionResult EditService(Service service)
        {

            ServiceValidator validations = new ServiceValidator();
            ValidationResult validationResult = validations.Validate(service);
            if (validationResult.IsValid)
            {
                serviceManager.TUpdate(service);

                return RedirectToAction("index");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);

                }
            }
            return View();
        }


    }
}
