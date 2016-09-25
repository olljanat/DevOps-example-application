using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class CompanyController : Controller
    {
        // GET: Company
        public ActionResult Index()
        {
            ICompanyService.CompanyServiceClient obj = new ICompanyService.CompanyServiceClient();
            return View(obj.GetCompanies());
        }

        public ActionResult Create(string CompanyName)
        {
            ICompanyService.CompanyServiceClient obj = new ICompanyService.CompanyServiceClient();
            var Company = new ICompanyService.Company();
            Company.CompanyName = CompanyName;
            var result = obj.InsertCompany(Company);
            return Create("");
        }

    }
}