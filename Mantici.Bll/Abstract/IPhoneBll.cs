using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Mantici.Entities.Models;

namespace Mantici.Bll.Abstract
{
    public interface IPhoneBll
    {
        List<Phone> ListAll(Expression<Func<Phone, bool>> filter = null);
        Phone GetOne(Expression<Func<Phone, bool>> filter);
        bool Add(Phone phone);
        bool Update(Phone phone);
        bool Delete(int id);
    }
}