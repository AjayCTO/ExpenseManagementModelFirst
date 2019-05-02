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
    public class CategoriesController : ApiController
    {
        private AuthContext db = new AuthContext();

        // GET: api/Categories
        public List<Category> GetCategories()
        {
            return db.Categories.ToList();
        }

        // GET: api/Categories/5
        [ResponseType(typeof(Category))]
        public List<CategoryModel> GetCategory(int id)
        {
            //Return list of categories related to the project id
            List<CategoryModel> ListCategoryModel = new List<CategoryModel>();

            List<Category> listOfCategory = db.Categories.Where(x => x.ProjectID == id).ToList();
        
            foreach(var category in listOfCategory)
            {
                CategoryModel CategoryModel = new CategoryModel();
                CategoryModel.name = category.Name;
                CategoryModel.description = category.Description;
                CategoryModel.categoryID = category.CategoryID;
                CategoryModel.projectID = category.ProjectID;

                ListCategoryModel.Add(CategoryModel);
            }


            return ListCategoryModel;
        }

        // PUT: api/Categories/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCategory(Category category)
        {
            var id = category.CategoryID;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != category.CategoryID)
            {
                return BadRequest();
            }

            db.Entry(category).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(id))
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

        // POST: api/Categories
        [ResponseType(typeof(Category))]
        public IHttpActionResult PostCategory(Category category)
        {
            if (!ModelState.IsValid)
            {
                //return BadRequest(ModelState);
            }

            db.Categories.Add(category);
            db.SaveChanges();

            return Ok(category);
        }

        // DELETE: api/Categories/5
        [ResponseType(typeof(Category))]
        public IHttpActionResult DeleteCategory(int id)
        {
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }

            db.Categories.Remove(category);
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

        private bool CategoryExists(int id)
        {
            return db.Categories.Count(e => e.CategoryID == id) > 0;
        }
    }
}