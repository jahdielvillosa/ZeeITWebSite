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
    public class TravelTourBacklinksController : Controller
    {
        private TravelDBContainer db = new TravelDBContainer();

        // GET: TravelTourBacklinks
        public ActionResult Index()
        {
            return View(db.tpBacklinks.ToList());
        }

        // GET: TravelTourBacklinks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tpBacklink tpBacklink = db.tpBacklinks.Find(id);
            if (tpBacklink == null)
            {
                return HttpNotFound();
            }
            return View(tpBacklink);
        }

        // GET: TravelTourBacklinks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TravelTourBacklinks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,LinkType,LinkUrl,Description,LinkExpiry,Status")] tpBacklink tpBacklink)
        {
            if (ModelState.IsValid)
            {
                db.tpBacklinks.Add(tpBacklink);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tpBacklink);
        }

        // GET: TravelTourBacklinks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tpBacklink tpBacklink = db.tpBacklinks.Find(id);
            if (tpBacklink == null)
            {
                return HttpNotFound();
            }
            return View(tpBacklink);
        }

        // POST: TravelTourBacklinks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,LinkType,LinkUrl,Description,LinkExpiry,Status")] tpBacklink tpBacklink)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tpBacklink).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tpBacklink);
        }

        // GET: TravelTourBacklinks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tpBacklink tpBacklink = db.tpBacklinks.Find(id);
            if (tpBacklink == null)
            {
                return HttpNotFound();
            }
            return View(tpBacklink);
        }

        // POST: TravelTourBacklinks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tpBacklink tpBacklink = db.tpBacklinks.Find(id);
            db.tpBacklinks.Remove(tpBacklink);
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
