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
    public class SalesController : ApiController
    {
        private TestBDEntities db = new TestBDEntities();

        // GET: api/Sales
        [ResponseType(typeof(List<Sale>))]
        public IHttpActionResult GetUsers()
        {
            return Ok(db.Sales.ToList().ConvertAll(p => new Sale(p)));
        }

        // GET: api/Sales/5
        [ResponseType(typeof(Sales))]
        public IHttpActionResult GetSales(int id)
        {
            Sales sales = db.Sales.Find(id);
            if (sales == null)
            {
                return NotFound();
            }

            return Ok(sales);
        }

        // PUT: api/Sales/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSales(int id, Sales sales)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sales.IdSale)
            {
                return BadRequest();
            }

            db.Entry(sales).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalesExists(id))
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

        // POST: api/Sales
        [ResponseType(typeof(Sales))]
        public IHttpActionResult PostSales(Sales sales)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Sales.Add(sales);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = sales.IdSale }, sales);
        }

        // DELETE: api/Sales/5
        [ResponseType(typeof(Sales))]
        public IHttpActionResult DeleteSales(int id)
        {
            Sales sales = db.Sales.Find(id);
            if (sales == null)
            {
                return NotFound();
            }

            db.Sales.Remove(sales);
            db.SaveChanges();

            return Ok(sales);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SalesExists(int id)
        {
            return db.Sales.Count(e => e.IdSale == id) > 0;
        }
    }
}