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
    [RoutePrefix("api/Suppliers")]
    public class SuppliersController : ApiController
    {
        private AuthContext db = new AuthContext();

        // GET: api/Suppliers
        public List<SupplierModel> GetSuppliers()
        {

            List<SupplierModel> ListSupplierModel = new List<SupplierModel>();

            List<Supplier> listOfSupplier = db.Suppliers.ToList();

            foreach (var supplier in listOfSupplier)
            {
                SupplierModel SupplierModel = new SupplierModel();

                SupplierModel.name = supplier.Name;
                SupplierModel.address = supplier.Address;
                SupplierModel.contact = supplier.Contact;
                SupplierModel.supplierID = supplier.SupplierID;
                SupplierModel.totalAmount = supplier.TotalAmount;
                SupplierModel.amountPaid = supplier.AmountPaid;
                //SupplierModel.projectID = supplier.ProjectID;

                ListSupplierModel.Add(SupplierModel);
            }

            return ListSupplierModel;         
        }


        [HttpGet]
        [Route("GetSupplier")]
        [ActionName("GetSupplier")]

        public List<SupplierModel> GetSupplier(string userName)
        {

            var userID = db.Users.FirstOrDefault(x => x.UserName == userName).Id;
            List<SupplierModel> ListSupplierModel = new List<SupplierModel>();

            //List<Supplier> listOfSupplier = db.Suppliers.Where(x => x.ProjectID == id).ToList();

            //List<Supplier> listOfSupplier = db.Suppliers.ToList();
            List<Supplier> listOfSupplier = db.Suppliers.Where(x => x.UserId == userID).ToList();

            foreach (var supplier in listOfSupplier)
            { 
                SupplierModel SupplierModel = new SupplierModel();

                SupplierModel.name = supplier.Name;
                SupplierModel.address = supplier.Address;
                SupplierModel.contact = supplier.Contact;
                SupplierModel.supplierID = supplier.SupplierID;
                SupplierModel.totalAmount = supplier.TotalAmount;
                SupplierModel.amountPaid = supplier.AmountPaid;
                //SupplierModel.projectID = supplier.ProjectID;

                ListSupplierModel.Add(SupplierModel);
            }

            return ListSupplierModel;
        }

        [HttpGet]
        [Route("SupplierByID")]
        [ActionName("SupplierByID")]
        public Supplier SupplierByID(int id)
        {
            Supplier Supplier = new Supplier();
            Supplier = db.Suppliers.FirstOrDefault(x => x.SupplierID == id);

            return Supplier;
        }

        // PUT: api/Suppliers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSupplier(Supplier supplier)
        {
            var id = supplier.SupplierID;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != supplier.SupplierID)
            {
                return BadRequest();
            }

            db.Entry(supplier).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SupplierExists(id))
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

        // POST: api/Suppliers
        [ResponseType(typeof(Supplier))]
        public IHttpActionResult PostSupplier(SupplierPostModel SupplierPostModel)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}


            var userID = db.Users.FirstOrDefault(x => x.UserName == SupplierPostModel.UserName).Id;

            SupplierPostModel.Supplier.UserId = userID;



            db.Suppliers.Add(SupplierPostModel.Supplier);
            db.SaveChanges();


            var projectId = SupplierPostModel.projectID;

            SupplierProject supplierproject = new SupplierProject();

            supplierproject.projectID = projectId;
            supplierproject.supplierID = SupplierPostModel.Supplier.SupplierID;


            db.SupplierProjects.Add(supplierproject);

            db.SaveChanges();



            return CreatedAtRoute("DefaultApi", new { id = SupplierPostModel.Supplier.SupplierID }, SupplierPostModel.Supplier);
        }

        // DELETE: api/Suppliers/5
        [ResponseType(typeof(Supplier))]
        public IHttpActionResult DeleteSupplier(int id)
        {
            Supplier supplier = db.Suppliers.Find(id);
            if (supplier == null)
            {
                return NotFound();
            }

            db.Suppliers.Remove(supplier);
            db.SaveChanges();

            return Ok(supplier);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SupplierExists(int id)
        {
            return db.Suppliers.Count(e => e.SupplierID == id) > 0;
        }
    }
}