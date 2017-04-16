using MvcMovie.Models;
using MvcMovieApplication.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MvcMovie.Controllers
{
    public class HomeController : Controller
    {

        private CustomerApplicationService _customerApplicationService { get; set; }

        public HomeController()
        {
            _customerApplicationService = new CustomerApplicationService();
        }

        public ActionResult Index()
        {
            ViewBag.Title = "Movies.Net - Center of Movies";
            long custId = _customerApplicationService.GetCustomerFromGuid(new Guid());
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            // create an instance of a person for contact view
            ContactPerson person = new ContactPerson();
            person.Organization = "St. Cloud State University";
            person.AgreeToTerms = false;
            
            return View(person);
        }

        [HttpPost]
        public ActionResult Contact(ContactPerson person)
        {
            // check if model state is valid (e.g. required fields are entered in the contact form)
            if (!ModelState.IsValid)
            {
                
                return View(person);
            }
            return RedirectToAction("Index");
        }
    }
}