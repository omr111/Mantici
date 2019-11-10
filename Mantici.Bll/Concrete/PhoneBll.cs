using Mantici.Bll.Abstract;

namespace Mantici.Bll.Concrete
{
    public class PhoneBll:IPhoneBll
    {

        public System.Collections.Generic.List<Entities.Models.Phone> ListAll(System.Linq.Expressions.Expression<System.Func<Entities.Models.Phone, bool>> filter = null)
        {
            throw new System.NotImplementedException();
        }

        public Entities.Models.Branch GetOne(System.Linq.Expressions.Expression<System.Func<Entities.Models.Phone, bool>> filter)
        {
            throw new System.NotImplementedException();
        }

        public bool Add(Entities.Models.Phone phone)
        {
            throw new System.NotImplementedException();
        }

        public bool Update(Entities.Models.Phone phone)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}