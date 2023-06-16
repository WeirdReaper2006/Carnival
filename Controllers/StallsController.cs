using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Carnival.Models;

namespace Carnival.Controllers
{
    [OutputCache(Duration = 600, Location = System.Web.UI.OutputCacheLocation.Client)]
    public class StallsController : Controller
    {
        private CarnivalContext db = new CarnivalContext();

        // GET: Stalls
        public ActionResult Index()
        {
            return View(db.Stalls.ToList());
        }

        // GET: Stalls/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stall stall = db.Stalls.Find(id);
            if (stall == null)
            {
                return HttpNotFound();
            }
            return View(stall);
        }

        // GET: Stalls/Create
        public ActionResult Create()
        {
            ViewData["s"] = db.Stalls.ToList();
            return View();
        }

        // POST: Stalls/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StallID,Name,Address,Specialty")] Stall stall)
        {
            if (ModelState.IsValid)
            {
                db.Stalls.Add(stall);
                db.SaveChanges();
                return Json(JsonRequestBehavior.AllowGet);
            }

            return View(stall);
        }

        // GET: Stalls/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stall stall = db.Stalls.Find(id);
            if (stall == null)
            {
                return HttpNotFound();
            }
            return View(stall);
        }

        // POST: Stalls/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StallID,Name,Address,Specialty")] Stall stall)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stall).State = EntityState.Modified;
                db.SaveChanges();
                return Json(JsonRequestBehavior.AllowGet);
            }
            return View(stall);
        }

        // GET: Stalls/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stall stall = db.Stalls.Find(id);
            if (stall == null)
            {
                return HttpNotFound();
            }
            return View(stall);
        }

        // POST: Stalls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Stall stall = db.Stalls.Find(id);
            db.Stalls.Remove(stall);
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
