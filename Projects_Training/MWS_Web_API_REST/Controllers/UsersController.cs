using MWS_API_EF.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Cors;

namespace MWS_API_EF.Controllers
{
    [Authorize]
    public class UsersController : ApiController
    {
        private MechanicalWorkshop_Entities db = new MechanicalWorkshop_Entities();

        // GET: api/Users
        public IQueryable<tbl_Users> Gettbl_Users()
        {
            return db.tbl_Users;
        }

        // GET: api/Users/5
        [ResponseType(typeof(tbl_Users))]
        public IHttpActionResult Gettbl_Users(int id)
        {
            tbl_Users tbl_Users = db.tbl_Users.Find(id);
            if (tbl_Users == null)
            {
                return NotFound();
            }

            return Ok(tbl_Users);
        }


        // PUT: api/Users/5
        [Authorize(Roles = "Administrator")]
        [ResponseType(typeof(void))]
        public IHttpActionResult Puttbl_Users(int id, tbl_Users tbl_Users)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbl_Users.Id_User)
            {
                return BadRequest();
            }

            db.Entry(tbl_Users).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_UsersExists(id))
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
        

        // POST: api/Users
        [Authorize(Roles = "Administrator")]
        [ResponseType(typeof(tbl_Users))]
        public IHttpActionResult Posttbl_Users(tbl_Users tbl_Users)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tbl_Users.Add(tbl_Users);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tbl_Users.Id_User }, tbl_Users);
        }

        // DELETE: api/Users/5
        [Authorize(Roles = "Administrator")]
        [ResponseType(typeof(tbl_Users))]
        public IHttpActionResult Deletetbl_Users(int id)
        {
            tbl_Users tbl_Users = db.tbl_Users.Find(id);
            if (tbl_Users == null)
            {
                return NotFound();
            }

            db.tbl_Users.Remove(tbl_Users);
            db.SaveChanges();

            return Ok(tbl_Users);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tbl_UsersExists(int id)
        {
            return db.tbl_Users.Count(e => e.Id_User == id) > 0;
        }
    }
}