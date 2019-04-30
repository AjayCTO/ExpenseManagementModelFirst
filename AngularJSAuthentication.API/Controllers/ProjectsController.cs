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
    [RoutePrefix("api/Projects")]
    public class ProjectsController : ApiController
    {
        private AuthContext db = new AuthContext();

        // GET: api/Projects
        [Route("GetProjects")]
        public List<ProjectModel> GetProjects(string userName)
        {
            List<ProjectModel> projectModalList = new List<ProjectModel>();

            var userID = db.Users.FirstOrDefault(x => x.UserName == userName).Id;

            var projectList = db.Projects.Where(x=> x.UserId == userID).ToList();


            foreach (var project in projectList)
            {
                ProjectModel projectModel = new ProjectModel();

                projectModel.projectID = project.ProjectID;
                projectModel.name = project.Name;
                projectModel.billingMethod = project.BillingMethod;
                projectModel.toalCost = project.TotalCost;

                projectModalList.Add(projectModel);
            }

            return projectModalList;
        }

        // GET: api/Projects/5
        [ResponseType(typeof(Project))]
        [Route("GetProject")]
        //public IHttpActionResult GetProject(int id)
        //{
        //    Project project = db.Projects.Find(id);
        //    if (project == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(project);
        //}

        // PUT: api/Projects/5
        [ResponseType(typeof(void))]
        [Route("PutProject")]
        public IHttpActionResult PutProject(Project project)
        {

            var id = project.ProjectID;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != project.ProjectID)
            {
                return BadRequest();
            }

            db.Entry(project).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectExists(id))
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

        // POST: api/Projects
        [ResponseType(typeof(Project))]
        [Route("PostProject")]
        public IHttpActionResult PostProject(ProjectUser project)
        {

            if (!ModelState.IsValid)
            {
                //return BadRequest(ModelState);
            }
            var userID = db.Users.FirstOrDefault(x => x.UserName == project.UserName).Id;

            //Dummy Customer
            project.Project.CustomerID = 1;

            try
            {
                project.Project.UserId = userID;
                db.Projects.Add(project.Project);
                db.SaveChanges();
            }
            catch (Exception e)
            {

                throw;
            }
           

            return Ok(project);
            //return CreatedAtRoute("DefaultApi", new { id = project.Project.ProjectID }, project);
        }

        // DELETE: api/Projects/5
        [ResponseType(typeof(Project))]
        [Route("DeleteProject")]
        public IHttpActionResult DeleteProject(int id)
        {
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return NotFound();
            }

            db.Projects.Remove(project);
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

        private bool ProjectExists(int id)
        {
            return db.Projects.Count(e => e.ProjectID == id) > 0;
        }
    }
}