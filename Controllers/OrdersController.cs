﻿using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Carnival.Models;

namespace Carnival.Controllers
{
    [OutputCache(Duration = 600, Location = System.Web.UI.OutputCacheLocation.Client)]
    [Authorize]
    public class OrdersController : Controller
    {
        private CarnivalContext db = new CarnivalContext();

        // GET: Orders
        public ActionResult Index()
        {
            var orders = db.Orders.Include(o => o.Customer).Include(o => o.Food_Product).Include(o => o.Stall);
            return View(orders.ToList());
        }

        // GET: Orders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // GET: Orders/Create
        public ActionResult Create()
        {
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "Name");
            ViewBag.FoodID = new SelectList(db.FoodProducts, "FoodID", "Name");
            ViewBag.StallID = new SelectList(db.Stalls, "StallID", "Name");
            ViewData["o"] = db.Orders.Include(o => o.Customer).Include(o => o.Food_Product).Include(o => o.Stall).ToList();
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderID,CustomerID,FoodID,Quantity,StallID")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Orders.Add(order);
                db.SaveChanges();
                return Json(JsonRequestBehavior.AllowGet);
            }

            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "Name", order.CustomerID);
            //ViewBag.FoodID = new SelectList(db.FoodProducts, "FoodID", "Name", order.FoodID);
            //ViewBag.StallID = new SelectList(db.Stalls, "StallID", "Name", order.StallID);
            return View(order);
        }

        // GET: Orders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "Name", order.CustomerID);
            ViewBag.FoodID = new SelectList(db.FoodProducts, "FoodID", "Name", order.FoodID);
            ViewBag.StallID = new SelectList(db.Stalls, "StallID", "Name", order.StallID);
            return PartialView(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderID,CustomerID,FoodID,Quantity,StallID")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
            }
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "Name", order.CustomerID);
            ViewBag.FoodID = new SelectList(db.FoodProducts, "FoodID", "Name", order.FoodID);
            ViewBag.StallID = new SelectList(db.Stalls, "StallID", "Name", order.StallID);
            return RedirectToAction("Index");
        }

        // GET: Orders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order order = db.Orders.Find(id);
            db.Orders.Remove(order);
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
    }
}
