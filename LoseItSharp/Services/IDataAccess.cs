using LoseItSharp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoseItSharp.Services
{
    public interface IDataAccess
    {
        ApplicationUser GetUser(string userId);
        CheckIn GetCheckIn(int checkInId);
        List<CheckIn> GetAllCheckInsForWeek(int matchWeekId);
        List<CheckIn> GetCheckInsForUser(string userId);
        Match GetMatch(int matchId);
        List<Match> GetAllMatches();
        MatchWeek GetMatchWeek(int matchWeekId);
        List<MatchWeek> GetAllMatchWeeksInMatch(int matchId);
        Participant GetParticipant(int participantId);
        List<Participant> GetAllParticipantsInMatch(int matchId);
        void AddCheckIn(string userId, int matchWeekId);
        void AddParticipant(string userId, int matchId, bool isMatchAdmins);
        Match AddMatch(string matchName, DateTime matchStart, DateTime matchEnd, int numberOfWeeks, string createdById);
        void AddMatchWeek(DateTime startDate, DateTime endDate, int weekNumber, int matchId);
        void UpdateCheckIn(int checkInId, DateTime lastModifiedDate, float weight);
    }
}
