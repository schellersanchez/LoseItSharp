using LoseItSharp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using LoseItSharp.Services;

namespace LoseItSharp.Controllers
{
    public class CheckInController : Controller
    {
        private Repository _repsitory;

        public CheckInController()
        {
            _repsitory = new Repository();
        }

        public CheckInController(IDataAccess dataAccess)
        {
            _repsitory = new Repository(dataAccess);
        }

        // GET: CheckIn
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Match");
        }

        [HttpGet]
        public ActionResult Update(int? id)
        {
            if(id == null)
            {
                return RedirectToAction("Index", "Match", new { @Message = "Match not found.  Check in ID missing." });
            }

            var checkInId = Int32.Parse(id.ToString());
            var checkIn = _repsitory.GetCheckIn(checkInId);

            if (checkIn == null)
            {
                return RedirectToAction("Index", "Match", new { @Message = "Match not found" });
            }
            return View(checkIn);
        }

        [HttpPost]
        public ActionResult Update(CheckIn Model)
        {

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
            _repsitory.UpdateCheckIn(Model.Id, Model.Weight);

            var matchWeek = _repsitory.GetMatchWeek(Model.MatchWeekId);
            int matchId = matchWeek.MatchId;
            //int matchId = _db.MatchWeeks.Find(Model.MatchWeekId).MatchId;
            return RedirectToAction("Details", "Match", new { @id = matchId });
        }

    }
}