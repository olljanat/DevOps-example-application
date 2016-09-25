using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class PersonController : Controller
    {
        // GET: Person
        public ActionResult Index()
        {
            IPersonService.PersonServiceClient obj = new IPersonService.PersonServiceClient();
            return View(obj.GetPeople());
        }
    }
}