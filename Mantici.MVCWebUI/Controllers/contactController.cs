using Mantici.Bll.Abstract;
using Mantici.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mantici.Bll.Concrete;
using Mantici.Bll.Concrete.EfRepository;
using Mantici.MVCWebUI.Models;
using System.Net.Mail;
using System.Net;
using System.Text;

namespace Mantici.MVCWebUI.Controllers
{
    [AllowAnonymous]
    public class contactController : Controller
    {
        // GET: contact
        ICompanyInformationBll _companyInformation=new CompanyInformationBll(new CompanyInformationDal());
        IuserBll _userBll=new userBll(new userDal());
        private IreviewBll _reviewBll = new reviewBll(new reviewDal());
        
        public ActionResult Index()
        {
            contactModel model = new contactModel();
            if (User.Identity.IsAuthenticated)
            {
                user user=_userBll.GetOneWithNick(User.Identity.Name);
               
                model.user = user;
                model.CompanyInformation = _companyInformation.GetOneWitId(2);
                return View(model);
            }
            else
            {
                model.CompanyInformation = _companyInformation.GetOneWitId(2);
            }
            return View(model);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult sendMail(review review,string selection)
        {
           
            try
            {
                if (ModelState.IsValid)
                {
                    if (selection == "Email Gönder")
                    {
                        CompanyInformation company = _companyInformation.GetOneWitId(2);

                      
                  
                        // mail adresi ve şifresi ne ise adminpanelden company information'dan mail ve şifreyi de aynısını yapmalı!
                        var senderEmail = new MailAddress(review.email.Trim(), "");
                        var receivereEmail = new MailAddress(company.email.Trim(), "Receiver");
                        var password = company.emailPassword.Trim();
                      
                        var sub = review.subject;
                        var body = review.comment;
                        var smtp = new SmtpClient
                          
                        {
                            Timeout = 10000,
                            Host = "mail.ayha.net",
                            Port = 587,
                            EnableSsl = false,
                            DeliveryMethod = SmtpDeliveryMethod.Network,
                            UseDefaultCredentials = false,
                            Credentials = new NetworkCredential(senderEmail.Address, password)
                        };
                        using (var mess = new MailMessage(senderEmail, receivereEmail)
                        {
                            IsBodyHtml = true,
                            BodyEncoding = UTF8Encoding.UTF8,
                            Subject = review.subject.ToString(),
                            Body = body,
                            DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure,

                        })
                        {
                            smtp.Send(mess);
                        }
                        Session["reviewInfo"] = "Mesaj Başarıyla Gönderildi.";
                        return RedirectToAction("Index");

                    }

                    else if (selection == "Eleştiri-Görüş")
                    {
                        review re = new review();
                        if (User.Identity.IsAuthenticated)
                        {

                            user usr = _userBll.GetOneWithNick(User.Identity.Name);
                            re.visitorName = usr.personelName;
                            re.visitorSurname = usr.surname;
                            re.comment = review.comment;
                            re.userID = usr.id;
                            re.subject = review.subject;
                            re.email = usr.email;
                            bool result1 = _reviewBll.Add(re);
                            if (result1)
                            {
                                Session["reviewInfo"] = "Yorum Başarıyla Gönderildi.";
                                return RedirectToAction("Index");
                              
                            }
                            else
                            {

                                Session["reviewInfo"] = "Yorum Gönderilemedi.";
                                return RedirectToAction("Index");
                            }
                        }
                        else
                        {
                            bool result2 = _reviewBll.Add(review);
                            if (result2)
                            {
                                return RedirectToAction("Index");
                                Session["reviewInfo"] = "Yorum Başarıyla Gönderildi.";
                            }
                            else
                            {
                                Session["reviewInfo"] = "Yorum Gönderilemedi.";
                                return RedirectToAction("Index");
                            }
                        }
                        return RedirectToAction("Index");
                        Session["reviewInfo"] = "Lütfen Eksik Alanları Doldurun !";
                    }
                    else
                    {
                        Session["reviewInfo"] = "Lütfen Bir Mesaj Gönderme Sebebi Seçiniz !";
                        return RedirectToAction("Index");
                    }
                }
                Session["reviewInfo"] = "Yorum Gönderilemedi.";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                Session["reviewInfo"] = e.Message;
                return RedirectToAction("Index");
            }
            
        }
    }
}