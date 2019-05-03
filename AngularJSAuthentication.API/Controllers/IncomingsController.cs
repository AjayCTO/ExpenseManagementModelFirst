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
using AngularJSAuthentication.API;
using AngularJSAuthentication.API.Models;

namespace AngularJSAuthentication.API.Controllers
{
     [RoutePrefix("api/Incomings")]
    public class IncomingsController : ApiController
    {
        private AuthContext db = new AuthContext();

        // GET: api/Incomings
        public List<Incoming> GetIncomings()
        {
            return db.Incomings.ToList();
        }

        // GET: api/Incomings/5
        [ResponseType(typeof(Incoming))]
        public IHttpActionResult GetIncoming(short id)
        {
            Incoming incoming = db.Incomings.Find(id);
            if (incoming == null)
            {
                return NotFound();
            }

            return Ok(incoming);
        }


        [HttpGet]
        [Route("GetIncomingByProjectID")]
        [ActionName("GetIncomingByProjectID")]
        public List<IncomingModal> GetIncomingByProjectID(short id)
        {
            List<IncomingModal> incomings = new List<IncomingModal>();
            var listOfIncoming =  db.Incomings.Where(x => x.ProjectID == id).ToList();

            foreach (Incoming income in listOfIncoming)
            {
                IncomingModal singleIncome = new IncomingModal();

                singleIncome.projectID = income.ProjectID;
                singleIncome.projectName = income.Project.Name;
                singleIncome.sourceName = income.SourceName;
                singleIncome.amount = income.Amount;
                singleIncome.date = income.Date;
                singleIncome.incomingID = income.IncomingID;
                singleIncome.receiptPath = income.receiptPath;



                incomings.Add(singleIncome);
            }


            return incomings;
        }




        // PUT: api/Incomings/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutIncoming(Incoming incoming)
        {
            var id = incoming.IncomingID;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != incoming.IncomingID)
            {
                return BadRequest();
            }

            db.Entry(incoming).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IncomingExists(id))
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

        // POST: api/Incomings
        [ResponseType(typeof(Incoming))]
        public IHttpActionResult PostIncoming(Incoming incoming)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}


            db.Incomings.Add(incoming);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = incoming.IncomingID }, incoming);
        }

        // DELETE: api/Incomings/5
        [ResponseType(typeof(Incoming))]
        public IHttpActionResult DeleteIncoming(short id)
        {
            Incoming incoming = db.Incomings.Find(id);
            if (incoming == null)
            {
                return NotFound();
            }

            db.Incomings.Remove(incoming);
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
            return db.Incomings.Count(e => e.IncomingID == id) > 0;
        }
    }
}