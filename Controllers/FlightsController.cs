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
    public class FlightsController : Controller
    {
        private MIS4200Context db = new MIS4200Context();

        // GET: Flights
        public ActionResult Index()
        {
            var flight = db.Flight.Include(f => f.Flyer);
            return View(flight.ToList());
        }

        // GET: Flights/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flight flight = db.Flight.Find(id);
            if (flight == null)
            {
                return HttpNotFound();
            }
            return View(flight);
        }

        // GET: Flights/Create
        public ActionResult Create()
        {
            ViewBag.flyerID = new SelectList(db.Flyer, "flyerID", "firstName");
            return View();
        }

        // POST: Flights/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "flightID,description,flightDate,flyerID,airlineID")] Flight flight)
        {
            if (ModelState.IsValid)
            {
                db.Flight.Add(flight);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.flyerID = new SelectList(db.Flyer, "flyerID", "firstName", flight.flyerID);
            return View(flight);
        }

        // GET: Flights/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flight flight = db.Flight.Find(id);
            if (flight == null)
            {
                return HttpNotFound();
            }
            ViewBag.flyerID = new SelectList(db.Flyer, "flyerID", "firstName", flight.flyerID);
            return View(flight);
        }

        // POST: Flights/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "flightID,description,flightDate,flyerID,airlineID")] Flight flight)
        {
            if (ModelState.IsValid)
            {
                db.Entry(flight).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.flyerID = new SelectList(db.Flyer, "flyerID", "firstName", flight.flyerID);
            return View(flight);
        }

        // GET: Flights/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flight flight = db.Flight.Find(id);
            if (flight == null)
            {
                return HttpNotFound();
            }
            return View(flight);
        }

        // POST: Flights/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Flight flight = db.Flight.Find(id);
            db.Flight.Remove(flight);
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
