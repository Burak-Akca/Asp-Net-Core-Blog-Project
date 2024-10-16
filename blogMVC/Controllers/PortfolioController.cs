using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace blogMVC.Controllers
{
    public class PortfolioController : Controller
    {
        PortfolioManager portfolioManager=new PortfolioManager(new EfPortfolioDal());
        public IActionResult Index()
        {var values=portfolioManager.TGetList();
            return View(values);
        }


        [HttpGet]
        public IActionResult AddPortfolio()
        {
        

            return View();
        }
        [HttpPost]
        public IActionResult AddPortfolio(Portfolio portfolio)
        {



            PortfolioValidator validations= new PortfolioValidator();
            ValidationResult validationResult= validations.Validate(portfolio);
            if (validationResult.IsValid)
            { portfolioManager.TAdd(portfolio);

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
        public IActionResult DeletePortfolio(int id)
        {
            var values = portfolioManager.TGetById(id);
            portfolioManager.TDelete(values);
            return RedirectToAction("index");



        }
        public IActionResult EditPortfolio(int id)
        {

            var portfolio = portfolioManager.TGetById(id);
            return View(portfolio);
        }
        [HttpPost]
        public IActionResult EditPortfolio(Portfolio portfolio)
        {

            PortfolioValidator validations = new PortfolioValidator();
            ValidationResult validationResult = validations.Validate(portfolio);
            if (validationResult.IsValid)
            {
                portfolioManager.TUpdate(portfolio);

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
