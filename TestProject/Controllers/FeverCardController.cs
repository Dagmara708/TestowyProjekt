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
    }



}