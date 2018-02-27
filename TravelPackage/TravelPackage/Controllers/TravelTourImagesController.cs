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
    public class TravelTourImagesController : Controller
    {
        private TravelDBContainer db = new TravelDBContainer();

        // GET: TravelTourImages
        public ActionResult Index()
        {
            var tpProductImages = db.tpProductImages.Include(t => t.tpProduct);
            return View(tpProductImages.ToList());
        }

        // GET: TravelTourImages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tpProductImages tpProductImages = db.tpProductImages.Find(id);
            if (tpProductImages == null)
            {
                return HttpNotFound();
            }
            return View(tpProductImages);
        }

        // GET: TravelTourImages/Create
        public ActionResult Create()
        {
            ViewBag.tpProductsId = new SelectList(db.tpProducts, "Id", "Name");
            return View();
        }

        // POST: TravelTourImages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,tpProductsId,ImgPath,Desc,AltName,Sort")] tpProductImages tpProductImages)
        {
            if (ModelState.IsValid)
            {
                db.tpProductImages.Add(tpProductImages);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.tpProductsId = new SelectList(db.tpProducts, "Id", "Name", tpProductImages.tpProductsId);
            return View(tpProductImages);
        }

        // GET: TravelTourImages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tpProductImages tpProductImages = db.tpProductImages.Find(id);
            if (tpProductImages == null)
            {
                return HttpNotFound();
            }
            ViewBag.tpProductsId = new SelectList(db.tpProducts, "Id", "Name", tpProductImages.tpProductsId);
            return View(tpProductImages);
        }

        // POST: TravelTourImages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,tpProductsId,ImgPath,Desc,AltName,Sort")] tpProductImages tpProductImages)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tpProductImages).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.tpProductsId = new SelectList(db.tpProducts, "Id", "Name", tpProductImages.tpProductsId);
            return View(tpProductImages);
        }

        // GET: TravelTourImages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tpProductImages tpProductImages = db.tpProductImages.Find(id);
            if (tpProductImages == null)
            {
                return HttpNotFound();
            }
            return View(tpProductImages);
        }

        // POST: TravelTourImages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tpProductImages tpProductImages = db.tpProductImages.Find(id);
            db.tpProductImages.Remove(tpProductImages);
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
