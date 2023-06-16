using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Carnival.Models;

namespace Carnival.Controllers
{
    [OutputCache(Duration = 600, Location = System.Web.UI.OutputCacheLocation.Client)]
    public class FoodStallRelationshipsController : Controller
    {
        private CarnivalContext db = new CarnivalContext();

        // GET: FoodStallRelationships
        public ActionResult Index()
        {
            var foodStallRelationships = db.FoodStallRelationships.Include(f => f.Food_Product).Include(f => f.Stall);
            return View(foodStallRelationships.ToList());
        }

        // GET: FoodStallRelationships/Details/5
        public ActionResult Details(int? foodID, int? stallID)
        {
            if (foodID == null || stallID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            FoodStallRelationship foodStallRelationship = db.FoodStallRelationships.Find(foodID, stallID);

            if (foodStallRelationship == null)
            {
                return HttpNotFound();
            }

            return View(foodStallRelationship);
        }

        // GET: FoodStallRelationships/Create
        public ActionResult Create()
        {
            ViewBag.FoodID = new SelectList(db.FoodProducts, "FoodID", "Name");
            ViewBag.StallID = new SelectList(db.Stalls, "StallID", "Name");
            ViewData["fsr"] = db.FoodStallRelationships.Include(f => f.Food_Product).Include(f => f.Stall).ToList();
            return View();
        }

        // POST: FoodStallRelationships/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FoodID,StallID")] FoodStallRelationship foodStallRelationship)
        {
            if (ModelState.IsValid)
            {
                db.FoodStallRelationships.Add(foodStallRelationship);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FoodID = new SelectList(db.FoodProducts, "FoodID", "Name", foodStallRelationship.FoodID);
            ViewBag.StallID = new SelectList(db.Stalls, "StallID", "Name", foodStallRelationship.StallID);
            return View(foodStallRelationship);
        }

        // GET: FoodStallRelationships/Edit/5
        public ActionResult Edit(int? foodID, int? stallID)
        {
            if (foodID == null || stallID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            FoodStallRelationship foodStallRelationship = db.FoodStallRelationships.Find(foodID, stallID);

            if (foodStallRelationship == null)
            {
                return HttpNotFound();
            }

            ViewBag.FoodID = new SelectList(db.FoodProducts, "FoodID", "Name", foodStallRelationship.FoodID);
            ViewBag.StallID = new SelectList(db.Stalls, "StallID", "Name", foodStallRelationship.StallID);
            return View(foodStallRelationship);
        }

        // POST: FoodStallRelationships/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FoodID,StallID")] FoodStallRelationship foodStallRelationship)
        {
            if (ModelState.IsValid)
            {
                db.Entry(foodStallRelationship).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FoodID = new SelectList(db.FoodProducts, "FoodID", "Name", foodStallRelationship.FoodID);
            ViewBag.StallID = new SelectList(db.Stalls, "StallID", "Name", foodStallRelationship.StallID);
            return View(foodStallRelationship);
        }

        // GET: FoodStallRelationships/Delete/5
        public ActionResult Delete(int? foodID, int? stallID)
        {
            if (foodID == null || stallID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            FoodStallRelationship foodStallRelationship = db.FoodStallRelationships.Find(foodID, stallID);

            if (foodStallRelationship == null)
            {
                return HttpNotFound();
            }

            return View(foodStallRelationship);
        }

        // POST: FoodStallRelationships/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int foodID, int stallID)
        {
            FoodStallRelationship foodStallRelationship = db.FoodStallRelationships.Find(foodID, stallID);

            if (foodStallRelationship == null)
            {
                return HttpNotFound();
            }

            db.FoodStallRelationships.Remove(foodStallRelationship);
            db.SaveChanges();

            // Return a JSON response indicating the success of the delete action
            return Json(new { success = true });
        }



    }
}
