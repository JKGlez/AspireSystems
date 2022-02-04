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
    public class WorkOrdersController : Controller
    {
        private Mechanical_WorkshopEntities db = new Mechanical_WorkshopEntities();

        // GET: WorkOrders
        public ActionResult Index()
        {
            var tbl_WorkOrders = db.tbl_WorkOrders.Include(t => t.tbl_Clients).Include(t => t.tbl_Vehicles);
            return View(tbl_WorkOrders.ToList());
        }

        // GET: WorkOrders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_WorkOrders tbl_WorkOrders = db.tbl_WorkOrders.Find(id);
            if (tbl_WorkOrders == null)
            {
                return HttpNotFound();
            }
            return View(tbl_WorkOrders);
        }

        // GET: WorkOrders/Create
        public ActionResult Create()
        {
            ViewBag.Client_WorkOrder = new SelectList(db.tbl_Clients, "Id_Client", "Name_Client");
            ViewBag.Vehicle_WorkOrder = new SelectList(db.tbl_Vehicles, "Id_Vehicle", "Brand_Vehicle");
            return View();
        }

        // POST: WorkOrders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_WorkOrder,Client_WorkOrder,Vehicle_WorkOrder,StartDate_WorkOrder,FinishDate_WorkOrder,Observation_WorkOrder,FinalCost_WorkOrder,Status_WorkOrder")] tbl_WorkOrders tbl_WorkOrders)
        {
            if (ModelState.IsValid)
            {
                db.tbl_WorkOrders.Add(tbl_WorkOrders);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Client_WorkOrder = new SelectList(db.tbl_Clients, "Id_Client", "Name_Client", tbl_WorkOrders.Client_WorkOrder);
            ViewBag.Vehicle_WorkOrder = new SelectList(db.tbl_Vehicles, "Id_Vehicle", "Brand_Vehicle", tbl_WorkOrders.Vehicle_WorkOrder);
            return View(tbl_WorkOrders);
        }

        // GET: WorkOrders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_WorkOrders tbl_WorkOrders = db.tbl_WorkOrders.Find(id);
            if (tbl_WorkOrders == null)
            {
                return HttpNotFound();
            }
            ViewBag.Client_WorkOrder = new SelectList(db.tbl_Clients, "Id_Client", "Name_Client", tbl_WorkOrders.Client_WorkOrder);
            ViewBag.Vehicle_WorkOrder = new SelectList(db.tbl_Vehicles, "Id_Vehicle", "Brand_Vehicle", tbl_WorkOrders.Vehicle_WorkOrder);
            return View(tbl_WorkOrders);
        }

        // POST: WorkOrders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_WorkOrder,Client_WorkOrder,Vehicle_WorkOrder,StartDate_WorkOrder,FinishDate_WorkOrder,Observation_WorkOrder,FinalCost_WorkOrder,Status_WorkOrder")] tbl_WorkOrders tbl_WorkOrders)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_WorkOrders).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Client_WorkOrder = new SelectList(db.tbl_Clients, "Id_Client", "Name_Client", tbl_WorkOrders.Client_WorkOrder);
            ViewBag.Vehicle_WorkOrder = new SelectList(db.tbl_Vehicles, "Id_Vehicle", "Brand_Vehicle", tbl_WorkOrders.Vehicle_WorkOrder);
            return View(tbl_WorkOrders);
        }

        // GET: WorkOrders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_WorkOrders tbl_WorkOrders = db.tbl_WorkOrders.Find(id);
            if (tbl_WorkOrders == null)
            {
                return HttpNotFound();
            }
            return View(tbl_WorkOrders);
        }

        // POST: WorkOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_WorkOrders tbl_WorkOrders = db.tbl_WorkOrders.Find(id);
            db.tbl_WorkOrders.Remove(tbl_WorkOrders);
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
