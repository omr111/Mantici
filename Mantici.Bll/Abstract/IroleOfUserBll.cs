using Mantici.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
namespace Mantici.Bll.Abstract
{
    public interface IroleOfUserBll
    {
        List<roleOfUser> ListAll(Expression<Func<roleOfUser, bool>> filter = null);
        roleOfUser GetOne(Expression<Func<roleOfUser, bool>> filter);
        bool Add(roleOfUser roleOfUser);
        bool Update(roleOfUser roleOfUser);
        bool Delete(int id);
    }
}