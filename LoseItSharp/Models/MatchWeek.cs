using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LoseItSharp.Models
{
    public class MatchWeek
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int WeekNumber { get; set; }

        // Relationships
        public int MatchId { get; set; }
        public Match Match { get; set; }
        public List<CheckIn> CheckIns { get; set; }

    }
}