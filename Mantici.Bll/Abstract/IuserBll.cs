using Mantici.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
namespace Mantici.Bll.Abstract
{
    public interface IuserBll
    {
        List<user> ListAll(Expression<Func<user, bool>> filter = null);
        user GetOne(Expression<Func<user, bool>> filter);
        bool Add(user user);
        bool Update(user user);
        bool Delete(int id);
    }
}