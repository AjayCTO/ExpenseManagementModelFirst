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
     [RoutePrefix("api/Project")]
    public class ProjectController : ApiController
    {
        private AuthContext db = new AuthContext();

        // GET api/Project
       
        [Route("")]
        public IEnumerable<Project> GetProject()
        {
            return db.Project.ToList();
        }

        // GET api/Project/5
        [Route("GetProject")]
        [ResponseType(typeof(Project))]
        public IHttpActionResult GetProject(short id)
        {
            Project project = db.Project.Find(id);
            if (project == null)
            {
                return NotFound();
            }

            return Ok(project);
        }

        // PUT api/Project/5
          [Route("PutProject")]
        public IHttpActionResult PutProject(Project project)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //if (id != project.ProjectID)
            //{
            //    return BadRequest();
            //}

            db.Entry(project).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!ProjectExists(id))
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

        // POST api/Project
        [ResponseType(typeof(Project))]
          public IHttpActionResult PostProject(ProjectUserModel projectUserModel)
        {          

            var UserId = db.Users.FirstOrDefault(x => x.UserName == projectUserModel.userName).Id;
            
            if (!ModelState.IsValid)
            {
                //return BadRequest(ModelState);
            }


            projectUserModel.project.UserId = UserId;

            db.Project.Add(projectUserModel.project);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = projectUserModel.project.ProjectID }, projectUserModel.project);

           
        }

        // DELETE api/Project/5
        [ResponseType(typeof(Project))]
        [Route("DeleteProject")]
        public IHttpActionResult DeleteProject(short id)
        {
            Project project = db.Project.Find(id);
            if (project == null)
            {
                return NotFound();
            }

            db.Project.Remove(project);
            db.SaveChanges();

            return Ok(project);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProjectExists(short id)
        {
            return db.Project.Count(e => e.ProjectID == id) > 0;
        }
    }
}