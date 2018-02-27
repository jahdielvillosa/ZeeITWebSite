using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TravelPackage.Models;

namespace TravelPackage.Controllers
{
    public class TravelTourPackagesController : Controller
    {
        private TravelDBContainer db = new TravelDBContainer();

        // GET: tpProducts
        public ActionResult Index()
        {
            var tpProducts = db.tpProducts.Include(t => t.tpArea);
            return View(tpProducts.ToList());
        }

        public ActionResult PackagesByCategory(int? CategoryId)
        {
            var tpCat = db.tpProdCats.Where(d => d.tpCategoryId == (int) CategoryId).Select( s=> s.Id);
            var tpProducts = db.tpProducts.Include(t => t.tpArea).Where( d=> tpCat.Contains( d.Id));
            return View("index", tpProducts.ToList() );
        }

        public ActionResult PackagesByTags(string sTag)
        {
            var tags = db.tpKeywords.Where(d => d.Keyword.Contains(sTag)).Select(d => d.tpProductsId).ToList();
            var data = db.tpProducts.Where(d => tags.Contains(d.Id)).ToList();
            return View("Index", data);
        }

        // GET: tpProducts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tpProducts tpProducts = db.tpProducts.Find(id);
            if (tpProducts == null)
            {
                return HttpNotFound();
            }
            return View(tpProducts);
        }

        // GET: tpProducts/Create
        public ActionResult Create()
        {
            ViewBag.tpAreasId = new SelectList(db.tpAreas, "Id", "Name");
            return View();
        }

        // POST: tpProducts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,ShortRemarks,PageView,PgFeatureImg,Sort,tpAreasId")] tpProducts tpProducts)
        {
            if (ModelState.IsValid)
            {
                db.tpProducts.Add(tpProducts);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.tpAreasId = new SelectList(db.tpAreas, "Id", "Name", tpProducts.tpAreasId);
            return View(tpProducts);
        }

        // GET: tpProducts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tpProducts tpProducts = db.tpProducts.Find(id);
            if (tpProducts == null)
            {
                return HttpNotFound();
            }
            ViewBag.tpAreasId = new SelectList(db.tpAreas, "Id", "Name", tpProducts.tpAreasId);
            return View(tpProducts);
        }

        // POST: tpProducts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,ShortRemarks,PageView,PgFeatureImg,Sort,tpAreasId")] tpProducts tpProducts)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tpProducts).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.tpAreasId = new SelectList(db.tpAreas, "Id", "Name", tpProducts.tpAreasId);
            return View(tpProducts);
        }

        // GET: tpProducts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tpProducts tpProducts = db.tpProducts.Find(id);
            if (tpProducts == null)
            {
                return HttpNotFound();
            }
            return View(tpProducts);
        }

        // POST: tpProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tpProducts tpProducts = db.tpProducts.Find(id);
            db.tpProducts.Remove(tpProducts);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
