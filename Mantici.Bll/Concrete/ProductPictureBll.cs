using Mantici.Bll.Abstract;

namespace Mantici.Bll.Concrete
{
    public class ProductPictureBll:IProductPictureBll
    {

        public System.Collections.Generic.List<Entities.Models.ProductPicture> ListAll(System.Linq.Expressions.Expression<System.Func<Entities.Models.ProductPicture, bool>> filter = null)
        {
            throw new System.NotImplementedException();
        }

        public Entities.Models.ProductPicture GetOne(System.Linq.Expressions.Expression<System.Func<Entities.Models.ProductPicture, bool>> filter)
        {
            throw new System.NotImplementedException();
        }

        public bool Add(Entities.Models.ProductPicture productPictureh)
        {
            throw new System.NotImplementedException();
        }

        public bool Update(Entities.Models.ProductPicture productPicture)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}