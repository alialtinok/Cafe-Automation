using CafeOtomasyonu.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CafeOtomasyonu.Controllers
{ 
    [Authorize]
    public class MasaController : Controller
    {
        CafeDBEntities db = new CafeDBEntities();
        // GET: Masa
       
        public ActionResult Index()
        {
            var model = db.Masa.ToList();
            return View(model);
        }

        [HttpGet]
        public ActionResult Kaydet()
        {

            return View("MasaForm");
        }

        [HttpPost]

        public ActionResult Kaydet(Masa masa)
        {
            if (masa.MasaID== 0)
            {
                db.Masa.Add(masa);
            }
            else
            {
                var guncellenecekMasa = db.Masa.Find(masa.MasaID);
                if (guncellenecekMasa == null)
                {
                    return HttpNotFound();
                }
                guncellenecekMasa.MasaIsim = masa.MasaIsim;
                guncellenecekMasa.MasaHesap = masa.MasaHesap;
                
            }

            db.Masa.Add(masa);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult Guncelle(int id)
        {
            var model = db.Masa.Find(id);
            if (model == null)
                return HttpNotFound();

            return View("MasaForm", model);
        }

        public ActionResult Sil(int id)
        {
            var silinecekMasa = db.Masa.Find(id);
            if (silinecekMasa == null)
                return HttpNotFound();
            db.Masa.Remove(silinecekMasa);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}