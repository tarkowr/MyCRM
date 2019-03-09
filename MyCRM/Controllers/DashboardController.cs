using System;
using System.Collections.Generic;
using System.Web;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using MyCRM.DAL;
using MyCRM.Models;
using PagedList;

namespace MyCRM.Controllers
{
    public class DashboardController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Dashboard
        public ActionResult Index(string order, string searchString)
        {
            // Save the current order
            ViewBag.CurrentSort = order;

            // Set default order
            ViewBag.CustomerSortParm = String.IsNullOrEmpty(order) ? "name_desc" : "";

            // Get all customers
            var customers = from c in db.Customers
                            select c;

            // Filter customers or accounts by search query
            if (!String.IsNullOrEmpty(searchString))
            {
                customers = customers.Where(c => c.Name.Contains(searchString) || c.Account.AccountName.Contains(searchString));
            }

            // Order Customers by Name
            switch (order)
            {
                case "name_desc":
                    customers = customers.OrderByDescending(c => c.Name);
                    break;
                default:
                    customers = customers.OrderBy(c => c.Name);
                    break;
            }
        
            var dashboard = new DashboardViewModel(customers.ToList(), db.Accounts.ToList(), db.Memberships.ToList());
            return View(dashboard);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditCustomer([Bind(Include = "ID, AccountID, Name, Email, Phone")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        // GET: Dashboard/Edit
        public ActionResult EditCustomer(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Customer customer = db.Customers.Find(id);

            if(customer == null)
            {
                return HttpNotFound();
            }

            ViewBag.AccountID = new SelectList(db.Accounts, "AccountID", "AccountName", customer.AccountID);
            return View(customer);
        }
    }
}