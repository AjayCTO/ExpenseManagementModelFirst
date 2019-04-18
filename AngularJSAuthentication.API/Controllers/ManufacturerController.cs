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
    [RoutePrefix("api/Manufacturer")]
    public class ManufacturerController : ApiController
    {
        private AuthContext db = new AuthContext();

        // GET api/Manufacturer
        [Authorize]
        [Route("")]
        public IQueryable<Manufacturer> GetManufacturers()
        {
            return db.Manufacturers;
        }

        // GET api/Manufacturer/5
        [Route("")]
        [ResponseType(typeof(Manufacturer))]
        public IHttpActionResult GetManufacturer(int id)
        {
            Manufacturer manufacturer = db.Manufacturers.Find(id);
            if (manufacturer == null)
            {
                return NotFound();
            }

            return Ok(manufacturer);
        }

        // PUT api/Manufacturer/5
        [Route("PutManufacturer")]
        public IHttpActionResult PutManufacturer(Manufacturer manufacturer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //if (id != manufacturer.ManufacturerID)
            //{
            //    return BadRequest();
            //}

            db.Entry(manufacturer).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!ManufacturerExists(id))
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

        // POST api/Manufacturer
        [ResponseType(typeof(Manufacturer))]
        [Route("PostManufacturer")]
        public IHttpActionResult PostManufacturer(Manufacturer manufacturer)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            db.Manufacturers.Add(manufacturer);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = manufacturer.ManufacturerID }, manufacturer);
        }

        // DELETE api/Manufacturer/5
        [ResponseType(typeof(Manufacturer))]
        [Route("DeleteManufacturer")]
        public IHttpActionResult DeleteManufacturer(int id)
        {
            Manufacturer manufacturer = db.Manufacturers.Find(id);
            if (manufacturer == null)
            {
                return NotFound();
            }

            db.Manufacturers.Remove(manufacturer);
            db.SaveChanges();

            return Ok(manufacturer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ManufacturerExists(int id)
        {
            return db.Manufacturers.Count(e => e.ManufacturerID == id) > 0;
        }
    }
}