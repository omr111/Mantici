using Mantici.Bll.Abstract;

namespace Mantici.Bll.Concrete
{
    public class BranchBll:IBranchBll
    {

        public System.Collections.Generic.List<Entities.Models.Branch> ListAll(System.Linq.Expressions.Expression<System.Func<Entities.Models.Branch, bool>> filter = null)
        {
            throw new System.NotImplementedException();
        }

        public Entities.Models.Branch GetOne(System.Linq.Expressions.Expression<System.Func<Entities.Models.Branch, bool>> filter)
        {
            throw new System.NotImplementedException();
        }

        public bool Add(Entities.Models.Branch branch)
        {
            throw new System.NotImplementedException();
        }

        public bool Update(Entities.Models.Branch branch)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}