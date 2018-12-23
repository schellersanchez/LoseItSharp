using LoseItSharp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoseItSharp.Controllers
{
    public class MatchController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();

        // GET: Match
        public ActionResult Index()
        {
            List<Match> matchesInDb = _db.Matches.ToList();
            return View(matchesInDb);
        }

        public ActionResult Add()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Match Model)
        {
            if (!ModelState.IsValid)
            {
                return View(Model);
            }

            Model.MatchEnd = Model.MatchStart.AddDays(Model.NumberOfWeeks * 7);
            _db.Matches.Add(Model);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}