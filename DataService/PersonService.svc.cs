using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace DataService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "PersonService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select PersonService.svc or PersonService.svc.cs at the Solution Explorer and start debugging.
    public class PersonService : IPersonService
    {
        // Getting persanies data from database
        public List<Person> GetPeople()
        {
            Person Person = null;
            List<Person> lstpers = new List<Person>();
            using (var context = new ExampleAppModel())
            {
                var PersonEntity = (from pers in context.People select pers).ToList();
                if (PersonEntity != null)
                    foreach (var pers in PersonEntity)
                    {
                        Person = new Person();
                        Person.PersonId = pers.PersonId;
                        Person.CompanyId = pers.CompanyId;
                        Person.FirstName = pers.FirstName;
                        Person.LastName = pers.LastName;
                        lstpers.Add(Person);
                    }
            }
            return lstpers;
        }
    }
}
