using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestProject.Models;

namespace TestProject.Controllers
{
    [Authorize]
    public class PatientController : Controller
    {
        private Context db;
        public PatientController()
        {
            db = new Context();
        }
        // GET: Patient
        public ActionResult Index()
        {
            List<Patient> model = db.Patients.ToList();
            return View(model);
        }

        [HttpPost]
        public ActionResult Search(string pattern)
        {
            if (string.IsNullOrEmpty(pattern) || string.IsNullOrWhiteSpace(pattern))
            {
                return RedirectToAction("Index");
            }

            List<Patient> model = db.Patients.Where
                (x => x.Name.ToLower().Contains(pattern.ToLower())
                || x.Surname.ToLower().Contains(pattern.ToLower())
                || x.PESEL.Contains(pattern))
                .ToList();

            return View("Index", model);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Patient model)
        {
            if (!ModelState.IsValid)
            {
                string error = "";
                foreach (var modelState in ModelState.Values)
                {
                    foreach (var modelError in modelState.Errors)
                    {
                        error += modelError.ErrorMessage + "\n";
                    }
                }
                TempData["Error"] = error;
                return RedirectToAction("Add");
            }
            db.Patients.Add(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int Patient_id)
        {
            Patient model = db.Patients.Where(x => x.Patient_id == Patient_id).FirstOrDefault();

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Patient model)
        {
            if (!ModelState.IsValid)
            {
                string error = "";
                foreach (var modelState in ModelState.Values)
                {
                    foreach (var modelError in modelState.Errors)
                    {
                        error += modelError.ErrorMessage + "\n";
                    }
                }
                TempData["Error"] = error;
                return RedirectToAction("Edit", new { @Patient_id = model.Patient_id });
            }
            Patient old = db.Patients.Single(x => x.Patient_id == model.Patient_id);
            db.Entry(old).State = System.Data.Entity.EntityState.Modified;
            old.Name = model.Name;
            old.Surname = model.Surname;
            old.PESEL = model.PESEL;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int Patient_id)
        {
           

            DeleteHelper.DeletePatient(Patient_id);
            DeleteHelper.SaveChanges();

            return RedirectToAction("Index");
        }


    }

}