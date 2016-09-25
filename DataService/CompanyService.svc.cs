using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace DataService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CompanyService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select CompanyService.svc or CompanyService.svc.cs at the Solution Explorer and start debugging.
    public class CompanyService : ICompanyService
    {

        // Getting Companies data from database
        public List<Company> GetCompanies()
        {
            Company Company = null;
            List<Company> lstcomp = new List<Company>();
            using (var context = new ExampleAppModel())
            {
                var CompanyEntity = (from comp in context.Companies select comp).ToList();
                if (CompanyEntity != null)
                    foreach (var comp in CompanyEntity)
                    {
                        Company = new Company();
                        Company.CompanyId = comp.CompanyId;
                        Company.CompanyName = comp.CompanyName;
                        lstcomp.Add(Company);
                    }
            }
            return lstcomp;
        }

        // Implement the method for inserting data into Company table
        public bool InsertCompany(Company obj)
        {
            CompanyEntity objcomp = new CompanyEntity()
            {
                CompanyId = obj.CompanyId,
                CompanyName = obj.CompanyName,
            };
            ExampleAppModel db = new ExampleAppModel();
            db.Companies.Add(objcomp);
             // db.Company.AddObject(objcomp);
            // db.CompanyEntity.AddObject(objcomp);
            // db.AddToCompanyEntity(objcomp);
            db.SaveChanges();
            return true;
        }




        // Implement the method for update data into Company table
        public bool UpdateCompany(Company obj)
        {
            var compId = obj.CompanyId;
            using (ExampleAppModel context = new ExampleAppModel())
            {
                var CompanyEntity = (from c in context.Companies where c.CompanyId == compId select c).Single();
                if (CompanyEntity != null)
                {
                    CompanyEntity.CompanyId = obj.CompanyId;
                    CompanyEntity.CompanyName = obj.CompanyName;
                    /*
                    context.Company
                        .DeleteObject(CompanyEntity);
                    context.SaveChanges();
                    context.AddToCompanyEntity(CompanyEntity);
                    */
                    context.SaveChanges();
                }
            }

            return true;
        }

        // Implementing Method for Deleting the Company
        public bool DeleteCompany(int ID)
        {
            using (ExampleAppModel context = new ExampleAppModel())
            {
                var CompanyEntity = (from c in context.Companies where c.CompanyId == ID select c).Single();
                if (CompanyEntity != null)
                {
                    context.Companies.Remove(CompanyEntity);
                    context.SaveChanges();
                }
            }
            return true;
        }

    }
}
