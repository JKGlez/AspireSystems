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
    public class VehiclesController : ApiController
    {
        private MechanicalWorkshop_Entities db = new MechanicalWorkshop_Entities();

        // GET: api/Vehicles
        public IQueryable<tbl_Vehicles> Gettbl_Vehicles()
        {
            return db.tbl_Vehicles;
        }

        // GET: api/Vehicles/5
        [ResponseType(typeof(tbl_Vehicles))]
        public IHttpActionResult Gettbl_Vehicles(int id)
        {
            tbl_Vehicles tbl_Vehicles = db.tbl_Vehicles.Find(id);
            if (tbl_Vehicles == null)
            {
                return NotFound();
            }

            return Ok(tbl_Vehicles);
        }

        // PUT: api/Vehicles/5
        [Authorize(Roles = "Administrator")]
        [ResponseType(typeof(void))]
        public IHttpActionResult Puttbl_Vehicles(int id, tbl_Vehicles tbl_Vehicles)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbl_Vehicles.Id_Vehicle)
            {
                return BadRequest();
            }

            db.Entry(tbl_Vehicles).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_VehiclesExists(id))
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

        // POST: api/Vehicles
        [Authorize(Roles = "Administrator")]

        [ResponseType(typeof(tbl_Vehicles))]
        public IHttpActionResult Posttbl_Vehicles(tbl_Vehicles tbl_Vehicles)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tbl_Vehicles.Add(tbl_Vehicles);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tbl_Vehicles.Id_Vehicle }, tbl_Vehicles);
        }

        // DELETE: api/Vehicles/5
        [Authorize(Roles = "Administrator")]

        [ResponseType(typeof(tbl_Vehicles))]
        public IHttpActionResult Deletetbl_Vehicles(int id)
        {
            tbl_Vehicles tbl_Vehicles = db.tbl_Vehicles.Find(id);
            if (tbl_Vehicles == null)
            {
                return NotFound();
            }

            db.tbl_Vehicles.Remove(tbl_Vehicles);
            db.SaveChanges();

            return Ok(tbl_Vehicles);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tbl_VehiclesExists(int id)
        {
            return db.tbl_Vehicles.Count(e => e.Id_Vehicle == id) > 0;
        }
    }
}