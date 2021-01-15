using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestProject.Models;

namespace TestProject.Controllers
{
    public class HomeController : Controller
    {
        private Context db;
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddPatient()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddPatient(Patient model)
        {
            db.Patients.Add(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult AddCard()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCard(FeverCard model)
        {
            db.FeverCards.Add(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult AddMeasure()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddMeasure(Measure model)
        {
            db.Measures.Add(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}