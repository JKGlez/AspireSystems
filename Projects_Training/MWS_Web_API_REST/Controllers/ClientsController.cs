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
    public class ClientsController : ApiController
    {
        private MechanicalWorkshop_Entities db = new MechanicalWorkshop_Entities();

        
        // GET: api/Clients
        public IQueryable<tbl_Clients> Gettbl_Clients()
        {
            return db.tbl_Clients;
        }

        
        // GET: api/Clients/5
        [ResponseType(typeof(tbl_Clients))]
        public IHttpActionResult Gettbl_Clients(int id)
        {
            tbl_Clients tbl_Clients = db.tbl_Clients.Find(id);
            if (tbl_Clients == null)
            {
                return NotFound();
            }

            return Ok(tbl_Clients);
        }


        // PUT: api/Clients/5
        [Authorize(Roles = "Administrator")]
        [ResponseType(typeof(void))]
        public IHttpActionResult Puttbl_Clients(int id, tbl_Clients tbl_Clients)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbl_Clients.Id_Client)
            {
                return BadRequest();
            }

            db.Entry(tbl_Clients).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_ClientsExists(id))
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


        // POST: api/Clients
        [Authorize(Roles = "Administrator")]
        [ResponseType(typeof(tbl_Clients))]
        public IHttpActionResult Posttbl_Clients([FromBody] tbl_Clients tbl_Clients)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //
            db.tbl_Clients.Add(tbl_Clients);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tbl_Clients.Id_Client }, tbl_Clients);
        }

        // DELETE: api/Clients/5
        [Authorize(Roles = "Administrator")]
        [ResponseType(typeof(tbl_Clients))]
        public IHttpActionResult Deletetbl_Clients(int id)
        {
            tbl_Clients tbl_Clients = db.tbl_Clients.Find(id);
            if (tbl_Clients == null)
            {
                return NotFound();
            }

            db.tbl_Clients.Remove(tbl_Clients);
            db.SaveChanges();

            return Ok(tbl_Clients);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tbl_ClientsExists(int id)
        {
            return db.tbl_Clients.Count(e => e.Id_Client == id) > 0;
        }
    }
}