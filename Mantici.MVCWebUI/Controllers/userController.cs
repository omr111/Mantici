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
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Web.Services.Description;

namespace Mantici.MVCWebUI.Controllers
{
    public class userController : Controller
    {
        ICompanyInformationBll _company=new CompanyInformationBll(new CompanyInformationDal());
        IuserBll _userBll=new userBll(new userDal());
        // GET: login
        public ActionResult Index()
        {
            CompanyInformation comp = _company.GetOneWitId(2);
            if (comp!=null)
            {
                return View(comp); 
            }
            else
            {
                return View();
            }
          
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
       
        [HttpPost]
        [ValidateAntiForgeryToken]
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
                       
                       
                       bool resultAddUser= _userBll.Add(usr);
                       if (resultAddUser)
                       {
                           IroleOfUserBll _roleOfUserBll=new roleOfUserBll(new roleOfUserDal());
                           roleOfUser giveRoleOfUser=new roleOfUser();
                           giveRoleOfUser.roleID = 6;//uye
                           giveRoleOfUser.userID = usr.id;
                           _roleOfUserBll.Add(giveRoleOfUser);

                       }
                       else
                       {
                           ViewData["userError"] = "Kayıt Sırasında Bir Hata Meydana Geldi!";

                           return View("Index");
                       }

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

        public ActionResult userProfile()
        {
            if (User.Identity.IsAuthenticated)
            {
                var name = User.Identity.Name;
                user user=_userBll.GetOneWithNick(name);
                if (user!=null)
                {
                    return View(user);   
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

           
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult userProfileUpdate(string newPass, user user)
        {
            user userName = _userBll.GetOne(user.id);
            try
            {
                if (ModelState.IsValid)
                {
                    
                    if (userName!=null)
                    {
                        userName.email = user.email;
                        userName.personelName = user.personelName;
                        userName.surname = user.surname;
                        if (userName.name != user.name)
                        {
                            user checkNick = _userBll.GetOneWithNick(user.name);
                            if (checkNick != null)
                            {
                                ViewData["userProfileError"] = "Böyle Bir Kullanıcı Zaten Kayıtlıdır.";
                                return View("userProfile",userName);
                            }
                            else
                            {
                                userName.name = user.name;
                               
                            }

                            
                        }

                        if (!string.IsNullOrEmpty(newPass))
                        {
                            userName.password = newPass;
                        }
                        _userBll.Update(userName);
                        FormsAuthentication.SetAuthCookie(user.name, false);
                        return RedirectToAction("userProfile");
                    }
                    else
                    {
                        return RedirectToAction("Index", "user");
                    }
                   
                }
                return View("userProfile", userName);
              
            }
            catch (Exception e)
            {
                ViewData["userProfileError"] = "Güncelleme Sırasında Bir Hata Meydana Geldi.";
                return View("userProfile",userName);
            }
       
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult pictureUpdate(int id, HttpPostedFileBase file)
        {
            user user=_userBll.GetOne(id);
            if (user!=null)
            {
                if (file != null)
                {

                    if (System.IO.File.Exists(Server.MapPath(user.userPicturePath)))
                    {
                        System.IO.File.Delete(Server.MapPath(user.userPicturePath));

                    }
                    int iconWidth = settings.userPicture.Width;
                    int iconHeight = settings.userPicture.Height;

                    string newName = Path.GetFileNameWithoutExtension(file.FileName) + Path.GetExtension(file.FileName);
                    Image orjResim = Image.FromStream(file.InputStream);
                    Bitmap iconDraw = new Bitmap(orjResim, iconWidth, iconHeight);

                    iconDraw.Save(Server.MapPath("~/content/img/userPictures/" + newName));

                    string saveDBPath = "/content/img/userPictures/" + newName;

                    user.userPicturePath = saveDBPath;
                    bool resultUpdate = _userBll.Update(user);
                   if (resultUpdate)
                   {
                       return RedirectToAction("userProfile");
                   }
                   else
                   {
                       return RedirectToAction("userProfile");
                   }
                }
                else
                {
                    return RedirectToAction("userProfile");
                }
                
            }
            else
            {
                return RedirectToAction("Index","Home");
            }
          
        }

        [HttpPost]
        public ActionResult resetPassword(string changeName)
        {
            try
            {
                ICompanyInformationBll _companyInformation = new CompanyInformationBll(new CompanyInformationDal());
                CompanyInformation company = _companyInformation.GetOneWitId(2);
                user userPass = _userBll.GetOneWithMail(changeName);

                if (userPass != null)
                {
                    Random random = new Random();
                    int sifreUret = random.Next(15689, 99586);

                    userPass.password = sifreUret.ToString();
                    bool resultUpdate = _userBll.Update(userPass);

                    if (resultUpdate)
                    {

                        user reUser = _userBll.GetOneWithMail(changeName);
                        // mail adresi ve şifresi ne ise adminpanelden company information'dan mail ve şifreyi de aynısını yapmalı!
                        var senderEmail = new MailAddress(company.email.Trim(), "");
                        var receiverEmail = new MailAddress(userPass.email.Trim(), "Receiver");
                    
                        var password = company.emailPassword.Trim();
                        var sub = "Ayha.Net Şifre Reset";
                        var body = string.Format("Yeni Şifreniz {0}", reUser.password);


                        var smtp = new SmtpClient
                        {
                            Timeout = 10000,
                            Host = "mail.ayha.net",
                            Port = 587,
                            EnableSsl = false,
                            DeliveryMethod = SmtpDeliveryMethod.Network,
                            UseDefaultCredentials = true,
                            Credentials = new NetworkCredential(senderEmail.Address, password),

                        };
                        using (var mess = new MailMessage(senderEmail, receiverEmail)
                        {
                            IsBodyHtml = true,
                            BodyEncoding = UTF8Encoding.UTF8,
                            Subject = sub,
                            Body = body,
                            DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure,

                        })
                        {
                            smtp.Send(mess);
                        }

                        return Json("Yeni Şifreniz Mail Adresinize Gönderildi.");
                    }
                    else
                    {
                       
                        return Json("Mail Gönderilemedi Lütfen Tekrar Deneyiniz.");
                    }


                }
                else
                {
                    
                    return Json("Girilen Mail Adresi Kullanılmıyor !");
                }

            }



            catch (Exception EX_NAME)
            {
                ViewData["resetInfo"] = "Girilen Mail Adresi Kullanılmıyor !";
                return View("Index");
            }


        }

      
    }
} 