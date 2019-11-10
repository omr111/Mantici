using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Mantici.Dal.Abstract
{
    public interface IRepositoryBase<T>where T:class
    {
        List<T> AllList(Expression<Func<T, bool>> filter=null);
        T GetOne(Expression<Func<T, bool>> filter);
        bool Add(T entity);
        bool Update(T entity);
        bool Delete(T entity);


    }
}