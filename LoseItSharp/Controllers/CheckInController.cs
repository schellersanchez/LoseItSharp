using LoseItSharp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace LoseItSharp.Controllers
{
    public class CheckInController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        // GET: CheckIn
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Match");
        }

        [HttpGet]
        public ActionResult Update(int Id)
        {
            CheckIn checkInInDb = _db.CheckIns.Include("Matchweek").FirstOrDefault(c=>c.Id == Id);
            if(checkInInDb == null)
            {
                return RedirectToAction("Index", "Match", new { @Message = "Match not found" });
            }
            // Load match data
            checkInInDb.MatchWeek.Match = _db.Matches.Find(checkInInDb.MatchWeek.MatchId);
           
            return View(checkInInDb);
        }

        [HttpPost]
        public ActionResult Update(CheckIn Model)
        {
            //Load relationships
            Model.MatchWeek = _db.MatchWeeks.Include("Match").FirstOrDefault(m=>m.Id == Model.MatchWeekId);

            //Validate model
            if (!ModelState.IsValid)
            {
                return View(Model);
            }

            //Validate user
            string loggedInUser = User.Identity.GetUserId();
            if(!string.Equals(Model.ApplicationUserId, loggedInUser))
            {
                ViewBag.Message = "You do not have access to update this check in";
                return View(Model);
            }

            //Update check in
            CheckIn checkInInDb = _db.CheckIns.Find(Model.Id);
            checkInInDb.LastModifiedDate = DateTime.Now;
            checkInInDb.Weight = Model.Weight;
            _db.SaveChanges(); 

            int matchId = _db.MatchWeeks.Find(Model.MatchWeekId).MatchId;
            return RedirectToAction("Details", "Match", new { @id = matchId });
        }

    }
}