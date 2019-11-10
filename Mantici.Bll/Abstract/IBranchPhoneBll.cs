﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Mantici.Entities.Models;

namespace Mantici.Bll.Abstract
{
    public interface IBranchPhoneBll
    {
        List<BranchPhone> ListAll(Expression<Func<BranchPhone, bool>> filter = null);
        BranchPhone GetOne(Expression<Func<BranchPhone, bool>> filter);
        bool Add(BranchPhone branchPhone);
        bool Update(BranchPhone branchPhone);
        bool Delete(int id);
    }
}