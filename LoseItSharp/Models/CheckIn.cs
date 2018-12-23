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
        [Key]
        public int Id { get; set; }
        public int? MatchId { get; set; }
        public string ApplicationUserId { get; set; }
        public int? MatchWeekId { get; set; }
        public DateTime DateStamp { get; set; }
        public float Weight { get; set; }


    }
}