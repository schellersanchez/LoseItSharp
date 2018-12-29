﻿using LoseItSharp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoseItSharp.Services
{
    public class Repository
    {
        private IDataAccess _dataAccess;

        public Repository()
        {
            _dataAccess = new WorkingDataAccess();
        }

        public Repository(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public Match GetMatch(int matchId)
        {
            return _dataAccess.GetMatch(matchId);
        }

        public List<Match> GetAllMatches()
        {
            return _dataAccess.GetAllMatches();
        }

        public List<Participant> GetAllParticipantsInMatch(int matchId)
        {

            return _dataAccess.GetAllParticipantsInMatch(matchId);
        }

        public List<MatchWeek> GetAllMatchWeeks(int matchId)
        {
            return _dataAccess.GetAllMatchWeeksInMatch(matchId); ;
        }

        public List<CheckIn> GetCheckInsForMatchWeek(int matchWeekId)
        {
            return _dataAccess.GetAllCheckInsForWeek(matchWeekId);
        }

        public bool IsUserInMatch(string userId, int matchId)
        {
            var match = _dataAccess.GetMatch(matchId);
            var participant = match.Participants.Where(p => p.MatchId == matchId).Where(p => p.ApplicationUserId == userId);

            return participant == null ? false : true;
        }

        public void JoinMatch(string userId, int matchId, bool isAdmin)
        {
            _dataAccess.AddParticipant(userId, matchId, isAdmin);
        }

        public void CreateMatch(DateTime matchStart, int numberOfWeeks, string matchName, string userId)
        {
            var matchEnd = matchStart.AddDays(7).AddMinutes(-1); //11:59pm
            _dataAccess.AddMatch(matchName, matchStart, matchEnd, numberOfWeeks, userId);

        }

        public CheckIn GetCheckIn(int checkInId)
        {
            var checkIn = _dataAccess.GetCheckIn(checkInId);
            checkIn.MatchWeek = GetMatchWeek(checkIn.MatchWeekId);
            return checkIn;
        }

        public MatchWeek GetMatchWeek(int? matchWeekId)
        {
            int mwId = Int32.Parse(matchWeekId.ToString()); //idk fix this later maybe
            var matchWeek = _dataAccess.GetMatchWeek(mwId);
            matchWeek.Match = GetMatch(matchWeek.MatchId);
            return matchWeek;
        }

        public void UpdateCheckIn(int checkInId, float weight)
        {
            _dataAccess.UpdateCheckIn(checkInId, DateTime.Now, weight);
        }

        public ApplicationUser GetUser (string userId)
        {
            return _dataAccess.GetUser(userId);
        }

        public List<MatchWeek> GetAllMatchWeeksInMatch(int matchId)
        {
            return _dataAccess.GetAllMatchWeeksInMatch(matchId);
        }

        public List<CheckIn> GetCheckInsForUser(string userId)
        {
            var checkIns = _dataAccess.GetCheckInsForUser(userId);
            foreach(var checkIn in checkIns)
            {
                checkIn.MatchWeek = GetMatchWeek(checkIn.MatchWeekId);
            }
            return checkIns;
        }

        public List<CheckIn> GetCheckInsForUser(string userId, int matchId)
        {
            return  GetCheckInsForUser(userId).Where(c => c.MatchWeek.MatchId == matchId).ToList();
        }
    }
}