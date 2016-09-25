using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace DataService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICompanyService" in both code and config file together.
    [ServiceContract]
    public interface ICompanyService
    {

        // TODO: Add your service operations here
        [OperationContract]
        List<Company> GetCompanies();
        [OperationContract]
        bool InsertCompany(Company obj);
        [OperationContract]
        bool UpdateCompany(Company obj);
        [OperationContract]
        bool DeleteCompany(int ID);
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class Company
    {
        [DataMember]
        public int CompanyId { get; set; }
        [DataMember]
        public string CompanyName { get; set; }
    }
}
