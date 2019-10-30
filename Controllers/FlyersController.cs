using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EA446115_MIS4200.DAL;
using EA446115_MIS4200.Models;

namespace EA446115_MIS4200.Controllers
{
    public class FlyersController : Controller
    {
        private MIS4200Context db = new MIS4200Context();

        // GET: Flyers
        public ActionResult Index()
        {
            return View(db.Flyer.ToList());
        }

        // GET: Flyers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flyer flyer = db.Flyer.Find(id);
            if (flyer == null)
            {
                return HttpNotFound();
            }
            return View(flyer);
        }

        // GET: Flyers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Flyers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "flyerID,firstName,lastName,email,phone,flyerSince")] Flyer flyer)
        {
            if (ModelState.IsValid)
            {
                db.Flyer.Add(flyer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(flyer);
        }

        // GET: Flyers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flyer flyer = db.Flyer.Find(id);
            if (flyer == null)
            {
                return HttpNotFound();
            }
            return View(flyer);
        }

        // POST: Flyers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "flyerID,firstName,lastName,email,phone,flyerSince")] Flyer flyer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(flyer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(flyer);
        }

        // GET: Flyers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flyer flyer = db.Flyer.Find(id);
            if (flyer == null)
            {
                return HttpNotFound();
            }
            return View(flyer);
        }

        // POST: Flyers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Flyer flyer = db.Flyer.Find(id);
            db.Flyer.Remove(flyer);
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
