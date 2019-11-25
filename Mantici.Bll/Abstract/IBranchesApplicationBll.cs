using Mantici.Entities.Models;
using System.Collections.Generic;
namespace Mantici.Bll.Abstract
{
    public interface IBranchesApplicationBll
    {
        List<BranchesApplication> ListAll();

        BranchesApplication GetOne(int id);
        bool Add(BranchesApplication branchesApplication);
        bool Update(BranchesApplication branchesApplication);
        bool Delete(int id);
    }
}