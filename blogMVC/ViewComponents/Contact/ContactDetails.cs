using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace blogMVC.ViewComponents.Contact
{
    public class ContactDetails:ViewComponent
    {
        ContactManager contactManager = new ContactManager(new EfContactDal());
        public IViewComponentResult Invoke()
        {
            var values = contactManager.TGetById(1);
            return View(values);


        }
    }
}
