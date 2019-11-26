using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Mantici.Bll.Abstract;
using Mantici.Bll.Concrete;
using Mantici.Bll.Concrete.EfRepository;
using Mantici.Entities.Models;
using System.IO;
using Mantici.MVCWebUI.App_Classes;
using System.Drawing;

namespace Mantici.MVCWebUI.Controllers
{
    public class userController : Controller
    {
        IuserBll _userBll=new userBll(new userDal());
        // GET: login
        public ActionResult Index()
        {
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Index(user usr)
        {
            user user = _userBll.logIn(usr.name, usr.password);
           if (user!=null)
           {
               
               FormsAuthentication.SetAuthCookie(user.name,false);
               return RedirectToAction("Index","Home");
           }
           else
           {
               ViewData["logInError"] = "Kullanıcı Adı veya Şifre Yanlış!";
               return View();
           }
            
        }
        public ActionResult logOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "user");
        }

        public ActionResult signIn()
        {
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult signIn(user usr,HttpPostedFileBase file)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    user checkNick = _userBll.GetOneWithNick(usr.name);
                    if (checkNick == null)
                    {
                        if (file!=null)
                        {

                            int iconWidth = settings.userPicture.Width;
                            int iconHeight = settings.userPicture.Height;

                            string newName = Path.GetFileNameWithoutExtension(file.FileName) + Path.GetExtension(file.FileName);
                            Image orjResim = Image.FromStream(file.InputStream);
                            Bitmap iconDraw = new Bitmap(orjResim, iconWidth, iconHeight);

                            iconDraw.Save(Server.MapPath("~/content/img/userPictures/" + newName));

                            string saveDBPath = "/content/img/userPictures/" + newName;
                            usr.userPicturePath = saveDBPath;
                        }
                        _userBll.Add(usr);


                    }
                    else
                    {
                        ViewData["userError"] = "Kayıt Etmeye Çalıştığınız Kullanıcı Zaten Kayıtlıdır.";
                       
                        return View();
                    }
                }
                else
                {
                    ViewData["userError"] = "Geçersiz Kullanıcı Verileri Girildi !";
                 
                    return View();
                }

                return RedirectToAction("Index", "user");

            }
            catch (Exception e)
            {

                ViewData["userError"] = e.Message.ToString();
             
                return View();
            }
        }
    }
} 