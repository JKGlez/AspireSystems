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
    public class ServicesProvidedController : ApiController
    {
        private MechanicalWorkshop_Entities db = new MechanicalWorkshop_Entities();

        // GET: api/ServicesProvided
        public IQueryable<tbl_ServicesProvided> Gettbl_ServicesProvided()
        {
            return db.tbl_ServicesProvided;
        }

        // GET: api/ServicesProvided/5
        [ResponseType(typeof(tbl_ServicesProvided))]
        public IHttpActionResult Gettbl_ServicesProvided(int id)
        {
            tbl_ServicesProvided tbl_ServicesProvided = db.tbl_ServicesProvided.Find(id);
            if (tbl_ServicesProvided == null)
            {
                return NotFound();
            }

            return Ok(tbl_ServicesProvided);
        }

        // PUT: api/ServicesProvided/5
        [Authorize(Roles = "Administrator")]
        [ResponseType(typeof(void))]
        public IHttpActionResult Puttbl_ServicesProvided(int id, tbl_ServicesProvided tbl_ServicesProvided)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbl_ServicesProvided.Id_Service)
            {
                return BadRequest();
            }

            db.Entry(tbl_ServicesProvided).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_ServicesProvidedExists(id))
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

        // POST: api/ServicesProvided
        [Authorize(Roles = "Administrator")]
        [ResponseType(typeof(tbl_ServicesProvided))]
        public IHttpActionResult Posttbl_ServicesProvided(tbl_ServicesProvided tbl_ServicesProvided)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tbl_ServicesProvided.Add(tbl_ServicesProvided);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tbl_ServicesProvided.Id_Service }, tbl_ServicesProvided);
        }

        // DELETE: api/ServicesProvided/5
        [ResponseType(typeof(tbl_ServicesProvided))]
        [Authorize(Roles = "Administrator")]
        public IHttpActionResult Deletetbl_ServicesProvided(int id)
        {
            tbl_ServicesProvided tbl_ServicesProvided = db.tbl_ServicesProvided.Find(id);
            if (tbl_ServicesProvided == null)
            {
                return NotFound();
            }

            db.tbl_ServicesProvided.Remove(tbl_ServicesProvided);
            db.SaveChanges();

            return Ok(tbl_ServicesProvided);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tbl_ServicesProvidedExists(int id)
        {
            return db.tbl_ServicesProvided.Count(e => e.Id_Service == id) > 0;
        }
    }
}