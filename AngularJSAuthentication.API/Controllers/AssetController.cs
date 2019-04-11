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
    public class AssetController : ApiController
    {
        private AuthContext db = new AuthContext();

        // GET api/Asset
        public IQueryable<Asset> GetAsset()
        {
            return db.Asset;
        }

        // GET api/Asset/5
        [ResponseType(typeof(Asset))]
        public IHttpActionResult GetAsset(short id)
        {
            Asset asset = db.Asset.Find(id);
            if (asset == null)
            {
                return NotFound();
            }

            return Ok(asset);
        }

        // PUT api/Asset/5
        public IHttpActionResult PutAsset(short id, Asset asset)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != asset.AssetID)
            {
                return BadRequest();
            }

            db.Entry(asset).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssetExists(id))
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

        // POST api/Asset
        [ResponseType(typeof(Asset))]
        public IHttpActionResult PostAsset(Asset asset)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Asset.Add(asset);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = asset.AssetID }, asset);
        }

        // DELETE api/Asset/5
        [ResponseType(typeof(Asset))]
        public IHttpActionResult DeleteAsset(short id)
        {
            Asset asset = db.Asset.Find(id);
            if (asset == null)
            {
                return NotFound();
            }

            db.Asset.Remove(asset);
            db.SaveChanges();

            return Ok(asset);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AssetExists(short id)
        {
            return db.Asset.Count(e => e.AssetID == id) > 0;
        }
    }
}