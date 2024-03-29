﻿using Mantici.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
namespace Mantici.Bll.Abstract
{
    public interface IrezervationBll
    {
        List<rezervation> ListAll(Expression<Func<rezervation, bool>> filter = null);
        List<rezervation> newListAll();
        rezervation GetOne(int id);
        bool Add(rezervation rezervation);
        bool Update(rezervation rezervation);
        bool Delete(int id);

    }
}