using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LoseItSharp.Models
{
    public class CheckIn
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public string CreatedById { get; set; }
        public float Weight { get; set; }

        //Relationships
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public int? MatchWeekId { get; set; }
        public MatchWeek MatchWeek { get; set; }
    }
}