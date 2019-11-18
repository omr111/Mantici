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
    public class productController : Controller
    {
        ICategoryBll _categoryBll=new CategoryBll(new CategoryDal());
        IProductBll _productBll =new ProductBll(new ProductDal());
        // GET: AdminPanel/product
        public ActionResult Index()
        {
           
            return View(_productBll.ListAll());
        }

        public ActionResult productAdd()
        {
            List<Category> categories = _categoryBll.ListAll();
            return View(categories);
        }

        [HttpPost]
        public ActionResult productAdd(Product product, HttpPostedFileBase file)
        {
            product.coverPicture = pictureController.pictureAdd(file, HttpContext);
            _productBll.Add(product);
            return RedirectToAction("Index", "product",new{area="AdminPanel"});
        }
        public ActionResult productDelete(int id)
        {
            //Makale m = ctx.Makales.FirstOrDefault(x => x.id == makale.id);
            //if (Resim != null)
            //{

            //    Resim makaleResim = ctx.Resims.FirstOrDefault(x => x.id == m.KapakResimID);

            //    if (System.IO.File.Exists(Server.MapPath("/Content/BuyukResim/" + makaleResim.BuyukResimYol)))
            //    {
            //        System.IO.File.Delete(Server.MapPath("/Content/BuyukResim/" + makaleResim.BuyukResimYol));

            //    }
            //    if (System.IO.File.Exists(Server.MapPath("/Content/BuyukResim/" + makaleResim.KucukResimYol)))
            //    {
            //        System.IO.File.Delete(Server.MapPath("/Content/BuyukResim/" + makaleResim.BuyukResimYol));
            //    }

            //    ctx.Entry(makaleResim).State = EntityState.Deleted;
            //    ctx.SaveChanges();
            //    m.KapakResimID = ResimKaydet(Resim, HttpContext);
            //}
            return View();
        }
        //[ValidateInput(false)]
        //public ActionResult productUpdate(int id)
        //{
          
        //    return View();
        //}
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult productUpdate(Product product, HttpPostedFile file)
        {
            //Makale m = ctx.Makales.FirstOrDefault(x => x.id == makale.id);
            //if (Resim != null)
            //{

            //    Resim makaleResim = ctx.Resims.FirstOrDefault(x => x.id == m.KapakResimID);

            //    if (System.IO.File.Exists(Server.MapPath("/Content/BuyukResim/" + makaleResim.BuyukResimYol)))
            //    {
            //        System.IO.File.Delete(Server.MapPath("/Content/BuyukResim/" + makaleResim.BuyukResimYol));

            //    }
            //    if (System.IO.File.Exists(Server.MapPath("/Content/BuyukResim/" + makaleResim.KucukResimYol)))
            //    {
            //        System.IO.File.Delete(Server.MapPath("/Content/BuyukResim/" + makaleResim.BuyukResimYol));
            //    }

            //    ctx.Entry(makaleResim).State = EntityState.Deleted;
            //    ctx.SaveChanges();
            //    m.KapakResimID = ResimKaydet(Resim, HttpContext);
            //}



            return RedirectToAction("Index", "product",new {area="AdminPanel"});
        }
    }
}