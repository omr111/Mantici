using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Mantici.Dal.Abstract;
using Mantici.Entities.Models;

namespace Mantici.Bll.Concrete.EfRepository
{
    public class RepositoryBase<T>:IRepositoryBase<T>where T: class
    {
        DBMantiContext ctx=new DBMantiContext();
        public List<T> AllList(Expression<Func<T, bool>> filter = null)
        {
            if (filter!=null)
            {
               return ctx.Set<T>().Where(filter).ToList();
            }
            return ctx.Set<T>().ToList();
        }

        public T GetOne(Expression<Func<T, bool>> filter)
        {
            return ctx.Set<T>().FirstOrDefault(filter);
        }

        public bool Add(T entity)
        {
            ctx.Entry(entity).State = EntityState.Added;
            int result = ctx.SaveChanges();
            if (result>0)
            {
                return true;
            }

            return false;
        }

        public bool Update(T entity)
        {
            ctx.Entry(entity).State = EntityState.Modified;
            int result = ctx.SaveChanges();
            if (result > 0)
            {
                return true;
            }

            return false;
        }

        public bool Delete(T entity)
        {
            ctx.Entry(entity).State = EntityState.Deleted;
            int result = ctx.SaveChanges();
            if (result > 0)
            {
                return true;
            }

            return false;
        }
    }
}