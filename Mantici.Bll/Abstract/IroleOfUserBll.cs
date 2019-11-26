using Mantici.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
namespace Mantici.Bll.Abstract
{
    public interface IroleOfUserBll
    {
        List<roleOfUser> ListAll(Expression<Func<roleOfUser, bool>> filter = null);
        List<roleOfUser> listAllRoleTheUser(string username);
        roleOfUser GetOneWithRoleId(int roleId,int userId);
         roleOfUser CheckRoleOfUser(int userId);
        bool Add(roleOfUser roleOfUser);
        bool Update(roleOfUser roleOfUser);
        bool Delete(int id);
    }
}