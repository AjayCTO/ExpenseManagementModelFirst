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
     [RoutePrefix("api/Expense")]
    public class ExpenseController : ApiController
    {
        private AuthContext db = new AuthContext();

        // GET api/Expense
        [Authorize]
        [Route("")]
        public IQueryable<Expense> GetExpense()
        {
            return db.Expense;
        }

        // GET api/Expense/5
        [ResponseType(typeof(Expense))]
        [Route("GetExpense")]
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
          [Route("PutExpense")]
        public IHttpActionResult PutExpense(Expense expense)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //if (id != expense.ExpenseID)
            //{
            //    return BadRequest();
            //}

            db.Entry(expense).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!ExpenseExists(id))
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

        // POST api/Expense
        [ResponseType(typeof(Expense))]
        [Route("PostExpense")]
       public IHttpActionResult PostExpense(expenseUserModel expenseUserModel)
       {
            var UserId = db.Users.FirstOrDefault(x => x.UserName == expenseUserModel.userName).Id;


            Transaction transaction = new Transaction();

            transaction.ProjectID = expenseUserModel.Expense.ProjectID;
            transaction.AssetID = expenseUserModel.Expense.AssetID;
            transaction.SupplierID = expenseUserModel.Expense.SupplierID;
            transaction.TotalAmount = expenseUserModel.Expense.Amount;

            expenseUserModel.Expense.Date = DateTime.Now;
            expenseUserModel.Expense.UserId = UserId;            
            if (!ModelState.IsValid)
            {
                //return BadRequest(ModelState);
            }
            db.Expense.Add(expenseUserModel.Expense);
            db.Transaction.Add(transaction);
            db.SaveChanges();
            return Ok(expenseUserModel.Expense);
        }

        // DELETE api/Expense/5
        [ResponseType(typeof(Expense))]
        [Route("DeleteExpense")]
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