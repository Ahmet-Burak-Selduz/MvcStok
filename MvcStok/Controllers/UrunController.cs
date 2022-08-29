using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;

namespace MvcStok.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        MvcDbStockEntities1 db = new MvcDbStockEntities1();
        public ActionResult Index()
        {
            var degerler = db.Tbl_Urunler.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniUrun()
        {
            List<SelectListItem> degerler=(from i in db.Tbl_Kategoriler.ToList() select new SelectListItem {Text = i.KategoriAd, Value=i.KategoriId.ToString()}).ToList();
            ViewBag.dgr = degerler;
            return View();
        }

        [HttpPost]
        public ActionResult YeniUrun(Tbl_Urunler p1)
        {
            var ktg = db.Tbl_Kategoriler.Where(m => m.KategoriId == p1.Tbl_Kategoriler.KategoriId).FirstOrDefault();
            p1.Tbl_Kategoriler = ktg;
            db.Tbl_Urunler.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            var urun = db.Tbl_Urunler.Find(id);
            db.Tbl_Urunler.Remove(urun);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunGetir(int id)
        {
            var urn = db.Tbl_Urunler.Find(id);
            List<SelectListItem> degerler = (from i in db.Tbl_Kategoriler.ToList() select new SelectListItem { Text = i.KategoriAd, Value = i.KategoriId.ToString() }).ToList();
            ViewBag.dgr = degerler;
            return View("UrunGetir", urn);
        }
        public ActionResult Guncelle(Tbl_Urunler p)
        {
            var urun = db.Tbl_Urunler.Find(p.UrunId);
            urun.UrunAd=p.UrunAd;
            urun.Marka = p.Marka;
            urun.Stok = p.Stok;
            urun.Fiyat=p.Fiyat;
            var ktg = db.Tbl_Kategoriler.Where(m => m.KategoriId == p.Tbl_Kategoriler.KategoriId).FirstOrDefault();
            urun.UrunKategori = ktg.KategoriId;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}