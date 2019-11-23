using System.Collections.Generic;
using Mantici.Entities.Models;

namespace Mantici.Bll.Abstract
{
    public interface IbannerBll
    {
        List<banner> defaultBannerList();
        bool addBanner(banner banner);
        banner getOneWithId(int id);
        bool deleteBanner(int id);
    }
}