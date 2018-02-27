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
    public class TravelTourTagsController : Controller
    {
        private TravelDBContainer db = new TravelDBContainer();

        // GET: TravelTourTags

        public ActionResult Index()
        {
            var tpKeywords = db.tpKeywords.Include(t => t.tpProduct);
            return View(tpKeywords.ToList());
        }

        // GET: TravelTourTags/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tpKeyword tpKeyword = db.tpKeywords.Find(id);
            if (tpKeyword == null)
            {
                return HttpNotFound();
            }
            return View(tpKeyword);
        }

        // GET: TravelTourTags/Create
        public ActionResult Create()
        {
            ViewBag.tpProductsId = new SelectList(db.tpProducts, "Id", "Name");
            return View();
        }

        // POST: TravelTourTags/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Keyword,tpProductsId")] tpKeyword tpKeyword)
        {
            if (ModelState.IsValid)
            {
                db.tpKeywords.Add(tpKeyword);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.tpProductsId = new SelectList(db.tpProducts, "Id", "Name", tpKeyword.tpProductsId);
            return View(tpKeyword);
        }

        // GET: TravelTourTags/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tpKeyword tpKeyword = db.tpKeywords.Find(id);
            if (tpKeyword == null)
            {
                return HttpNotFound();
            }
            ViewBag.tpProductsId = new SelectList(db.tpProducts, "Id", "Name", tpKeyword.tpProductsId);
            return View(tpKeyword);
        }

        // POST: TravelTourTags/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Keyword,tpProductsId")] tpKeyword tpKeyword)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tpKeyword).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.tpProductsId = new SelectList(db.tpProducts, "Id", "Name", tpKeyword.tpProductsId);
            return View(tpKeyword);
        }

        // GET: TravelTourTags/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tpKeyword tpKeyword = db.tpKeywords.Find(id);
            if (tpKeyword == null)
            {
                return HttpNotFound();
            }
            return View(tpKeyword);
        }

        // POST: TravelTourTags/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tpKeyword tpKeyword = db.tpKeywords.Find(id);
            db.tpKeywords.Remove(tpKeyword);
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
