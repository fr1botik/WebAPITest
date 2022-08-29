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
using WebAPITest.Entityes;
using WebAPITest.Models;

namespace WebAPITest.Controllers
{
    public class LoginsController : ApiController
    {
        private TestBDEntities db = new TestBDEntities();

        // GET: api/Logins
        [ResponseType(typeof(List<Login>))]
        public IHttpActionResult GetUsers()
        {
            return Ok(db.Logins.ToList().ConvertAll(p => new Login(p)));
        }

        // GET: api/Logins/5
        [ResponseType(typeof(Logins))]
        public IHttpActionResult GetLogins(int id)
        {
            Logins logins = db.Logins.Find(id);
            if (logins == null)
            {
                return NotFound();
            }

            return Ok(logins);
        }

        // PUT: api/Logins/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLogins(int id, Logins logins)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != logins.IdUser)
            {
                return BadRequest();
            }

            db.Entry(logins).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoginsExists(id))
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

        // POST: api/Logins
        [ResponseType(typeof(Logins))]
        public IHttpActionResult PostLogins(Logins logins)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Logins.Add(logins);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (LoginsExists(logins.IdUser))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = logins.IdUser }, logins);
        }

        // DELETE: api/Logins/5
        [ResponseType(typeof(Logins))]
        public IHttpActionResult DeleteLogins(int id)
        {
            Logins logins = db.Logins.Find(id);
            if (logins == null)
            {
                return NotFound();
            }

            db.Logins.Remove(logins);
            db.SaveChanges();

            return Ok(logins);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LoginsExists(int id)
        {
            return db.Logins.Count(e => e.IdUser == id) > 0;
        }
    }
}