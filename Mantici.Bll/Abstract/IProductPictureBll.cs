using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Mantici.Entities.Models;

namespace Mantici.Bll.Abstract
{
    public interface IProductPictureBll
    {
        List<ProductPicture> ListAll(Expression<Func<ProductPicture, bool>> filter = null);
        ProductPicture GetOne(Expression<Func<ProductPicture, bool>> filter);
        bool Add(ProductPicture productPictureh);
        bool Update(ProductPicture productPicture);
        bool Delete(int id); 
    }
}