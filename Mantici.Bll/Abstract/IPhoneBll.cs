using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Mantici.Entities.Models;

namespace Mantici.Bll.Abstract
{
    public interface IPhoneBll
    {
        List<Phone> ListAllOfCompany(int compId);
        Phone GetOne(string phoneNo,int compId);
        bool Add(Phone phone);
        bool Update(Phone phone);
        bool Delete(int id);
    }
}