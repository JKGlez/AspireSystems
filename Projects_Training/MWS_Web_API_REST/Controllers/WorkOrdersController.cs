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
    public class WorkOrdersController : ApiController
    {
        private MechanicalWorkshop_Entities db = new MechanicalWorkshop_Entities();

        // GET: api/WorkOrders
        public IQueryable<tbl_WorkOrders> Gettbl_WorkOrders()
        {
            return db.tbl_WorkOrders;
        }

        // GET: api/WorkOrders/5
        [ResponseType(typeof(tbl_WorkOrders))]
        public IHttpActionResult Gettbl_WorkOrders(int id)
        {
            tbl_WorkOrders tbl_WorkOrders = db.tbl_WorkOrders.Find(id);
            if (tbl_WorkOrders == null)
            {
                return NotFound();
            }

            return Ok(tbl_WorkOrders);
        }

        // PUT: api/WorkOrders/5
        [Authorize(Roles = "Administrator")]
        [ResponseType(typeof(void))]
        public IHttpActionResult Puttbl_WorkOrders(int id, tbl_WorkOrders tbl_WorkOrders)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbl_WorkOrders.Id_WorkOrder)
            {
                return BadRequest();
            }

            db.Entry(tbl_WorkOrders).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_WorkOrdersExists(id))
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

        // POST: api/WorkOrders
        [Authorize(Roles = "Administrator")]
        [ResponseType(typeof(tbl_WorkOrders))]
        public IHttpActionResult Posttbl_WorkOrders(tbl_WorkOrders tbl_WorkOrders)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tbl_WorkOrders.Add(tbl_WorkOrders);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tbl_WorkOrders.Id_WorkOrder }, tbl_WorkOrders);
        }

        // DELETE: api/WorkOrders/5
        [Authorize(Roles = "Administrator")]
        [ResponseType(typeof(tbl_WorkOrders))]
        public IHttpActionResult Deletetbl_WorkOrders(int id)
        {
            tbl_WorkOrders tbl_WorkOrders = db.tbl_WorkOrders.Find(id);
            if (tbl_WorkOrders == null)
            {
                return NotFound();
            }

            db.tbl_WorkOrders.Remove(tbl_WorkOrders);
            db.SaveChanges();

            return Ok(tbl_WorkOrders);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tbl_WorkOrdersExists(int id)
        {
            return db.tbl_WorkOrders.Count(e => e.Id_WorkOrder == id) > 0;
        }
    }
}