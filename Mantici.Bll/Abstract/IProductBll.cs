using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Mantici.Entities.Models;

namespace Mantici.Bll.Abstract
{
    public interface IProductBll
    {
        List<Product> ListAll(Expression<Func<Product, bool>> filter = null);
        Product GetOne(int id);
        bool Add(Product product);
        bool Update(Product product);
        bool Delete(int id);
    }
}