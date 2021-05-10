using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KafeOtomasyonu.Models.Entitiy;


namespace KafeOtomasyonu.Controllers
{
    public class IcecekController : Controller
    {
        CafeDBEntities aa = new CafeDBEntities();
        
        // GET: Icecek
        public ActionResult Index()
        {
            var degerler = aa.Icecek.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult IcecekEkle()
        {
            return View();
        }
        [HttpPost]

        public ActionResult IcecekEkle(Icecek icecek)
        {
            aa.Icecek.Add(icecek);
            aa.SaveChanges();
            return RedirectToAction("Index","Icecek");
            
        }

    }
}