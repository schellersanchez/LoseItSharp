﻿using LoseItSharp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using LoseItSharp.Services;

namespace LoseItSharp.Controllers
{
    public class MatchController : Controller
    {
        private Repository _repository;

        public MatchController()
        {
            _repository = new Repository();
        }

        public MatchController(IDataAccess dataAccess)
        {
            _repository = new Repository(dataAccess);
        }

        // GET: Match
        public ActionResult Index(string Message)
        {
            ViewBag.Message = Message;
            var matches = _repository.GetAllMatches();
            foreach(var match in matches)
            {
                match.Participants = _repository.GetAllParticipantsInMatch(match.Id);
            }
            return View(matches);
        }
        /// <summary>
        /// Join a match through an ajax call
        /// </summary>
        /// <param name="Id">Match Id</param>
        /// <returns></returns>
        [HttpPost]
        public string Join(string Id)
        {
            //check if user is logged in
            if (!User.Identity.IsAuthenticated)
            {
                ViewBag.Message = "Please Log in before joining";
                return "Please Log in before joining";
            }

            //Validate matchId
            int matchId = 0;
            try
            {
                matchId = Int32.Parse(Id);
            }
            catch
            {
                return "Please select a valid match";
            }

            //Validate Match
            var matchInDb = _repository.GetMatch(matchId);
            if(matchInDb == null)
            {
                return "Match not found";
            }

            //Validate if user already joined match
            if (_repository.IsUserInMatch(User.Identity.GetUserId(), matchId))
            {
                return "You've already joined this match";
            }

            //Join match
            _repository.JoinMatch(User.Identity.GetUserId(), matchId, false);

            ViewBag.Result = "Successfully joined " + matchInDb.MatchName;
            return "Successfully joined" + matchInDb.MatchName; ;
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
                return RedirectToAction("Login", "Account", new { @returnUrl = "/match/add" });
            }

            //Validate form
            if (!ModelState.IsValid)
            {
                return View(Model);
            }

            //Create match
            _repository.CreateMatch(Model.MatchStart, Model.NumberOfWeeks, Model.MatchName, User.Identity.GetUserId(), Model.Info);

            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult Details(int? id)
        {
            if(id == null)
            {
                return RedirectToAction("Index", "Match", new { @message = "Match not found.  Match Id missing." });
            }

            var matchId = Int32.Parse(id.ToString());

            var model = _repository.GetMatch(matchId);
            if (model == null)
            {
                return RedirectToAction("Index", "Match", new { @message = "Match not found." });
            }

            //load participants
            model.Participants = _repository.GetAllParticipantsInMatch(matchId);
            foreach(var participant in model.Participants)
            {
                participant.AspNetUser = _repository.GetUser(participant.ApplicationUserId);
                participant.AspNetUser.CheckIns = _repository.GetCheckInsForUser(participant.ApplicationUserId, matchId);
                //participant.Match = _repository.GetMatch(participant.MatchId);
            }

            //load matchweeks
            model.MatchWeeks = _repository.GetAllMatchWeeksInMatch(matchId);
            //                @foreach(var checkin in item.ApplicationUser.CheckIns.OrderBy(c => c.CreatedDate))


            return View(model);
        }

    }
}