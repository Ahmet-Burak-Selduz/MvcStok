using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;

namespace MvcStok.Controllers
{
    public class SatisController : Controller
    {
        // GET: Satis
        MvcDbStockEntities1 db = new MvcDbStockEntities1();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult YeniSatis()
        {
            return View("Index");
        }
        [HttpPost]
        public ActionResult YeniSatis(Tbl_Satislar p)
        {
            db.Tbl_Satislar.Add(p);
            db.SaveChanges();
            return View("Index");
        }
    }
}