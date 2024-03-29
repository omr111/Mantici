﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Mantici.Entities.Models;

namespace Mantici.Bll.Abstract
{
    public interface ICompanyInformationBll

    {
        List<CompanyInformation> ListAll(Expression<Func<CompanyInformation, bool>> filter = null);
        CompanyInformation GetOneWitId(int id);
        bool Add(CompanyInformation companyInformation);
        bool Update(CompanyInformation companyInformation);
        bool Delete(int id);
    }
}