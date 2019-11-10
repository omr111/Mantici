using Mantici.Bll.Abstract;

namespace Mantici.Bll.Concrete
{
    public class ProductBll:IProductBll
    {

        public System.Collections.Generic.List<Entities.Models.Product> ListAll(System.Linq.Expressions.Expression<System.Func<Entities.Models.Product, bool>> filter = null)
        {
            throw new System.NotImplementedException();
        }

        public Entities.Models.Product GetOne(System.Linq.Expressions.Expression<System.Func<Entities.Models.Product, bool>> filter)
        {
            throw new System.NotImplementedException();
        }

        public bool Add(Entities.Models.Product product)
        {
            throw new System.NotImplementedException();
        }

        public bool Update(Entities.Models.Product product)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}