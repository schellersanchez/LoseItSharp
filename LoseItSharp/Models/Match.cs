using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LoseItSharp.Models
{
    public class Match
    {
        public int Id { get; set; }
        public DateTime MatchStart { get; set; }
        public DateTime MatchEnd { get; set; }
        public int NumberOfWeeks { get; set; }

        // Relationships
        public List<ApplicationUser> ApplicationUser { get; set; }
        public List<CheckIn> CheckIns { get; set; }
        public List<MatchWeek> MatchWeeks { get; set; }
    }
}