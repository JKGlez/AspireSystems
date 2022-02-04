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
    public class ServicesProvidedController : Controller
    {
        private Mechanical_WorkshopEntities db = new Mechanical_WorkshopEntities();

        // GET: ServicesProvided
        public ActionResult Index()
        {
            var tbl_ServicesProvided = db.tbl_ServicesProvided.Include(t => t.tbl_WorkOrders);
            return View(tbl_ServicesProvided.ToList());
        }

        // GET: ServicesProvided/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_ServicesProvided tbl_ServicesProvided = db.tbl_ServicesProvided.Find(id);
            if (tbl_ServicesProvided == null)
            {
                return HttpNotFound();
            }
            return View(tbl_ServicesProvided);
        }

        // GET: ServicesProvided/Create
        public ActionResult Create()
        {
            ViewBag.Id_WorkOrder_Service = new SelectList(db.tbl_WorkOrders, "Id_WorkOrder", "Observation_WorkOrder");
            return View();
        }

        // POST: ServicesProvided/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Service,Id_WorkOrder_Service,Description_Service,Observation_Service,EstimatedCost_Service,ExtraExpenses_Service,ExtraExpensesDescription_Service,FinalCost_Service")] tbl_ServicesProvided tbl_ServicesProvided)
        {
            if (ModelState.IsValid)
            {
                db.tbl_ServicesProvided.Add(tbl_ServicesProvided);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_WorkOrder_Service = new SelectList(db.tbl_WorkOrders, "Id_WorkOrder", "Observation_WorkOrder", tbl_ServicesProvided.Id_WorkOrder_Service);
            return View(tbl_ServicesProvided);
        }

        // GET: ServicesProvided/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_ServicesProvided tbl_ServicesProvided = db.tbl_ServicesProvided.Find(id);
            if (tbl_ServicesProvided == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_WorkOrder_Service = new SelectList(db.tbl_WorkOrders, "Id_WorkOrder", "Observation_WorkOrder", tbl_ServicesProvided.Id_WorkOrder_Service);
            return View(tbl_ServicesProvided);
        }

        // POST: ServicesProvided/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Service,Id_WorkOrder_Service,Description_Service,Observation_Service,EstimatedCost_Service,ExtraExpenses_Service,ExtraExpensesDescription_Service,FinalCost_Service")] tbl_ServicesProvided tbl_ServicesProvided)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_ServicesProvided).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_WorkOrder_Service = new SelectList(db.tbl_WorkOrders, "Id_WorkOrder", "Observation_WorkOrder", tbl_ServicesProvided.Id_WorkOrder_Service);
            return View(tbl_ServicesProvided);
        }

        // GET: ServicesProvided/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_ServicesProvided tbl_ServicesProvided = db.tbl_ServicesProvided.Find(id);
            if (tbl_ServicesProvided == null)
            {
                return HttpNotFound();
            }
            return View(tbl_ServicesProvided);
        }

        // POST: ServicesProvided/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_ServicesProvided tbl_ServicesProvided = db.tbl_ServicesProvided.Find(id);
            db.tbl_ServicesProvided.Remove(tbl_ServicesProvided);
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
