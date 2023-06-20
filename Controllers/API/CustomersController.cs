using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Carnival.Models;

namespace Carnival.Controllers.API
{
    public class CustomersController : ApiController
    {
        private CarnivalContext db = new CarnivalContext();

        // GET: api/Customers
        [HttpGet,Route("api/Customer/Index")]
        public async Task<IHttpActionResult> GetCustomers()
        {
            var customerlist = await db.Customers.ToListAsync();
            return Json (new {customerlist});
        }

        // GET: api/Customers/5
        [ResponseType(typeof(Customer))]
        [HttpGet,Route("api/Customer/Index/{id}")]
        public async Task<IHttpActionResult> GetCustomer([FromUri]int id)
        {
            Customer customer = await db.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        // PUT: api/Customers/5
        [ResponseType(typeof(void))]
        [HttpPut,Route("api/Customers/PutCustomer/{id}")]
        public async Task<IHttpActionResult> PutCustomer([FromUri]int id, [FromBody]Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != customer.CustomerID)
            {
                return BadRequest();
            }

            db.Entry(customer).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Json(new { success = "Your Data has been Edited" });
        }

        // POST: api/Customers
        [ResponseType(typeof(Customer))]
        public async Task<IHttpActionResult> PostCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Customers.Add(customer);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = customer.CustomerID }, customer);
        }

        // DELETE: api/Customers/5
        [ResponseType(typeof(Customer))]
        [HttpDelete, Route("api/Customers/DeleteCustomer/{id}")]
        public async Task<IHttpActionResult> DeleteCustomer([FromUri]int id)
        {
            Customer customer = await db.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            db.Customers.Remove(customer);
            await db.SaveChangesAsync();

            return Json(new {success="Your Data has been Deleted"});
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CustomerExists(int id)
        {
            return db.Customers.Count(e => e.CustomerID == id) > 0;
        }
    }
}