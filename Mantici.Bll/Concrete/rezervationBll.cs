using Mantici.Dal.Abstract;
using Mantici.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Mantici.Bll.Abstract;

namespace Mantici.Bll.Concrete
{
    public class rezervationBll:IrezervationBll
    {
        private IrezervationDal _rezervationDal;

        public rezervationBll(IrezervationDal rezervationDal)
        {
            _rezervationDal = rezervationDal;
        }
        public List<rezervation> ListAll(Expression<System.Func<rezervation, bool>> filter = null)
        {
            return _rezervationDal.AllList();
        }

        public List<rezervation> newListAll()
        {
            return _rezervationDal.AllList(x => x.showed == false);
        }
        public rezervation GetOne(int id)
        {
            return _rezervationDal.GetOne(x=>x.id==id);
        }

        public bool Add(rezervation rezervation)
        {
            bool result = _rezervationDal.Add(rezervation);
            if (result)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Update(rezervation rezervation)
        {
            bool result = _rezervationDal.Update(rezervation);
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
            rezervation rezervation = _rezervationDal.GetOne(x => x.id == id);
            bool result = _rezervationDal.Delete(rezervation);    
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