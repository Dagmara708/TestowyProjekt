using System;
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
            List<Example> model = db.Examples.ToList();

            return View(model);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Example model)
        {
            db.Examples.Add(model);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int Id)
        {
            Example model = db.Examples.Where(x => x.Id_pacjenta == Id).FirstOrDefault();

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Example model)
        {
            Example old = db.Examples.Single(x => x.Id_pacjenta == model.Id_pacjenta);
            db.Entry(old).State = System.Data.Entity.EntityState.Modified;
            old.Name = model.Name;
            old.Surname = model.Surname;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int Id)
        {
            Example old = db.Examples.Single(x => x.Id_pacjenta == Id);
            db.Examples.Remove(old);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}