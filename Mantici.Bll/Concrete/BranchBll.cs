using Mantici.Bll.Abstract;
using Mantici.Bll.Concrete.EfRepository;
using Mantici.Dal.Abstract;
using Mantici.Entities.Models;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Mantici.Bll.Concrete
{
    public class BranchBll:IBranchBll
    {
        private IBranchDal _BranchDal;

        public BranchBll(IBranchDal branchDal)
        {
            _BranchDal = branchDal;
        }
        public List<Branch> ListAll(Expression<System.Func<Branch, bool>> filter = null)
        {
            return _BranchDal.AllList();
        }

       
        public Branch GetOne(int id)
        {
            return _BranchDal.GetOne(x=>x.id==id);
        }

        public bool Add(Entities.Models.Branch branch)
        {
            bool result = _BranchDal.Add(branch);
            if (result)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Update(Entities.Models.Branch branch)
        {
            bool result = _BranchDal.Update(branch);
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
            Branch branch = _BranchDal.GetOne(x => x.id == id);
            bool result = _BranchDal.Delete(branch);    
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