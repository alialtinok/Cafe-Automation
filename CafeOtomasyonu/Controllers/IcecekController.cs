using CafeOtomasyonu.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CafeOtomasyonu.Controllers
{
    public class IcecekController : Controller
    {
        CafeDBEntities db = new CafeDBEntities();
        // GET: Icecek
        public ActionResult Index()
        {
            var model = db.Icecek.ToList();
            return View(model);
        }

        [HttpGet]
        public ActionResult Kaydet()
        {

            return View("IcecekForm");
        }

        [HttpPost]

        public ActionResult Kaydet(Icecek icecek)
        {
            if (icecek.IcecekID==0)
            {
                db.Icecek.Add(icecek);
            }
            else
            {
                var guncellenecekIcecek = db.Icecek.Find(icecek.IcecekID);
                if (guncellenecekIcecek==null)
                {
                    return HttpNotFound();
                }
                guncellenecekIcecek.IcecekKategori = icecek.IcecekKategori;
                guncellenecekIcecek.IcecekAd = icecek.IcecekAd;
                guncellenecekIcecek.IcecekFiyat = icecek.IcecekFiyat;
            }
            
            db.Icecek.Add(icecek);
            db.SaveChanges();
           return RedirectToAction("Index");
           
        }

        public ActionResult Guncelle (int id)
        {
            var model = db.Icecek.Find(id);
            if (model == null)
                return HttpNotFound();
          
            return View("IcecekForm", model);
        }

        public ActionResult Sil(int id)
        {
            var silinecekIcecek = db.Icecek.Find(id);
            if (silinecekIcecek==null)
               return HttpNotFound();
            db.Icecek.Remove(silinecekIcecek);
            db.SaveChanges();
            return RedirectToAction("Index"); 
        }

    }
}