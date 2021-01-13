using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestProject.Models;

namespace TestProject.Controllers
{
    public class MeasureController : Controller
    {
        private Context db;

        public MeasureController()
        {
            db = new Context();
        }

        // GET: Measure
        public ActionResult Index()
        {
            List<Measure> model = db.Measures.ToList();
            return View(model);
        }
    }
}