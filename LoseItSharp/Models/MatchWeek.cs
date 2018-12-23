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
        [Key]
        public int Id { get; set; }
        public int MatchId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int WeekNumber { get; set; }

        // Relationships
        public List<CheckIn> CheckIns { get; set; }

    }
}