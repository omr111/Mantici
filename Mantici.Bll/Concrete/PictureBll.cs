using Mantici.Bll.Abstract;
using Mantici.Dal.Abstract;
using Mantici.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Mantici.Bll.Concrete
{
    public class PictureBll:IPictureBll
    {

        private IPictureDal _pictureDal;

        public PictureBll(IPictureDal pictureDal)
        {
            _pictureDal = pictureDal;
        }
        public List<Picture> ListAll(Expression<Func<Picture, bool>> filter = null)
        {
            return _pictureDal.AllList();
        }

        public Picture GetOne(Expression<Func<Picture, bool>> filter)
        {
            return _pictureDal.GetOne(filter);
        }

        public bool Add(Picture picture)
        {
            bool result = _pictureDal.Add(picture);
            if (result)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Update(Picture picture)
        {
            bool result = _pictureDal.Update(picture);
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
            Picture picture = _pictureDal.GetOne(x => x.id == id);
            bool result = _pictureDal.Delete(picture);
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