using Mantici.Bll.Abstract;
using Mantici.Dal.Abstract;
using Mantici.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Mantici.Bll.Concrete
{
    public class CompanyInformationBll:ICompanyInformationBll
    {

        private ICompanyInformationDal _companyInformationDal;

        public CompanyInformationBll(ICompanyInformationDal companyInformationDal)
        {
            _companyInformationDal = companyInformationDal;
        }
        public List<CompanyInformation> ListAll(Expression<Func<CompanyInformation, bool>> filter = null)
        {
            return _companyInformationDal.AllList();
        }

        public CompanyInformation GetOneWitId(int id)
        {
            return _companyInformationDal.GetOne(x=>x.id==id);
        }

        public bool Add(CompanyInformation companyInformation)
        {
            bool result = _companyInformationDal.Add(companyInformation);
            if (result)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Update(CompanyInformation companyInformation)
        {
            bool result = _companyInformationDal.Update(companyInformation);
            if (result)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            CompanyInformation companyInformation = _companyInformationDal.GetOne(x => x.id == id);
            bool result = _companyInformationDal.Delete(companyInformation);    
            if (result)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}