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
using AngularJSAuthentication.API.Models;
using AngularJSAuthentication.API;

namespace AngularJSAuthentication.API.Controllers
{
     [RoutePrefix("api/Category")]
    public class CategoryController : ApiController
    {
        private AuthContext db = new AuthContext();

        // GET api/Category
        [Authorize]
        [Route("")]
        public IEnumerable<Category> GetCategory()
        {
            return db.Category.ToList();
        }

        // GET api/Category/5
        [ResponseType(typeof(Category))]
        [Route("GetCategory")]
        public IHttpActionResult GetCategory(short id)
        {
            Category category = db.Category.Find(id);
            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        // PUT api/Category/5
          [Route("PutCategory")]
        public IHttpActionResult PutCategory(Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //if (id != category.CategoryID)
            //{
            //    return BadRequest();
            //}

            db.Entry(category).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!CategoryExists(id))
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

        // POST api/Category
        [ResponseType(typeof(Category))]
        [Route("PostCategory")]
        public IHttpActionResult PostCategory(Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Category.Add(category);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = category.CategoryID }, category);
        }

        // DELETE api/Category/5
        [ResponseType(typeof(Category))]
        [Route("DeleteCategory")]
        public IHttpActionResult DeleteCategory(short id)
        {
            Category category = db.Category.Find(id);
            if (category == null)
            {
                return NotFound();
            }

            db.Category.Remove(category);
            db.SaveChanges();

            return Ok(category);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CategoryExists(short id)
        {
            return db.Category.Count(e => e.CategoryID == id) > 0;
        }
    }
}