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
    [Authorize(Roles = "Moderator")]
    public class CategoriesController : Controller
    {
        ICategoryBll _categoryBll=new CategoryBll(new CategoryDal());
        // GET: AdminPanel/Categories
        public ActionResult Index()
        {
            List < Category > cat=_categoryBll.ListAll();


            return View(cat);
        }
        [HttpPost]
        public ActionResult categoryAdd(string categoryName)
        {
            if (!string.IsNullOrEmpty(categoryName)||categoryName!="")
            {
                Category cat;
                cat = _categoryBll.GetOneWithCategoryName(categoryName);
                if (cat!=null)
                {
                    cat= new Category();
                    cat.categoryName = categoryName;
                    _categoryBll.Add(cat);
                }
                
            }
           
            return RedirectToAction("Index", "Categories", new {area = "AdminPanel"});
        }
        [HttpPost]
        public ActionResult categoryDelete(int id)
        {
            Category cat=_categoryBll.GetOne(id);
            if (cat!=null)
            {
                _categoryBll.Delete(id);
                return RedirectToAction("Index","Categories",new {area="AdminPanel"});
            }
            else
            {
                return Json(new {code=1, message="Böyle Bir Kayıt Bulunamadı"});
            }

        }
    }
}