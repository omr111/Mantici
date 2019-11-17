using Mantici.Bll.Abstract;
using Mantici.Dal.Abstract;
using Mantici.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Mantici.Bll.Concrete
{
    public class userBll:IuserBll
    {

        private IuserDal _userDal;

        public userBll(IuserDal userDal)
        {
            _userDal = userDal;
        }
        public List<user> ListAll(Expression<Func<user, bool>> filter = null)
        {
            return _userDal.AllList();
        }

        public user GetOne(Expression<Func<user, bool>> filter)
        {
            return _userDal.GetOne(filter);
        }

        public bool Add(user user)
        {
            bool result = _userDal.Add(user);
            if (result)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Update(user user)
        {
            bool result = _userDal.Update(user);
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
            user user = _userDal.GetOne(x => x.id == id);
            bool result = _userDal.Delete(user);
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