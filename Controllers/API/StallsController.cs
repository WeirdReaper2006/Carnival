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
    public class StallsController : ApiController
    {
        private CarnivalContext db = new CarnivalContext();

        // GET: api/Stalls
        [HttpGet, Route("api/Stalls/Index")]
        public async Task<IHttpActionResult> GetStalls()
        {
            var StallList = await db.Stalls.ToListAsync();
            return Json(new { StallList });
        }

        // GET: api/Stalls/5
        [ResponseType(typeof(Stall))]
        public async Task<IHttpActionResult> GetStall(int id)
        {
            Stall stall = await db.Stalls.FindAsync(id);
            if (stall == null)
            {
                return NotFound();
            }

            return Ok(stall);
        }

        // PUT: api/Stalls/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutStall(int id, Stall stall)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != stall.StallID)
            {
                return BadRequest();
            }

            db.Entry(stall).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StallExists(id))
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

        // POST: api/Stalls
        //[ResponseType(typeof(Stall))]
        [HttpPost, Route("api/Stalls/PostStall")]
        public async Task<IHttpActionResult> PostStall([FromBody]Stall stall)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Stalls.Add(stall);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = stall.StallID }, stall);
        }

        // DELETE: api/Stalls/5
        [ResponseType(typeof(Stall))]
        public async Task<IHttpActionResult> DeleteStall(int id)
        {
            Stall stall = await db.Stalls.FindAsync(id);
            if (stall == null)
            {
                return NotFound();
            }

            db.Stalls.Remove(stall);
            await db.SaveChangesAsync();

            return Ok(stall);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StallExists(int id)
        {
            return db.Stalls.Count(e => e.StallID == id) > 0;
        }
    }
}