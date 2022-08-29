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
    public class TypesController : ApiController
    {
        private TestBDEntities db = new TestBDEntities();

        // GET: api/Types
        [ResponseType(typeof(List<Types>))]
        public IHttpActionResult GetUsers()
        {
            return Ok(db.Type.ToList().ConvertAll(p => new Types(p)));
        }

        // GET: api/Types/5
        [ResponseType(typeof(Entityes.Type))]
        public IHttpActionResult GetType(int id)
        {
            Entityes.Type type = db.Type.Find(id);
            if (type == null)
            {
                return NotFound();
            }

            return Ok(type);
        }

        // PUT: api/Types/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutType(int id, Entityes.Type type)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != type.IdType)
            {
                return BadRequest();
            }

            db.Entry(type).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypeExists(id))
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

        // POST: api/Types
        [ResponseType(typeof(Entityes.Type))]
        public IHttpActionResult PostType(Entityes.Type type)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Type.Add(type);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = type.IdType }, type);
        }

        // DELETE: api/Types/5
        [ResponseType(typeof(Entityes.Type))]
        public IHttpActionResult DeleteType(int id)
        {
            Entityes.Type type = db.Type.Find(id);
            if (type == null)
            {
                return NotFound();
            }

            db.Type.Remove(type);
            db.SaveChanges();

            return Ok(type);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TypeExists(int id)
        {
            return db.Type.Count(e => e.IdType == id) > 0;
        }
    }
}