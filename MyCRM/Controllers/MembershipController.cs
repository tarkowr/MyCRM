using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyCRM.DAL;
using MyCRM.Models;

namespace MyCRM.Controllers
{
    public class MembershipController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Membership
        public ActionResult Index()
        {
            var memberships = db.Memberships.Include(m => m.Customer);
            return View(memberships.ToList());
        }

        // GET: Membership/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Membership membership = db.Memberships.Find(id);
            if (membership == null)
            {
                return HttpNotFound();
            }
            return View(membership);
        }

        // GET: Membership/Create
        public ActionResult Create()
        {
            ViewBag.CustomerID = new SelectList(db.Customers, "ID", "Name");
            return View();
        }

        // POST: Membership/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MembershipID,CustomerID,MembershipLevel,EffectiveDate,ExpirationDate,Price")] Membership membership)
        {
            try
            {
                membership.CalculateMembershipPrice();
                if (ModelState.IsValid)
                {
                    db.Memberships.Add(membership);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.CustomerID = new SelectList(db.Customers, "ID", "Name", membership.CustomerID);
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to Save Changes.");
            }

            return View(membership);
        }

        // GET: Membership/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Membership membership = db.Memberships.Find(id);
            if (membership == null)
            {
                return HttpNotFound();
            }
            membership.CalculateMembershipPrice();
            ViewBag.CustomerID = new SelectList(db.Customers, "ID", "Name", membership.CustomerID);
            return View(membership);
        }

        // POST: Membership/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MembershipID,CustomerID,MembershipLevel,EffectiveDate,ExpirationDate,Price")] Membership membership)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(membership).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (DataException)
                {
                    ModelState.AddModelError("", "Unable to Save Changes.");
                }
            }
            ViewBag.CustomerID = new SelectList(db.Customers, "ID", "Name", membership.CustomerID);
            return View(membership);
        }

        // GET: Membership/Delete/5
        public ActionResult Delete(int? id, bool? saveChangesError=false)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Please try again.";
            }

            Membership membership = db.Memberships.Find(id);
            if (membership == null)
            {
                return HttpNotFound();
            }
            return View(membership);
        }

        // POST: Membership/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Membership membership = db.Memberships.Find(id);
                db.Memberships.Remove(membership);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (DataException)
            {
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
