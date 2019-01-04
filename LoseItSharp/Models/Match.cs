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

        [Display(Name = "Start Date")]
        public DateTime MatchStart { get; set; }

        [Display(Name="End Date")]
        public DateTime MatchEnd { get; set; }

        [Display(Name ="Number of Weeks")]
        public int NumberOfWeeks { get; set; }

        [Required]
        [Display(Name ="Match Name")]
        public string MatchName { get; set; }

        public string CreatedById { get; set; }

        // Relationships
        public List<Participant> Participants { get; set; }
        public List<MatchWeek> MatchWeeks { get; set; }
    }
}