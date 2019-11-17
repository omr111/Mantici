using Mantici.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
namespace Mantici.Bll.Abstract
{
    public interface IrezervationBll
    {
        List<rezervation> ListAll(Expression<Func<rezervation, bool>> filter = null);
        rezervation GetOne(Expression<Func<rezervation, bool>> filter);
        bool Add(rezervation rezervation);
        bool Update(rezervation rezervation);
        bool Delete(int id);

    }
}