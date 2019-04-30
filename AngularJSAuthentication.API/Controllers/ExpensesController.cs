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
using System.Web.Services;
using System.Web.Script.Services;
using System.Web.Http.Results;

namespace AngularJSAuthentication.API.Controllers
{
       [RoutePrefix("api/Expenses")]
    public class ExpensesController : ApiController
    {
        private AuthContext db = new AuthContext();

    
        // [Route("GetData")]
        //public IHttpActionResult GetData()
        //{
        //    try
        //    {
        //        List<Expense> productList = db.Expenses.ToList<Expense>();
        //        return Json(new { success = true, sensorsdata = new { data = productList } });
        //    }
        //    catch(SyntaxErrorException)
        //    {

        //    }

           
        //    return Json((object)new { success = false });

        //}  



        // GET: api/Expenses


        public List<ExpenseModel> GetExpenses( string userName)
        {
            var userID = db.Users.FirstOrDefault(x => x.UserName == userName).Id;

            List<ExpenseModel> ExpenseModelList = new List<ExpenseModel>();
            
            var expenses = db.Expenses.Where(x => x.UserId == userID).ToList();

            foreach (var expense in expenses)
            {
                ExpenseModel ExpenseModel = new Models.ExpenseModel();
                ExpenseModel.expenseID = expense.ExpenseID;
                ExpenseModel.projectName = expense.Project.Name;
                ExpenseModel.assetName = expense.Asset != null ? expense.Asset.Name : "";
                ExpenseModel.categoryName = expense.Category != null ? expense.Category.Name : "";
                ExpenseModel.TotalAmount = expense.Amount != null ? (decimal)expense.Amount : 0;
                ExpenseModel.description = expense.Description;
                ExpenseModelList.Add(ExpenseModel);
            }
            return ExpenseModelList;
        }

        // GET: api/Expenses/5
        [ResponseType(typeof(Expense))]
        //public IHttpActionResult GetExpense(short id)
        //{
        //    Expense expense = db.Expenses.Find(id);
        //    if (expense == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(expense);
        //}

        // PUT: api/Expenses/5
        [ResponseType(typeof(void))]
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

        // POST: api/Expenses
        [ResponseType(typeof(Expense))]
        public IHttpActionResult PostExpense(ExpenseUserModel expense)
        {

            var userID = db.Users.FirstOrDefault(x => x.UserName == expense.UserName).Id;
            if (!ModelState.IsValid)
            {
                //return BadRequest(ModelState);
            }
            expense.Expense.UserId = userID;

            db.Expenses.Add(expense.Expense);
            db.SaveChanges();


            var transaction = new Transaction();

            transaction.ProjectID = (short?)expense.Expense.ProjectID;
            transaction.AssetID = (short?)expense.Expense.AssetID;
            transaction.SupplierID = (int?)expense.Expense.SupplierID;
            transaction.ExpenseID = (int?)expense.Expense.ExpenseID;
            transaction.TotalAmount = (int?)expense.Expense.Amount;

            db.Transaction.Add(transaction);
            db.SaveChanges();

            return Ok(expense);
        }

        // DELETE: api/Expenses/5
        [ResponseType(typeof(Expense))]
        public IHttpActionResult DeleteExpense(short id)
        {
            Expense expense = db.Expenses.Find(id);
            if (expense == null)
            {
                return NotFound();
            }

            db.Expenses.Remove(expense);
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
            return db.Expenses.Count(e => e.ExpenseID == id) > 0;
        }
    }
}