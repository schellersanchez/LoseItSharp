using LoseItSharp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

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
            ApplicationUser au = new ApplicationUser();
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
            //Check if user is logged in
            if (!User.Identity.IsAuthenticated)
            {
                ViewBag.Message = "Please log in to create";
                return View(Model);
            }

            //Validate form
            if (!ModelState.IsValid)
            {
                return View(Model);
            }
            
            //Get current user
            string currentUserId = User.Identity.GetUserId();
            ApplicationUser userInDb = _db.Users.Find(currentUserId);

            //Create new Match
            Match newMatch = Model;
            newMatch.CreatedById = currentUserId;
            newMatch.MatchEnd = newMatch.MatchStart.AddDays(newMatch.NumberOfWeeks * 7).AddMinutes(-1); //11:59pm
            _db.Matches.Add(Model);
            _db.SaveChanges();

            //Add current user to match
            Participant participant = new Participant()
            {
                Match = newMatch,
                ApplicationUser = userInDb,
                IsMatchAdmin = true,
            };
            _db.Participants.Add(participant);
            _db.SaveChanges();

            //Create MatchWeeks
            DateTime weekStart = Model.MatchStart;
            DateTime weekEnd = weekStart.AddDays(7).AddMinutes(-1); //11:59pm
            for(int i = 0; i < Model.NumberOfWeeks; i++)
            {
                MatchWeek mw = new MatchWeek()
                {
                    Match = newMatch,
                    StartDate = weekStart,
                    EndDate = weekEnd,
                    WeekNumber = i + 1
                };
                _db.MatchWeeks.Add(mw);
                weekStart.AddDays(7);
                weekEnd.AddDays(7);
            }

            _db.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}