using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace blogMVC.ViewComponents.Portfolio
{
    public class PortfolioList:ViewComponent
    {
        PortfolioManager featureManager = new PortfolioManager(new EfPortfolioDal());
        public IViewComponentResult Invoke()
        {
            var values = featureManager.TGetList();
            return View(values);


        }
    }
}
