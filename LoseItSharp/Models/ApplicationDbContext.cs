﻿using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LoseItSharp.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        //public DbSet<Step> Steps { get; set; }
        //public DbSet<CheckIn> CheckIns { get; set; }
        //public DbSet<Match> Matches { get; set; }
        //public DbSet<MatchWeek> MatchWeeks { get; set; }
        //public DbSet<Participant> Participants { get; set; }
        //public DbSet<AspNetUser> AspNetUsers { get; set; }
        //public DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer<ApplicationDbContext>(null);
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }

}