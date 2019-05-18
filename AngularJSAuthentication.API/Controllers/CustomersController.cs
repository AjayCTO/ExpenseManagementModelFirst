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
     [RoutePrefix("api/Customers")]
    public class CustomersController : ApiController
    {
        private AuthContext db = new AuthContext();

        // GET: api/Customers
        public List<Customer> GetCustomers()
        {
            return db.Customers.ToList();
        }

        // GET: api/Customers/5
        [HttpGet]
        [Route("GetCustomer")]
        [ActionName("GetCustomer")]
        public List<Customer> GetCustomer(string userName)
        {

            var userID = db.Users.FirstOrDefault(x => x.UserName == userName).Id;

            var customers = db.Customers.Where(x => x.UserId == userID).ToList();
            //if (customers == null)
            //{
            //    return BadRequest();
            //}

            return customers;
        }

        // PUT: api/Customers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCustomer(int id, Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != customer.CustomerID)
            {
                return BadRequest();
            }

            db.Entry(customer).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
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

        // POST: api/Customers
        [HttpPost]
        [Route("PostCustomer")]
        [ActionName("PostCustomer")]
        public IHttpActionResult PostCustomer(customerPostModel customer)
        {
            var userID = db.Users.FirstOrDefault(x => x.UserName == customer.UserName).Id;

            if (!ModelState.IsValid)
            {
                //return BadRequest(ModelState);
            }

            customer.Customer.UserId = userID;
            db.Customers.Add(customer.Customer);
            db.SaveChanges();

            return Ok(customer.Customer);
        }

        // DELETE: api/Customers/5
        [ResponseType(typeof(Customer))]
        public IHttpActionResult DeleteCustomer(int id)
        {
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return NotFound();
            }

            db.Customers.Remove(customer);
            db.SaveChanges();

            return Ok(customer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CustomerExists(int id)
        {
            return db.Customers.Count(e => e.CustomerID == id) > 0;
        }
    }
}