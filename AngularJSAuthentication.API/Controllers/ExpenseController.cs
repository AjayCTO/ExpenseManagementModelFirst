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
    public class ExpenseController : ApiController
    {
        private AuthContext db = new AuthContext();

        // GET api/Expense
        public IQueryable<Expense> GetExpense()
        {
            return db.Expense;
        }

        // GET api/Expense/5
        [ResponseType(typeof(Expense))]
        public IHttpActionResult GetExpense(short id)
        {
            Expense expense = db.Expense.Find(id);
            if (expense == null)
            {
                return NotFound();
            }

            return Ok(expense);
        }

        // PUT api/Expense/5
        public IHttpActionResult PutExpense(short id, Expense expense)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != expense.ExpenseID)
            {
                return BadRequest();
            }

            db.Entry(expense).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExpenseExists(id))
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

        // POST api/Expense
        [ResponseType(typeof(Expense))]
        public IHttpActionResult PostExpense(Expense expense)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Expense.Add(expense);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = expense.ExpenseID }, expense);
        }

        // DELETE api/Expense/5
        [ResponseType(typeof(Expense))]
        public IHttpActionResult DeleteExpense(short id)
        {
            Expense expense = db.Expense.Find(id);
            if (expense == null)
            {
                return NotFound();
            }

            db.Expense.Remove(expense);
            db.SaveChanges();

            return Ok(expense);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ExpenseExists(short id)
        {
            return db.Expense.Count(e => e.ExpenseID == id) > 0;
        }
    }
}