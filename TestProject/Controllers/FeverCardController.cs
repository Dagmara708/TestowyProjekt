using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestProject.Models;
using Microsoft.AspNet.Identity;

namespace TestProject.Controllers
{
    [Authorize]
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

        public ActionResult Add(int? Patient_id)
        {
            List<Doctor> doctorsModel = db.Doctors.ToList();
            if (Patient_id.HasValue)
            {
                var uid = User.Identity.GetUserId();
                Doctor doc = db.Doctors.Single(x => x.User_id == uid);

                FeverCard model = new FeverCard() 
                { 
                    Patient_id = Patient_id.Value,
                    Doctor_id = doc.Doctor_id
                };
               // /ViewBag.Doctors = doctorsModel;
                return View(model);
            }
            List<Patient> patientsModel = db.Patients.ToList();
            ViewBag.Patients = patientsModel;
           //  ViewBag.Doctors = doctorsModel;
            return View("AddNoPatient");
        }

        [HttpPost]
        public ActionResult Add(FeverCard model)
        {
            var uid = User.Identity.GetUserId();
            Doctor doc = db.Doctors.Single(x => x.User_id == uid);
            model.Doctor_id = doc.Doctor_id;
            db.FeverCards.Add(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int Card_id)
        {
            //FeverCard old = db.FeverCards.Single(x => x.Card_id == Card_id);
            //db.FeverCards.Remove(old);
            //db.SaveChanges();

            DeleteHelper.DeleteFeverCard(Card_id);
            DeleteHelper.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int Card_id)
        {
            List<Doctor> doctorsModel = db.Doctors.ToList();
            List<Patient> patientsModel = db.Patients.ToList();

            FeverCard model = db.FeverCards.Where(x => x.Card_id == Card_id).FirstOrDefault();

            ViewBag.Patients = patientsModel;
            ViewBag.Doctors = doctorsModel;

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

        [HttpPost]
        public ActionResult Search(string pattern)
        {
            if (string.IsNullOrEmpty(pattern) || string.IsNullOrWhiteSpace(pattern))
            {
                return RedirectToAction("Index");
            }

            List<FeverCard> model = db.FeverCards.Where(x => x.Patient.Name.ToLower().Contains(pattern.ToLower()) ||
                x.Patient.Surname.ToLower().Contains(pattern.ToLower()) ||
                x.Patient.PESEL.ToLower().Contains(pattern.ToLower()))
                .ToList();


            return View("Index", model);
        }

    }



}