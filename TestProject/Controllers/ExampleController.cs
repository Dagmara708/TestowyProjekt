﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestProject.Models;

namespace TestProject.Controllers
{
    public class ExampleController : Controller
    {
        private Context db;

        public ExampleController()
        {
            db = new Context();
        }

        // GET: Example
        public ActionResult Index()
        {
            List<Patient> model = db.Patients.ToList();

            return View(model);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Patient model)
        {
            db.Patients.Add(model);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int Id)
        {
            Patient model = db.Patients.Where(x => x.Patient_id == Id).FirstOrDefault();

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Patient model)
        {
            Patient old = db.Patients.Single(x => x.Patient_id == model.Patient_id);
            db.Entry(old).State = System.Data.Entity.EntityState.Modified;
            old.Name = model.Name;
            old.Surname = model.Surname;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int Id)
        {
            Patient old = db.Patients.Single(x => x.Patient_id == Id);
            db.Patients.Remove(old);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}