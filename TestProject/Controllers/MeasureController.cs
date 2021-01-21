using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestProject.Models;

namespace TestProject.Controllers
{
    [Authorize]
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

        public ActionResult Add(int? Card_id)
        {
            if (Card_id.HasValue)
            {
                Measure model = new Measure() { Card_id = Card_id.Value };
                return View(model);
            }
            List<FeverCard> FeverCardModel = db.FeverCards.ToList();
            ViewBag.FeverCardModel = FeverCardModel;
            return View("AddNoCard");
        }

        [HttpPost]
        public ActionResult Add(Measure model)
        {
            db.Measures.Add(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int Measure_id)
        {
           

            DeleteHelper.DeleteMeasure(Measure_id);
            DeleteHelper.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int Measure_id)
        {
            Measure model = db.Measures.Where(x => x.Measure_id == Measure_id).FirstOrDefault();

            List<FeverCard> FeverCardModel = db.FeverCards.ToList();
            ViewBag.FeverCardModel = FeverCardModel;

            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(Measure model)
        {
            Measure old = db.Measures.Single(x => x.Measure_id == model.Measure_id);
            db.Entry(old).State = System.Data.Entity.EntityState.Modified;
            old.Card_id = model.Card_id;
            old.Day_of_stay = model.Day_of_stay;
            old.Time_of_day = model.Time_of_day;
            old.Temperature = model.Temperature;
            old.Pulse = model.Pulse;
            old.Stool = model.Stool;
            old.Diet = model.Diet;
            old.Doctors_rec = model.Doctors_rec;
            old.Others = model.Others;
            db.SaveChanges();

            return RedirectToAction("Index");
        }
       
        public ActionResult GetMeasuresByFeverCardId(int Card_id)
        {
            List<Measure> model = db.Measures.Where(x => x.FeverCard.Card_id == Card_id).ToList();

            return View("Index", model);
        }

    }
}