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
    public class FlightDetailsController : Controller
    {
        private MIS4200Context db = new MIS4200Context();

        // GET: FlightDetails
        public ActionResult Index()
        {
            var flightDetail = db.FlightDetail.Include(f => f.Airplane).Include(f => f.Flight);
            return View(flightDetail.ToList());
        }

        // GET: FlightDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FlightDetail flightDetail = db.FlightDetail.Find(id);
            if (flightDetail == null)
            {
                return HttpNotFound();
            }
            return View(flightDetail);
        }

        // GET: FlightDetails/Create
        public ActionResult Create()
        {
            ViewBag.airplaneID = new SelectList(db.Airplane, "airplaneID", "Description");
            ViewBag.flightID = new SelectList(db.Flight, "flightID", "description");
            return View();
        }

        // POST: FlightDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "flightdetailID,price,flightID,airplaneID")] FlightDetail flightDetail)
        {
            if (ModelState.IsValid)
            {
                db.FlightDetail.Add(flightDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.airplaneID = new SelectList(db.Airplane, "airplaneID", "Description", flightDetail.airplaneID);
            ViewBag.flightID = new SelectList(db.Flight, "flightID", "description", flightDetail.flightID);
            return View(flightDetail);
        }

        // GET: FlightDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FlightDetail flightDetail = db.FlightDetail.Find(id);
            if (flightDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.airplaneID = new SelectList(db.Airplane, "airplaneID", "Description", flightDetail.airplaneID);
            ViewBag.flightID = new SelectList(db.Flight, "flightID", "description", flightDetail.flightID);
            return View(flightDetail);
        }

        // POST: FlightDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "flightdetailID,price,flightID,airplaneID")] FlightDetail flightDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(flightDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.airplaneID = new SelectList(db.Airplane, "airplaneID", "Description", flightDetail.airplaneID);
            ViewBag.flightID = new SelectList(db.Flight, "flightID", "description", flightDetail.flightID);
            return View(flightDetail);
        }

        // GET: FlightDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FlightDetail flightDetail = db.FlightDetail.Find(id);
            if (flightDetail == null)
            {
                return HttpNotFound();
            }
            return View(flightDetail);
        }

        // POST: FlightDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FlightDetail flightDetail = db.FlightDetail.Find(id);
            db.FlightDetail.Remove(flightDetail);
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
