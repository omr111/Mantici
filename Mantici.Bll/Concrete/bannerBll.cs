using Mantici.Bll.Abstract;
using Mantici.Dal.Abstract;
using Mantici.Entities.Models;
using System.Collections.Generic;

namespace Mantici.Bll.Concrete
{
    public class bannerBll:IbannerBll
    {
        private IbannerDal _bannerDal;

        public bannerBll(IbannerDal bannerDal)
        {
            _bannerDal = bannerDal;
        }

       public List<banner> defaultBannerList()
        {
            return _bannerDal.AllList();
        }
       public bool addBanner(banner banner)
        {
            bool resultAdd = _bannerDal.Add(banner);
            if (resultAdd)
            {
                return true;
            }

            return false;
        }

     public  banner getOneWithId(int id)
       {
           return _bannerDal.GetOne(x => x.id == id);
       }

     public bool deleteBanner(int id)
       {
           banner bnr = _bannerDal.GetOne(x => x.id == id);
          bool result= _bannerDal.Delete(bnr);
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