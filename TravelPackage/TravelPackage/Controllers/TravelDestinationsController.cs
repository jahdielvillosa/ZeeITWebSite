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
    public class TravelDestinationsController : Controller
    {
        private TravelDBContainer db = new TravelDBContainer();

        // GET: tpAreas
        public ActionResult Index()
        {
            return View(db.tpAreas.ToList());
        }

        // GET: tpAreas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tpAreas tpAreas = db.tpAreas.Find(id);
            if (tpAreas == null)
            {
                return HttpNotFound();
            }
            return View(tpAreas);
        }

        // GET: tpAreas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tpAreas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,PageRemarks,PageView,Sort")] tpAreas tpAreas)
        {
            if (ModelState.IsValid)
            {
                db.tpAreas.Add(tpAreas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tpAreas);
        }

        // GET: tpAreas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tpAreas tpAreas = db.tpAreas.Find(id);
            if (tpAreas == null)
            {
                return HttpNotFound();
            }
            return View(tpAreas);
        }

        // POST: tpAreas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,PageRemarks,PageView,Sort")] tpAreas tpAreas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tpAreas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tpAreas);
        }

        // GET: tpAreas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tpAreas tpAreas = db.tpAreas.Find(id);
            if (tpAreas == null)
            {
                return HttpNotFound();
            }
            return View(tpAreas);
        }

        // POST: tpAreas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tpAreas tpAreas = db.tpAreas.Find(id);
            db.tpAreas.Remove(tpAreas);
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
