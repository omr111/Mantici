using Mantici.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
namespace Mantici.Bll.Abstract
{
    public interface IreviewBll
    {
        List<review> ListAll(Expression<Func<review, bool>> filter = null);
        review GetOne(Expression<Func<review, bool>> filter);
        bool Add(review review);
        bool Update(review review);
        bool Delete(int id);
    }
}