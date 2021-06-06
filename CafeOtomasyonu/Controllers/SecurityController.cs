using CafeOtomasyonu.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CafeOtomasyonu.Controllers
{
    public class SecurityController : Controller
    {
        CafeDBEntities db = new CafeDBEntities();
        // GET: Security
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Admin admin)
        {
            var kullanici = db.Admin.FirstOrDefault(x=>x.isim==admin.isim && x.sifre==admin.sifre);
            if (kullanici!=null)
            {
                FormsAuthentication.SetAuthCookie(kullanici.isim, true);
                 return RedirectToAction("Index","Anasayfa");
            }
            else
            {
                
                ViewBag.Mesaj = "Geçersiz Kullanıcı Adı veya Şifre";
                ViewBag.color = "red";
                return View();
            }
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return View("Login");
        }

    }
}