using Mantici.Bll.Abstract;
using Mantici.Dal.Abstract;
using Mantici.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Mantici.Bll.Concrete
{
    public class rezervedFoodBll:IrezervedFoodBll
    {
        private IrezervedFoodDal _rezervedFoodDal;

        public rezervedFoodBll(IrezervedFoodDal rezervedFoodDal)
        {
            _rezervedFoodDal = rezervedFoodDal;
        }
        public List<rezervedFood> ListAll(Expression<Func<rezervedFood, bool>> filter = null)
        {
            return _rezervedFoodDal.AllList();
        }

        public rezervedFood GetOne(Expression<Func<rezervedFood, bool>> filter)
        {
            return _rezervedFoodDal.GetOne(filter);
        }

        public bool Add(rezervedFood rezervedFood)
        {
            bool result = _rezervedFoodDal.Add(rezervedFood);
            if (result)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Update(rezervedFood rezervedFood)
        {
            bool result = _rezervedFoodDal.Update(rezervedFood);
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
            rezervedFood rezervedFood = _rezervedFoodDal.GetOne(x => x.id == id);
            bool result = _rezervedFoodDal.Delete(rezervedFood);    
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