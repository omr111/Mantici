using Mantici.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
namespace Mantici.Bll.Abstract
{
    public interface IroleBll
    {
        List<role> ListAll(Expression<Func<role, bool>> filter = null);
        role GetOne(Expression<Func<role, bool>> filter);
        bool Add(role role);
        bool Update(role role);
        bool Delete(int id);
    }
}