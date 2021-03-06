﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestProject.Models;

namespace TestProject.Controllers
{
    [Authorize]
    public class DoctorController : Controller
    {
        private Context db;
        // GET: Doctor
        public DoctorController()
        {
            db = new Context();
        }
        public ActionResult Index()
        {
            List<Doctor> model = db.Doctors.ToList();
            return View(model);
        }
        [HttpPost]
        public ActionResult Search(string pattern)
        {
            if (string.IsNullOrEmpty(pattern) || string.IsNullOrWhiteSpace(pattern))
            {
                return RedirectToAction("Index");
            }

            List<Doctor> model = db.Doctors.Where
                (x => x.Doctor_name.ToLower().Contains(pattern.ToLower())
                || x.Doctor_surname.ToLower().Contains(pattern.ToLower())
                || x.Doctor_PESEL.Contains(pattern))
                .ToList();

            return View("Index", model);
        }
       
        public ActionResult Edit(int Doctor_id)
        {
            Doctor model = db.Doctors.Where(x => x.Doctor_id == Doctor_id).FirstOrDefault();

            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(Doctor model)
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
                return RedirectToAction("Edit", new { @Doctor_id = model.Doctor_id});
            }
            Doctor old = db.Doctors.Single(x => x.Doctor_id == model.Doctor_id);
            db.Entry(old).State = System.Data.Entity.EntityState.Modified;
            old.Doctor_name = model.Doctor_name;
            old.Doctor_surname = model.Doctor_surname;
            db.SaveChanges();

            return RedirectToAction("Index");
        }


    }
}