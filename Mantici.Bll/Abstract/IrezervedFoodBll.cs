using Mantici.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
namespace Mantici.Bll.Abstract
{
    public interface IrezervedFoodBll
    {
        List<rezervedFood> ListAll(Expression<Func<rezervedFood, bool>> filter = null);
        rezervedFood GetOne(Expression<Func<rezervedFood, bool>> filter);
        bool Add(rezervedFood rezervedFood);
        bool Update(rezervedFood rezervedFood);
        bool Delete(int id);

    }
}