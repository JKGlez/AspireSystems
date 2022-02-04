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
    public class ClientsController : Controller
    {
        private Mechanical_WorkshopEntities db = new Mechanical_WorkshopEntities();

        // GET: Clients
        public ActionResult Index()
        {
            return View(db.tbl_Clients.ToList());
        }

        // GET: Clients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Clients tbl_Clients = db.tbl_Clients.Find(id);
            if (tbl_Clients == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Clients);
        }

        // GET: Clients/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Client,Name_Client,NickName_Client,Pay_Day_Client,Mobile_Phone_Client,Email_Client,Billing_Data_Client")] tbl_Clients tbl_Clients)
        {
            if (ModelState.IsValid)
            {
                db.tbl_Clients.Add(tbl_Clients);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_Clients);
        }

        // GET: Clients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Clients tbl_Clients = db.tbl_Clients.Find(id);
            if (tbl_Clients == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Clients);
        }

        // POST: Clients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Client,Name_Client,NickName_Client,Pay_Day_Client,Mobile_Phone_Client,Email_Client,Billing_Data_Client")] tbl_Clients tbl_Clients)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Clients).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_Clients);
        }

        // GET: Clients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Clients tbl_Clients = db.tbl_Clients.Find(id);
            if (tbl_Clients == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Clients);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_Clients tbl_Clients = db.tbl_Clients.Find(id);
            db.tbl_Clients.Remove(tbl_Clients);
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
