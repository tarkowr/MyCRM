using System;
using System.Collections.Generic;
using System.Web;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using MyCRM.DAL;
using MyCRM.Models;

namespace MyCRM.Controllers
{
    public class DashboardController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Dashboard
        public ActionResult Index()
        {
            var dashboard = new DashboardViewModel(db.Customers.ToList(), db.Accounts.ToList(), db.Memberships.ToList());
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