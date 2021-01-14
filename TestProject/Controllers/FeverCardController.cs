using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestProject.Models;

namespace TestProject.Controllers
{
    public class FeverCardController : Controller
    {
        // GET: FeverCard
        private Context db;
        public FeverCardController()
        {
            db = new Context();
        }


        public ActionResult Index()
        {
            List<FeverCard> model = db.FeverCards.ToList();
            return View(model);
        }
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(FeverCard model)
        {
            db.FeverCards.Add(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int Card_id)
        {
            FeverCard old = db.FeverCards.Single(x => x.Card_id == Card_id);
            db.FeverCards.Remove(old);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int Card_id)
        {
            FeverCard model = db.FeverCards.Where(x => x.Card_id == Card_id).FirstOrDefault();

            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(FeverCard model)
        {
            FeverCard old = db.FeverCards.Single(x => x.Card_id == model.Card_id);
            db.Entry(old).State = System.Data.Entity.EntityState.Modified;
            old.Doctor_id = model.Doctor_id;
            old.Patient_id = model.Patient_id;
            old.Patient_age = model.Patient_age;
            old.Weight = model.Weight;
            old.Hospital = model.Hospital;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

    }



}