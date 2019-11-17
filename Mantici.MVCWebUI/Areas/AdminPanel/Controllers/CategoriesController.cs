using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mantici.Bll.Abstract;
using Mantici.Bll.Concrete;
using Mantici.Bll.Concrete.EfRepository;

namespace Mantici.MVCWebUI.Areas.AdminPanel.Controllers
{
    public class CategoriesController : Controller
    {
        ICategoryBll _categoryBll=new CategoryBll(new CategoryDal());
        // GET: AdminPanel/Categories
        public ActionResult Index()
        {
            
            return View();
        }
    }
}