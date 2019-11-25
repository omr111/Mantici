using Mantici.Dal.Abstract;
using Mantici.Entities.Models;
using System.Collections.Generic;
using Mantici.Bll.Abstract;

namespace Mantici.Bll.Concrete
{
    public class BranchesApplicationBll:IBranchesApplicationBll
    {
        private IBranchesApplicationDal _branchesApplicationDal;

        public BranchesApplicationBll(IBranchesApplicationDal branchesApplicationDal)
        {
            _branchesApplicationDal = branchesApplicationDal;
        }
        public List<BranchesApplication> ListAll()
        {
            return _branchesApplicationDal.AllList();
        }


        public BranchesApplication GetOne(int id)
        {
            return _branchesApplicationDal.GetOne(x => x.id == id);
        }

        public bool Add(BranchesApplication branchesApplication)
        {
            bool result = _branchesApplicationDal.Add(branchesApplication);
            if (result)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Update(BranchesApplication branchesApplication)
        {
            bool result = _branchesApplicationDal.Update(branchesApplication);
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
            BranchesApplication branchesApplication = _branchesApplicationDal.GetOne(x => x.id == id);
            bool result = _branchesApplicationDal.Delete(branchesApplication);    
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