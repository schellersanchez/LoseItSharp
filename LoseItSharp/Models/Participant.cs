using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoseItSharp.Models
{
    public class Participant
    {
        public int Id { get; set; }
        public bool IsMatchAdmin { get; set; }

        //Relationship
        public int MatchId { get; set; }
        public Match Match { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}