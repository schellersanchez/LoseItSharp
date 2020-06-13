using LoseItSharp.Models;
using LoseItSharp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoseItSharp.Tests
{
    class MockDataAccess : IDataAccess
    {
        private List<CheckIn> _allCheckIns = new List<CheckIn>();
        private List<MatchWeek> _allMatchWeeks = new List<MatchWeek>();
        private List<Match> _allMatches = new List<Match>();


        public void AddCheckIn(string userId, int matchWeekId)
        {
            throw new NotImplementedException();
        }

        public Match AddMatch(string matchName, DateTime matchStart, DateTime matchEnd, int numberOfWeeks, string createdById, string matchInfo)
        {
            throw new NotImplementedException();
        }

        public void AddMatchWeek(DateTime startDate, DateTime endDate, int weekNumber, int matchId)
        {
            throw new NotImplementedException();
        }

        public void AddParticipant(string userId, int matchId, bool isMatchAdmins)
        {
            throw new NotImplementedException();
        }

        public List<CheckIn> GetAllCheckInsForWeek(int matchWeekId)
        {
            throw new NotImplementedException();
        }

        public List<Match> GetAllMatches()
        {
            throw new NotImplementedException();
        }

        public List<MatchWeek> GetAllMatchWeeksInMatch(int matchId)
        {
            throw new NotImplementedException();
        }

        public List<Participant> GetAllParticipantsInMatch(int matchId)
        {
            throw new NotImplementedException();
        }

        public CheckIn GetCheckIn(int checkInId)
        {
            throw new NotImplementedException();
        }

        public List<CheckIn> GetCheckInsForUser(string userId)
        {
            throw new NotImplementedException();
        }

        public Match GetMatch(int matchId)
        {
            return _allMatches.Where(m => m.Id == matchId).FirstOrDefault();
        }

        public MatchWeek GetMatchWeek(int matchWeekId)
        {
            return _allMatchWeeks.Where(m => m.Id == matchWeekId).FirstOrDefault();
        }

        public Participant GetParticipant(int participantId)
        {
            throw new NotImplementedException();
        }

        public AspNetUser GetUser(string userId)
        {
            throw new NotImplementedException();
        }

        public void UpdateCheckIn(int checkInId, DateTime lastModifiedDate, float weight)
        {
            throw new NotImplementedException();
        }

        public MockDataAccess()
        {
            //Mock match
            Match match1 = new Match()
            {
                CreatedById = "scheller",
                Id = 1,
                Info = "Match 1 Info",
                MatchEnd = new DateTime(2030, 12, 31),
                MatchStart = new DateTime(2020, 01, 01),
                MatchName = "Match 1"
            };

            //Mock matchweek
            MatchWeek match1Week1 = new MatchWeek()
            {
                Id = 1,
                StartDate = new DateTime(2020, 01, 01),
                EndDate = new DateTime(2020, 01, 06),
                MatchId = 1,
                WeekNumber = 1
            };

            MatchWeek match1Week2 = new MatchWeek()
            {
                Id = 2,
                StartDate = new DateTime(2020, 01, 07),
                EndDate = new DateTime(2020, 01, 14),
                MatchId = 1,
                WeekNumber = 2
            };

            //Mock CheckIns
            CheckIn checkIn1 = new CheckIn()
            {
                Id = 1,
                CreatedDate = new DateTime(2020, 01, 02),
                LastModifiedDate = new DateTime(2020, 01, 02),
                CreatedById = "player1",
                Weight = 200,
                ApplicationUserId = "player1",
                MatchWeekId = 1
            };

            CheckIn checkIn2 = new CheckIn()
            {
                Id = 2,
                CreatedDate = new DateTime(2020, 01, 08),
                LastModifiedDate = new DateTime(2020, 01, 09),
                CreatedById = "player1",
                Weight = 199,
                ApplicationUserId = "player1",
                MatchWeekId = 2
            };

            CheckIn checkIn3 = new CheckIn()
            {
                Id = 3,
                CreatedDate = new DateTime(2020, 01, 02),
                LastModifiedDate = new DateTime(2020, 01, 02),
                CreatedById = "player2",
                Weight = 100,
                ApplicationUserId = "player2",
                MatchWeekId = 1
            };

            CheckIn checkIn4 = new CheckIn()
            {
                Id = 4,
                CreatedDate = new DateTime(2020, 01, 08),
                LastModifiedDate = new DateTime(2020, 01, 09),
                CreatedById = "player2",
                Weight = 110,
                ApplicationUserId = "player2",
                MatchWeekId = 2
            };

            
            _allCheckIns.Add(checkIn1);
            _allCheckIns.Add(checkIn2);
            _allCheckIns.Add(checkIn3);
            _allCheckIns.Add(checkIn4);

            
            _allMatchWeeks.Add(match1Week1);
            _allMatchWeeks.Add(match1Week2);

            
            _allMatches.Add(match1);


        }

    }
}
