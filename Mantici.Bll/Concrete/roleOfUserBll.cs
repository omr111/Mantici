using Mantici.Dal.Abstract;
using Mantici.Entities.Models;
using System;
using System.Collections.Generic;
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

        public roleOfUser GetOne(Expression<Func<roleOfUser, bool>> filter)
        {
            return _rolOfUserDal.GetOne(filter);
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