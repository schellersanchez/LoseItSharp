using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LoseItSharp.Models;

namespace LoseItSharp.Services
{
    public class WorkingDataAccess : IDataAccess
    {
        private Entities _db = new Entities();

        public void AddCheckIn(string userId, int matchWeekId)
        {
            var checkIn = new CheckIn()
            {
                ApplicationUserId = userId,
                MatchWeekId = matchWeekId,
                CreatedById = userId,
                CreatedDate = DateTime.Now,
                LastModifiedDate = DateTime.Now,
                Weight = 0
            };

            _db.CheckIns.Add(checkIn);
            _db.SaveChanges();
        }

        public Match AddMatch(string matchName, DateTime matchStart, DateTime matchEnd, int numberOfWeeks, string createdById, string matchInfo)
        {
            var match = new Match()
            {
                MatchName = matchName,
                MatchStart = matchStart,
                MatchEnd = matchEnd,
                NumberOfWeeks = numberOfWeeks,
                CreatedById = createdById,
                Info = matchInfo
            };

            _db.Matches.Add(match);
            _db.SaveChanges();

            return match;
        }

        public void AddMatchWeek(DateTime startDate, DateTime endDate, int weekNumber, int matchId)
        {
            var matchWeek = new MatchWeek()
            {
                StartDate = startDate,
                EndDate = endDate,
                WeekNumber = weekNumber,
                MatchId = matchId
            };

            _db.MatchWeeks.Add(matchWeek);
        }

        public void AddParticipant(string userId, int matchId, bool isMatchAdmin)
        {
            var participant = new Participant()
            {
                ApplicationUserId = userId,
                MatchId = matchId,
                IsMatchAdmin = isMatchAdmin
            };

            _db.Participants.Add(participant);
            _db.SaveChanges();
        }

        public List<CheckIn> GetAllCheckInsForWeek(int matchWeekId)
        {
            var checkIns = _db.CheckIns.Where(c => c.MatchWeekId == matchWeekId).ToList();
            return checkIns;
        }

        public List<Match> GetAllMatches()
        {
            return _db.Matches.ToList();
        }

        public List<MatchWeek> GetAllMatchWeeksInMatch(int matchId)
        {
            return _db.MatchWeeks.Where(mw => mw.MatchId == matchId).ToList();
        }

        public List<Participant> GetAllParticipantsInMatch(int matchId)
        {
            return _db.Participants.Where(p => p.MatchId == matchId).ToList();
        }

        public CheckIn GetCheckIn(int checkInId)
        {
            return _db.CheckIns.Find(checkInId);
        }

        public List<CheckIn> GetCheckInsForUser(string userId)
        {
            return _db.CheckIns.Where(c => c.ApplicationUserId == userId).ToList();
        }

        public Match GetMatch(int matchId)
        {
            return _db.Matches.Find(matchId);
        }

        public MatchWeek GetMatchWeek(int matchWeekId)
        {
            return _db.MatchWeeks.Find(matchWeekId);
        }

        public Participant GetParticipant(int participantId)
        {
            return _db.Participants.Find(participantId);
        }

        public AspNetUser GetUser(string userId)
        {
            return _db.AspNetUsers.Where(u => u.Id == userId).FirstOrDefault();
        }

        public void UpdateCheckIn(int checkInId, DateTime lastModifiedDate, float weight)
        {
            var checkIn = _db.CheckIns.Find(checkInId);
            checkIn.LastModifiedDate = lastModifiedDate;
            checkIn.Weight = weight;

            _db.SaveChanges();
        }
    }
}