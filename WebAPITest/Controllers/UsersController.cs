﻿using System;
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
    public class UsersController : ApiController
    {
        private TestBDEntities db = new TestBDEntities();

        // GET: api/Users
        [ResponseType(typeof(List<User>))]
        public IHttpActionResult GetUsers()
        {
            return Ok(db.Users.ToList().ConvertAll(p=> new User(p)));
        }

        // GET: api/Users/5
        [ResponseType(typeof(Users))]
        public IHttpActionResult GetUsers(int id)
        {
            Users users = db.Users.Find(id);
            if (users == null)
            {
                return NotFound();
            }

            return Ok(users);
        }
        public IHttpActionResult GetUsersSales(int sales)
        {
           
            return Ok(db.Users.ToList().Where(w=>w.Sale == sales));

        }

        // PUT: api/Users/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUsers(int id, Users users)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != users.IdUser)
            {
                return BadRequest();
            }

            db.Entry(users).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsersExists(id))
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
        [ResponseType(typeof(Users))]
        public IHttpActionResult PostUsers(Users users)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Users.Add(users);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = users.IdUser }, users);
        }

        // DELETE: api/Users/5
        [ResponseType(typeof(Users))]
        public IHttpActionResult DeleteUsers(int id)
        {
            Users users = db.Users.Find(id);
            if (users == null)
            {
                return NotFound();
            }

            db.Users.Remove(users);
            db.SaveChanges();

            return Ok(users);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UsersExists(int id)
        {
            return db.Users.Count(e => e.IdUser == id) > 0;
        }
    }
}