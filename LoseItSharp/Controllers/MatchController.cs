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

        [HttpPost]
        public string Join(string Id)
        {
            //TODO: join

            //check if user is logged in
            if (!User.Identity.IsAuthenticated)
            {
                ViewBag.Message = "Please Log in before joining";
                return "Please Log in before joining";
            }

            int matchId = 0;
            try
            {
                matchId = Int32.Parse(Id);
            }
            catch
            {
                return "Please select a valid match";
            }

            Match matchInDb = _db.Matches.Find(matchId);
            //add to aplicationusermatch table




            ViewBag.Result = "Successfully joined " + matchInDb.MatchName;
            return "successfully joined" + matchInDb.MatchName;
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

            //TODO: create match weeks

            return RedirectToAction("Index");
        }

    }
}