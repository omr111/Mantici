using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Mantici.Entities.Models;

namespace Mantici.Bll.Abstract
{
    public interface ICategoryBll
    {
        List<Category> ListAll(Expression<Func<Category, bool>> filter = null);
        Category GetOne(int id);
        Category GetOneWithCategoryName(string categoryName);
        bool Add(Category category);
        bool Update(Category category);
        bool Delete(int id);
    }
}