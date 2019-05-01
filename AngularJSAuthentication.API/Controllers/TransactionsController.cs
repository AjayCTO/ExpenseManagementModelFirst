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
    public class TransactionsController : ApiController
    {
        private AuthContext db = new AuthContext();

        // GET: api/Transactions
        public IQueryable<Transaction> GetTransaction()
        {
            return db.Transaction;
        }

        // GET: api/Transactions/5
        [ResponseType(typeof(DashboardProjectModel))]
        public DashboardProjectModel GetTransaction(short id)
        {
            DashboardProjectModel DashboardProjectModel = new DashboardProjectModel();

            var expenses = db.Expenses.Where(x => x.ProjectID == id).ToList();
            DashboardProjectModel.Expenses = expenses;

            foreach (var expense in expenses)
            {
                DashboardProjectModel.totalExpense = (decimal)(DashboardProjectModel.totalExpense + (expense.Amount != null ? expense.Amount : 0));
            }



            var project = db.Projects.FirstOrDefault(x => x.ProjectID == id);
            DashboardProjectModel.totalCost = project.TotalCost;
            DashboardProjectModel.projectName = project.Name;

            var Incomings = db.Incomings.Where(x => x.ProjectID == id);
            foreach (var income in Incomings)
            {
                DashboardProjectModel.totalIncoming = (decimal)(DashboardProjectModel.totalIncoming + income.Amount);
            }


            return DashboardProjectModel;
        }

        // PUT: api/Transactions/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTransaction(short id, Transaction transaction)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != transaction.TransactionID)
            {
                return BadRequest();
            }

            db.Entry(transaction).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransactionExists(id))
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

        // POST: api/Transactions
        [ResponseType(typeof(Transaction))]
        public IHttpActionResult PostTransaction(Transaction transaction)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Transaction.Add(transaction);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = transaction.TransactionID }, transaction);
        }

        // DELETE: api/Transactions/5
        [ResponseType(typeof(Transaction))]
        public IHttpActionResult DeleteTransaction(short id)
        {
            Transaction transaction = db.Transaction.Find(id);
            if (transaction == null)
            {
                return NotFound();
            }

            db.Transaction.Remove(transaction);
            db.SaveChanges();

            return Ok(transaction);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TransactionExists(short id)
        {
            return db.Transaction.Count(e => e.TransactionID == id) > 0;
        }
    }
}