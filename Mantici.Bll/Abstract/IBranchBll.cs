using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Mantici.Entities.Models;

namespace Mantici.Bll.Abstract
{
    public interface IBranchBll
    {
        List<Branch> ListAll(Expression<Func<Branch, bool>> filter = null);
        
        Branch GetOne(int id);
        bool Add(Branch branch);
        bool Update(Branch branch);
        bool Delete(int id);

    }
}