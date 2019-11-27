using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mantici.Bll.Abstract;
using Mantici.Bll.Concrete;
using Mantici.Bll.Concrete.EfRepository;
using Mantici.Entities.Models;

namespace Mantici.MVCWebUI.Areas.AdminPanel.Controllers
{
    public class reviewController : Controller
    {
        IreviewBll _reviewBll = new reviewBll(new reviewDal());
        // GET: AdminPanel/review
        public ActionResult Index()
        {
            
            return View(_reviewBll.ListAll());
        }
        [HttpPost]
        public int reviewDelete(int id)
        {

                bool resultDelete = _reviewBll.Delete(id);
                if (resultDelete)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
                return 0;
        }
           
        
    }
}