using Mantici.Dal.Abstract;
using Mantici.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Mantici.Bll.Abstract;

namespace Mantici.Bll.Concrete
{
    public class roleOfUserBll:IroleOfUserBll
    {

        private IroleOfUserDal _rolOfUserDal;

        public roleOfUserBll(IroleOfUserDal rolOfUserDal)
        {
            _rolOfUserDal = rolOfUserDal;
        }
        public List<roleOfUser> ListAll(Expression<Func<roleOfUser, bool>> filter = null)
        {
            return _rolOfUserDal.AllList();
        }

        public List<roleOfUser> listAllRoleTheUser(string username)
        {
            List<roleOfUser> roleOfUsers = _rolOfUserDal.AllList(x => x.user.name == username);
           return roleOfUsers;
        }
        public roleOfUser GetOneWithRoleId(int roleId, int userId)
        {
            return _rolOfUserDal.GetOne(x=>x.user.id==userId &&x.roleID==roleId);
        }
        public roleOfUser CheckRoleOfUser( int userId)
        {
            return _rolOfUserDal.GetOne(x => x.userID == userId);
        }
        public bool Add(roleOfUser roleOfUser)
        {
            bool result = _rolOfUserDal.Add(roleOfUser);
            if (result)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Update(roleOfUser roleOfUser)
        {
            bool result = _rolOfUserDal.Update(roleOfUser);
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
            roleOfUser roleOfUser = _rolOfUserDal.GetOne(x => x.id == id);
            bool result = _rolOfUserDal.Delete(roleOfUser);
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