using Mantici.Bll.Abstract;
using Mantici.Dal.Abstract;
using Mantici.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Mantici.Bll.Concrete
{
    public class roleBll:IroleBll
    {

        private IroleDal _roleDal;

        public roleBll(IroleDal roleDal)
        {
            _roleDal = roleDal;
        }
        public List<role> ListAll(Expression<Func<role, bool>> filter = null)
        {
            return _roleDal.AllList();
        }

        public role GetOne(Expression<Func<role, bool>> filter)
        {
            return _roleDal.GetOne(filter);
        }

        public bool Add(role role)
        {
            bool result = _roleDal.Add(role);
            if (result)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Update(role role)
        {
            bool result = _roleDal.Update(role);
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
            role role = _roleDal.GetOne(x => x.id == id);
            bool result = _roleDal.Delete(role);
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