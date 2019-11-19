using System.Collections.Generic;
using System.Linq;
using Mantici.Bll.Abstract;
using Mantici.Dal.Abstract;
using Mantici.Entities.Models;

namespace Mantici.Bll.Concrete
{
    public class CategoryBll:ICategoryBll
    {
        private ICategoryDal _categoryDal;

        public CategoryBll(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public List<Category> ListAll(System.Linq.Expressions.Expression<System.Func<Category, bool>> filter = null)
        {
            return _categoryDal.AllList().ToList();
        }

        public Category GetOne(int id)
        {
            Category cat=_categoryDal.GetOne(x=>x.id==id);
            if (cat!=null)
            {
                return cat;
            }
            else
            {
                return null;
            }
           
        }

        public bool Add(Category category)
        {
            bool result=_categoryDal.Add(category);
            if (result)
            {
                return true;
            }

            return false;
        }

        public bool Update(Category category)
        {
            bool result=_categoryDal.Update(category);
            if (result)
            {
                return true;
            }

            return false;
        }

        public bool Delete(int id)
        {
            Category category = _categoryDal.GetOne(x => x.id == id);
            bool result=_categoryDal.Delete(category);
            if (result)
            {
                return true;
            }
            return false;
        }


        public Category GetOneWithCategoryName(string categoryName)
        {
            return _categoryDal.GetOne(x => x.categoryName == categoryName);
        }
    }
}