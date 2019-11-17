using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Mantici.Entities.Models;

namespace Mantici.Bll.Abstract
{
    public interface IPictureBll
    {
        List<Picture> ListAll(Expression<Func<Picture, bool>> filter = null);
        Picture GetOne(Expression<Func<Picture, bool>> filter);
        bool Add(Picture picture);
        bool Update(Picture picture);
        bool Delete(int id); 
    }
}