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
using AngularJSAuthentication.API.Models;
using AngularJSAuthentication.API;

namespace AngularJSAuthentication.API.Controllers
{
      [RoutePrefix("api/Incoming")]
    public class IncomingController : ApiController
    {
        private AuthContext db = new AuthContext();

        // GET api/Incoming
        [Authorize]
        [Route("")]
        public IQueryable<Incoming> GetIncoming()
        {
            return db.Incoming;
        }

        // GET api/Incoming/5
        [ResponseType(typeof(Incoming))]
        [Route("GetIncoming")]
        public IHttpActionResult GetIncoming(short id)
        {
            Incoming incoming = db.Incoming.Find(id);
            if (incoming == null)
            {
                return NotFound();
            }

            return Ok(incoming);
        }

        // PUT api/Incoming/5
            [Route("PutIncoming")]
        public IHttpActionResult PutIncoming(Incoming incoming)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //if (id != incoming.IncomeID)
            //{
            //    return BadRequest();
            //}

            db.Entry(incoming).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!IncomingExists(id))
                //{
                //    return NotFound();
                //}
                //else
                //{
                //    throw;
                //}
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/Incoming
        [ResponseType(typeof(Incoming))]
        [Route("PostIncoming")]
        public IHttpActionResult PostIncoming(Incoming incoming)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Incoming.Add(incoming);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = incoming.IncomeID }, incoming);
        }

        // DELETE api/Incoming/5
        [ResponseType(typeof(Incoming))]
        [Route("DeleteIncoming")]
        public IHttpActionResult DeleteIncoming(short id)
        {
            Incoming incoming = db.Incoming.Find(id);
            if (incoming == null)
            {
                return NotFound();
            }

            db.Incoming.Remove(incoming);
            db.SaveChanges();

            return Ok(incoming);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool IncomingExists(short id)
        {
            return db.Incoming.Count(e => e.IncomeID == id) > 0;
        }
    }
}