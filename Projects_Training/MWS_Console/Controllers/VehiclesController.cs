using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MechanicalWorkshop.Models;

namespace MechanicalWorkshop.Controllers
{
    public class VehiclesController : Controller
    {
        private Mechanical_WorkshopEntities db = new Mechanical_WorkshopEntities();

        // GET: Vehicles
        public ActionResult Index()
        {
            var tbl_Vehicles = db.tbl_Vehicles.Include(t => t.tbl_Clients);
            return View(tbl_Vehicles.ToList());
        }

        // GET: Vehicles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Vehicles tbl_Vehicles = db.tbl_Vehicles.Find(id);
            if (tbl_Vehicles == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Vehicles);
        }

        // GET: Vehicles/Create
        public ActionResult Create()
        {
            ViewBag.Owner_Vehicle = new SelectList(db.tbl_Clients, "Id_Client", "Name_Client");
            return View();
        }

        // POST: Vehicles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Vehicle,Brand_Vehicle,Model_Vehicle,NickName_Vehicle,Economic_Number_Vehicle,Owner_Vehicle")] tbl_Vehicles tbl_Vehicles)
        {
            if (ModelState.IsValid)
            {
                db.tbl_Vehicles.Add(tbl_Vehicles);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Owner_Vehicle = new SelectList(db.tbl_Clients, "Id_Client", "Name_Client", tbl_Vehicles.Owner_Vehicle);
            return View(tbl_Vehicles);
        }

        // GET: Vehicles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Vehicles tbl_Vehicles = db.tbl_Vehicles.Find(id);
            if (tbl_Vehicles == null)
            {
                return HttpNotFound();
            }
            ViewBag.Owner_Vehicle = new SelectList(db.tbl_Clients, "Id_Client", "Name_Client", tbl_Vehicles.Owner_Vehicle);
            return View(tbl_Vehicles);
        }

        // POST: Vehicles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Vehicle,Brand_Vehicle,Model_Vehicle,NickName_Vehicle,Economic_Number_Vehicle,Owner_Vehicle")] tbl_Vehicles tbl_Vehicles)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Vehicles).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Owner_Vehicle = new SelectList(db.tbl_Clients, "Id_Client", "Name_Client", tbl_Vehicles.Owner_Vehicle);
            return View(tbl_Vehicles);
        }

        // GET: Vehicles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Vehicles tbl_Vehicles = db.tbl_Vehicles.Find(id);
            if (tbl_Vehicles == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Vehicles);
        }

        // POST: Vehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_Vehicles tbl_Vehicles = db.tbl_Vehicles.Find(id);
            db.tbl_Vehicles.Remove(tbl_Vehicles);
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
