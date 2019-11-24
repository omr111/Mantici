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
            product.coverPicturePath = pictureController.pictureAddForProduct(file, HttpContext);
            if (file.FileName.Length>50)
            {
                product.pictureAlt = file.FileName.Substring(0,49);
            }
            else
            {
                product.pictureAlt = file.FileName;
            }
            
            _productBll.Add(product);
            return RedirectToAction("Index", "product",new{area="AdminPanel"});
        }
        [HttpPost]
        public int productDelete(int id)
        {
      
            Product pro = _productBll.GetOne(id);
            
            if (pro != null)
            {
               

                if (System.IO.File.Exists(Server.MapPath(pro.coverPicturePath)))
                {
                    System.IO.File.Delete(Server.MapPath(pro.coverPicturePath));

                }

                bool resultDelete = _productBll.Delete(pro.id);
                if (resultDelete)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
               
            }
            return 0;
        }
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        [HttpPost]
        public int productUpdate(Product pro, HttpPostedFileBase file)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Product product = _productBll.GetOne(pro.id);
                    if (product != null)
                    {
                        if (file != null)
                        {
                            if (System.IO.File.Exists(Server.MapPath(pro.coverPicturePath)))
                            {
                                System.IO.File.Delete(Server.MapPath(pro.coverPicturePath));

                            }

                            product.coverPicturePath = pictureController.pictureAddForProduct(file, HttpContext);
                            product.pictureAlt = pro.pictureAlt;
                        }

                        product.categoryID = pro.categoryID;
                        product.caption = pro.caption;
                        product.description = pro.description;
                        product.price = pro.price;
                        bool resultUpdate = _productBll.Update(product);
                        if (resultUpdate)
                        {
                            return 1;
                        }
                        else
                        {
                            return 0;
                        }
                   
                    }
                    return 0;
                }
                return 0;
            }
            catch (Exception e)
            {
                return 0;
            }
        }
     
    }
}