using Mantici.MVCWebUI.App_Classes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mantici.Bll.Abstract;
using Mantici.Bll.Concrete;
using Mantici.Bll.Concrete.EfRepository;
using Mantici.Entities.Models;
using System.IO;

namespace Mantici.MVCWebUI.Areas.AdminPanel.Controllers
{
    public class pictureController : Controller
    {
        // GET: AdminPanel/picture
        public ActionResult Index()
        {
            return View();
        }

        public static string pictureAdd(HttpPostedFileBase file, HttpContextBase context)
        {

            IPictureBll _pictureBll = new PictureBll(new PictureDal());
            int picWidth = settings.pictureSize.Width;
            int pichHeight = settings.pictureSize.Height;
            string newName = Path.GetFileNameWithoutExtension(file.FileName) + "-" + Guid.NewGuid() + Path.GetExtension(file.FileName);
            Image orjResim = Image.FromStream(file.InputStream);
            Bitmap pictureDraw = new Bitmap(orjResim, picWidth, pichHeight);
            pictureDraw.Save(context.Server.MapPath("/content/img/productPicture/menuPicture/" + newName));

            Picture pp = new Picture();
            pp.smallPath = "/content/img/productPicture/menuPicture/" + newName;
            //resmin alt'ı olarak kullanacağım filename'i
            pp.pictureAlt = file.FileName;
            bool result = _pictureBll.Add(pp);
           if (result)
           {
               return pp.smallPath; 
           }
           else
           {
               return "";
           }
            
        }

        public static int pictureAddInt(HttpPostedFileBase file, HttpContextBase context)
        {
            IPictureBll _pictureBll = new PictureBll(new PictureDal());
            int picSmallWidth = settings.BranchSmallSize.Width;
            int picSmallHeight = settings.BranchSmallSize.Height;
            int picBigWidth = settings.BranchBigSize.Width;
            int picBigHeight = settings.BranchBigSize.Height;
            string newName = Path.GetFileNameWithoutExtension(file.FileName) + "-" + Guid.NewGuid() + Path.GetExtension(file.FileName);
            Image orjResim = Image.FromStream(file.InputStream);
            Bitmap pictureSmallDraw = new Bitmap(orjResim, picSmallWidth, picSmallHeight);
            Bitmap pictureBigDraw = new Bitmap(orjResim, picBigWidth, picBigHeight);
            pictureSmallDraw.Save(context.Server.MapPath("~/content/img/branchPicture/smallPicture/" + newName));
            pictureBigDraw.Save(context.Server.MapPath("~/content/img/branchPicture/bigPicture/" + newName));
            Picture pp = new Picture();
            pp.smallPath = "/content/img/branchPicture/smallPicture/" + newName;
            //resmin alt'ı olarak kullanacağım filename'i
            pp.pictureAlt = file.FileName;
            bool result = _pictureBll.Add(pp);

            if (result)
            {
                return pp.id;
            }
            else
            {
                return 0;
            }

        }
    }
}