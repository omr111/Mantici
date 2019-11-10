using Mantici.Bll.Abstract;

namespace Mantici.Bll.Concrete
{
    public class CompanyInformationBll:ICompanyInformationBll
    {

        public System.Collections.Generic.List<Entities.Models.CompanyInformation> ListAll(System.Linq.Expressions.Expression<System.Func<Entities.Models.CompanyInformation, bool>> filter = null)
        {
            throw new System.NotImplementedException();
        }

        public Entities.Models.CompanyInformation GetOne(System.Linq.Expressions.Expression<System.Func<Entities.Models.CompanyInformation, bool>> filter)
        {
            throw new System.NotImplementedException();
        }

        public bool Add(Entities.Models.CompanyInformation companyInformation)
        {
            throw new System.NotImplementedException();
        }

        public bool Update(Entities.Models.CompanyInformation companyInformation)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}