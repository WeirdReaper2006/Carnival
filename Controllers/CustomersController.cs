using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Carnival.Models;

namespace Carnival.Controllers
{
    [OutputCache(Duration = 600, Location = System.Web.UI.OutputCacheLocation.Client)]
    public class CustomersController : Controller
    {
        private CarnivalContext db = new CarnivalContext();

        // GET: Customers
        public ActionResult Index()
        {
            return View(db.Customers.ToList());
        }

        // GET: Customers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            ViewData["c"] = db.Customers.ToList();
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerID,Name,Address,ContactNo")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                return Json(JsonRequestBehavior.AllowGet);
            }

            return View(customer);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerID,Name,Address,ContactNo")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return Json(JsonRequestBehavior.AllowGet);
            }
            return View(customer);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }




        public ActionResult GetData(Datatable param)
        {
            var customers = db.Customers.AsQueryable();

            if (!string.IsNullOrEmpty(param.sSearch))
            {
                customers = customers.Where(x => x.Name.ToLower().Contains(param.sSearch.ToLower())
                    || x.Address.ToLower().Contains(param.sSearch.ToLower())
                    || x.ContactNo.ToLower().Contains(param.sSearch.ToLower()));
            }

            var sortColumnIndex = Convert.ToInt32(Request.QueryString["iSortCol_0"]);
            var sortDirection = Request.QueryString["sSortDir_0"];
            
            customers = sortDirection == "asc" ? customers.OrderBy(c => c.Name) : customers.OrderByDescending(c => c.Name);
            
            int totalRecords = customers.Count();

            var displayResult = customers
                .Skip(param.iDisplayStart)
                .Take(param.iDisplayLength)
                .ToList();

            return Json(new
            {
                param.sEcho,
                iTotalRecords = totalRecords,
                iTotalDisplayRecords = totalRecords,
                aaData = displayResult
            }, JsonRequestBehavior.AllowGet);
        }
    }

}
