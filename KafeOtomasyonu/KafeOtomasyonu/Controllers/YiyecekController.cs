using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KafeOtomasyonu.Models.Entitiy;


namespace KafeOtomasyonu.Controllers
{
    public class YiyecekController : Controller
    {
        CafeDBEntities altinokCafe = new CafeDBEntities();

        // GET: Yiyecek
        public ActionResult Index()
        {
            var degerler = altinokCafe.Yiyecek.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult YiyecekEkle()
        {
            return View();
        }
        [HttpPost]

        public ActionResult YiyecekEkle(Yiyecek icecek)
        {
            altinokCafe.Yiyecek.Add(icecek);
            altinokCafe.SaveChanges();
            return RedirectToAction("Index", "Yiyecek");

        }

    }
}