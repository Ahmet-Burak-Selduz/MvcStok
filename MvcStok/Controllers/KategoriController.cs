using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace MvcStok.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        MvcDbStockEntities1 db = new MvcDbStockEntities1();
        public ActionResult Index(int sayfa=1)
        {
            var degerler = db.Tbl_Kategoriler.ToList().ToPagedList(sayfa,4);
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniKategori()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniKategori(Tbl_Kategoriler p1)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniKategori");
            }
            db.Tbl_Kategoriler.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            var kategori = db.Tbl_Kategoriler.Find(id);
            db.Tbl_Kategoriler.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriGetir(int id)
        {
            var kategori = db.Tbl_Kategoriler.Find(id);
            return View("KategoriGetir", kategori);
        }
        public ActionResult Guncelle(Tbl_Kategoriler p1)
        {
            var ktg = db.Tbl_Kategoriler.Find(p1.KategoriId);
            ktg.KategoriAd = p1.KategoriAd;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}