using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Web;

namespace Mantici.MVCWebUI.App_Classes
{
    public class settings
    {
        public static Size companyLogo
        {
            get
            {
                Size sonuc = new Size();
                sonuc.Width = Convert.ToInt32(ConfigurationManager.AppSettings["logoWith"]);
                sonuc.Height = Convert.ToInt32(ConfigurationManager.AppSettings["logoHeight"]);
                return sonuc;
            }

        }
        public static Size companyPicture
        {
            get
            {
                Size sonuc = new Size();
                sonuc.Width = Convert.ToInt32(ConfigurationManager.AppSettings["compWith"]);
                sonuc.Height = Convert.ToInt32(ConfigurationManager.AppSettings["compHeight"]);
                return sonuc;
            }

        }
        public static Size pictureSize
        {
            get
            {
                Size sonuc = new Size();
                sonuc.Width = Convert.ToInt32(ConfigurationManager.AppSettings["sw"]);
                sonuc.Height = Convert.ToInt32(ConfigurationManager.AppSettings["sh"]);
                return sonuc;
            }

        }
        public static Size BranchSmallSize
        {
            get
            {
                Size sonuc = new Size();
                sonuc.Width = Convert.ToInt32(ConfigurationManager.AppSettings["branchSmallWidth"]);
                sonuc.Height = Convert.ToInt32(ConfigurationManager.AppSettings["branchSmallHeight"]);
                return sonuc;
            }

        }
        public static Size BranchBigSize
        {
            get
            {
                Size sonuc = new Size();
                sonuc.Width = Convert.ToInt32(ConfigurationManager.AppSettings["branchBigWidth"]);
                sonuc.Height = Convert.ToInt32(ConfigurationManager.AppSettings["branchBigHeight"]);
                return sonuc;
            }

        }
        //public static Size BuyukResimYol
        //{
        //    get
        //    {
        //        Size sonuc = new Size();
        //        sonuc.Width = Convert.ToInt32(ConfigurationManager.AppSettings["lw"]);
        //        sonuc.Height = Convert.ToInt32(ConfigurationManager.AppSettings["lh"]);
        //        return sonuc;
        //    }

        //}
        //public static Size KullaniciResim
        //{
        //    get
        //    {
        //        Size sonuc = new Size();
        //        sonuc.Width = Convert.ToInt32(ConfigurationManager.AppSettings["kfw"]);
        //        sonuc.Height = Convert.ToInt32(ConfigurationManager.AppSettings["kfh"]);
        //        return sonuc;
        //    }
        //}
        //public static Size YazarResim
        //{
        //    get
        //    {
        //        Size size = new Size();
        //        size.Height = Convert.ToInt32(ConfigurationManager.AppSettings["yh"]);
        //        size.Width = Convert.ToInt32(ConfigurationManager.AppSettings["yw"]);
        //        return size;
        //    }
        //}
    }
}