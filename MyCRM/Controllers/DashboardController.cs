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
    }
}