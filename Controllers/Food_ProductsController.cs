using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Carnival.Models;

namespace Carnival.Controllers
{
    [OutputCache(Duration = 600, Location = System.Web.UI.OutputCacheLocation.Client)]
    [Authorize]
    public class Food_ProductsController : Controller
    {
        private CarnivalContext db = new CarnivalContext();

        // GET: Food_Products
        public ActionResult Index()
        {
            //var result = db.FoodProducts.Where(item => item.FoodID == 10 || item.FoodID == 1013);
            return View(db.FoodProducts.ToList() /*result*/);
        }

        // GET: Food_Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Food_Product food_Product = db.FoodProducts.Find(id);
            if (food_Product == null)
            {
                return HttpNotFound();
            }
            return View(food_Product);
        }

        // GET: Food_Products/Create
        public ActionResult Create()
        {
            ViewData["f"] = db.FoodProducts.ToList();
            return View();
        }

        // POST: Food_Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FoodID,Name,Description,Price")] Food_Product food_Product)
        {
            if (ModelState.IsValid)
            {
                db.FoodProducts.Add(food_Product);
                db.SaveChanges();
                return Json(JsonRequestBehavior.AllowGet);
            }

            return View(food_Product);
        }

        // GET: Food_Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Food_Product food_Product = db.FoodProducts.Find(id);
            if (food_Product == null)
            {
                return HttpNotFound();
            }
            return View(food_Product);
        }

        // POST: Food_Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FoodID,Name,Description,Price")] Food_Product food_Product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(food_Product).State = EntityState.Modified;
                db.SaveChanges();
                return Json(JsonRequestBehavior.AllowGet);
            }
            return View(food_Product);
        }

        // GET: Food_Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Food_Product food_Product = db.FoodProducts.Find(id);
            if (food_Product == null)
            {
                return HttpNotFound();
            }
            return View(food_Product);
        }

        // POST: Food_Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Food_Product food_Product = db.FoodProducts.Find(id);
            db.FoodProducts.Remove(food_Product);
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
