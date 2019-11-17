using Mantici.Bll.Abstract;
using Mantici.Bll.Concrete.EfRepository;
using Mantici.Dal.Abstract;
using Mantici.Entities.Models;

namespace Mantici.Bll.Concrete
{
    public class BranchBll:IBranchBll
    {
        private IBranchDal _BranchDal;

        public BranchBll(IBranchDal branchDal)
        {
            _BranchDal = branchDal;
        }
        public System.Collections.Generic.List<Entities.Models.Branch> ListAll(System.Linq.Expressions.Expression<System.Func<Entities.Models.Branch, bool>> filter = null)
        {
            return _BranchDal.AllList();
        }

        public Entities.Models.Branch GetOne(System.Linq.Expressions.Expression<System.Func<Entities.Models.Branch, bool>> filter)
        {
            return _BranchDal.GetOne(filter);
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