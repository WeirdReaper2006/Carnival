using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Carnival.Controllers
{
    public class RandomsController : Controller
    {
        // GET: Platforms
        public ActionResult FoodPics()
        {
            return View();
        }
    }
}