using CafeOtomasyonu.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CafeOtomasyonu.Controllers
{
    public class YiyecekController : Controller
    {
        CafeDBEntities db = new CafeDBEntities();


        // GET: Yiyecek
        public ActionResult Index()
        {
            var model = db.Yiyecek.ToList();
            return View(model);
        }
        [HttpGet]
        public ActionResult Kaydet()
        {

            return View("YiyecekForm");
        }

        [HttpPost]

        public ActionResult Kaydet(Yiyecek yiyecek)
        {
            if (yiyecek.YiyecekID == 0)
            {
                db.Yiyecek.Add(yiyecek);
            }
            else
            {
                var guncellenecekyiyecek = db.Yiyecek.Find(yiyecek.YiyecekID);
                if (guncellenecekyiyecek == null)
                {
                    return HttpNotFound();
                }
                guncellenecekyiyecek.Yiyecekİsim = yiyecek.Yiyecekİsim;
                guncellenecekyiyecek.Yiyecekİsim = yiyecek.Yiyecekİsim;
                guncellenecekyiyecek.YiyecekFiyat = yiyecek.YiyecekFiyat;
            }

            db.Yiyecek.Add(yiyecek);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult Guncelle(int id)
        {
            var model = db.Yiyecek.Find(id);
            if (model == null)
                return HttpNotFound();

            return View("YiyecekForm", model);
        }

        public ActionResult Sil(int id)
        {
            var silinecekYiyecek = db.Yiyecek.Find(id);
            if (silinecekYiyecek == null)
                return HttpNotFound();
            db.Yiyecek.Remove(silinecekYiyecek);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
