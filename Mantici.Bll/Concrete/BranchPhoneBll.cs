using Mantici.Bll.Abstract;
using Mantici.Dal.Abstract;
using Mantici.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Mantici.Bll.Concrete
{
    public class BranchPhoneBll:IBranchPhoneBll
    {
        private IBranchPhoneDal _branchPhoneDal;

        public BranchPhoneBll(IBranchPhoneDal branchPhoneDal)
        {
            _branchPhoneDal = branchPhoneDal;
        }
        public List<BranchPhone> ListAll(Expression<Func<BranchPhone, bool>> filter = null)
        {
            return _branchPhoneDal.AllList();
        }

        public BranchPhone GetOne(Expression<Func<BranchPhone, bool>> filter)
        {
            return _branchPhoneDal.GetOne(filter);
        }

        public bool Add(BranchPhone branchPhone)
        {
            bool result = _branchPhoneDal.Add(branchPhone);
            if (result)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Update(BranchPhone branchPhone)
        {
            bool result = _branchPhoneDal.Update(branchPhone);
            if (result)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            BranchPhone branch = _branchPhoneDal.GetOne(x => x.id == id);
            bool result = _branchPhoneDal.Delete(branch);    
            if (result)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}