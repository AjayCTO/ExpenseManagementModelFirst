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
                SupplierModel.projectID = supplier.ProjectID;

                ListSupplierModel.Add(SupplierModel);
            }

            return ListSupplierModel;         
        }


        [HttpGet]
        [Route("GetSupplier")]
        [ActionName("GetSupplier")]

        public List<SupplierModel> GetSupplier(int id)
        {
            List<SupplierModel> ListSupplierModel = new List<SupplierModel>();

            List<Supplier> listOfSupplier = db.Suppliers.Where(x => x.ProjectID == id).ToList();

            foreach (var supplier in listOfSupplier)
            { 
                SupplierModel SupplierModel = new SupplierModel();

                SupplierModel.name = supplier.Name;
                SupplierModel.address = supplier.Address;
                SupplierModel.contact = supplier.Contact;
                SupplierModel.supplierID = supplier.SupplierID;
                SupplierModel.totalAmount = supplier.TotalAmount;
                SupplierModel.amountPaid = supplier.AmountPaid;
                SupplierModel.projectID = supplier.ProjectID;

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
        public IHttpActionResult PostSupplier(Supplier supplier)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            db.Suppliers.Add(supplier);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = supplier.SupplierID }, supplier);
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