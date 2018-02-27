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
    public class TravelTourCategoriesController : Controller
    {
        private TravelDBContainer db = new TravelDBContainer();

        // GET: TravelTourCategories
        public ActionResult Index()
        {
            return View(db.tpCategories.ToList());
        }

        // GET: TravelTourCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tpCategory tpCategory = db.tpCategories.Find(id);
            if (tpCategory == null)
            {
                return HttpNotFound();
            }
            return View(tpCategory);
        }

        // GET: TravelTourCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TravelTourCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Description,SysCode")] tpCategory tpCategory)
        {
            if (ModelState.IsValid)
            {
                db.tpCategories.Add(tpCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tpCategory);
        }

        // GET: TravelTourCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tpCategory tpCategory = db.tpCategories.Find(id);
            if (tpCategory == null)
            {
                return HttpNotFound();
            }
            return View(tpCategory);
        }

        // POST: TravelTourCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Description,SysCode")] tpCategory tpCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tpCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tpCategory);
        }

        // GET: TravelTourCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tpCategory tpCategory = db.tpCategories.Find(id);
            if (tpCategory == null)
            {
                return HttpNotFound();
            }
            return View(tpCategory);
        }

        // POST: TravelTourCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tpCategory tpCategory = db.tpCategories.Find(id);
            db.tpCategories.Remove(tpCategory);
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
