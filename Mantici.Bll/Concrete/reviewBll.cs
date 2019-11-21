using Mantici.Bll.Abstract;
using Mantici.Dal.Abstract;
using Mantici.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Mantici.Bll.Concrete
{
    public class reviewBll:IreviewBll
    {

        private IreviewDal _reviewDal;

        public reviewBll(IreviewDal reviewDal)
        {
            _reviewDal = reviewDal;
        }
        public List<review> ListAll(Expression<Func<review, bool>> filter = null)
        {
            return _reviewDal.AllList();
        }

        public review GetOne(Expression<Func<review, bool>> filter)
        {
            return _reviewDal.GetOne(filter);
        }

        public bool Add(review review)
        {
            bool result = _reviewDal.Add(review);
            if (result)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Update(review review)
        {
            bool result = _reviewDal.Update(review);
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
            review review = _reviewDal.GetOne(x => x.id == id);
            bool result = _reviewDal.Delete(review);    
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