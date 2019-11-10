using Mantici.Bll.Abstract;

namespace Mantici.Bll.Concrete
{
    public class BranchPhoneBll:IBranchPhoneBll
    {

        public System.Collections.Generic.List<Entities.Models.BranchPhone> ListAll(System.Linq.Expressions.Expression<System.Func<Entities.Models.BranchPhone, bool>> filter = null)
        {
            throw new System.NotImplementedException();
        }

        public Entities.Models.BranchPhone GetOne(System.Linq.Expressions.Expression<System.Func<Entities.Models.BranchPhone, bool>> filter)
        {
            throw new System.NotImplementedException();
        }

        public bool Add(Entities.Models.BranchPhone branchPhone)
        {
            throw new System.NotImplementedException();
        }

        public bool Update(Entities.Models.BranchPhone branchPhone)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}