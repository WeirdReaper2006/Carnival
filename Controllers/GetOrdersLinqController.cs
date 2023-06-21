using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Mvc;
using Newtonsoft.Json.Linq;
using Carnival.Models;

namespace Carnival.Controllers
{
    public class GetOrdersLinqController : Controller
    {
        // GET: GetOrdersLinq
        public ActionResult Index()
        {
            var orders = new List<GetOrderLinq>();
            using (var dbContext = new CarnivalContext())
            {
                orders = dbContext.Database.SqlQuery<GetOrderLinq>("EXEC dbo.GetOrders").ToList();
            }
            return View(orders);
        }
    }
}