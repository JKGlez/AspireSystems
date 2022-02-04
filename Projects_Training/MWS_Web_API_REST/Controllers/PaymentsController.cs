using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using MWS_API_EF.Models;
using System.Web.Http.Cors;

namespace MWS_API_EF.Controllers
{
    [Authorize]
    public class PaymentsController : ApiController
    {
        private MechanicalWorkshop_Entities db = new MechanicalWorkshop_Entities();

        // GET: api/Payments
        public IQueryable<tbl_Payments> Gettbl_Payments()
        {
            return db.tbl_Payments;
        }

        // GET: api/Payments/5
        [ResponseType(typeof(tbl_Payments))]
        public IHttpActionResult Gettbl_Payments(int id)
        {
            tbl_Payments tbl_Payments = db.tbl_Payments.Find(id);
            if (tbl_Payments == null)
            {
                return NotFound();
            }

            return Ok(tbl_Payments);
        }

        // PUT: api/Payments/5
        [Authorize(Roles = "Administrator")]
        [ResponseType(typeof(void))]
        public IHttpActionResult Puttbl_Payments(int id, tbl_Payments tbl_Payments)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbl_Payments.Id_Payment)
            {
                return BadRequest();
            }

            db.Entry(tbl_Payments).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_PaymentsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Payments
        [Authorize(Roles = "Administrator")]
        [ResponseType(typeof(tbl_Payments))]
        public IHttpActionResult Posttbl_Payments(tbl_Payments tbl_Payments)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tbl_Payments.Add(tbl_Payments);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tbl_Payments.Id_Payment }, tbl_Payments);
        }

        // DELETE: api/Payments/5
        [Authorize(Roles = "Administrator")]
        [ResponseType(typeof(tbl_Payments))]
        public IHttpActionResult Deletetbl_Payments(int id)
        {
            tbl_Payments tbl_Payments = db.tbl_Payments.Find(id);
            if (tbl_Payments == null)
            {
                return NotFound();
            }

            db.tbl_Payments.Remove(tbl_Payments);
            db.SaveChanges();

            return Ok(tbl_Payments);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tbl_PaymentsExists(int id)
        {
            return db.tbl_Payments.Count(e => e.Id_Payment == id) > 0;
        }
    }
}