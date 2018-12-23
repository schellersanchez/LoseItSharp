namespace LoseItSharp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialTableMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CheckIns",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MatchId = c.Int(),
                        ApplicationUserId = c.String(maxLength: 128),
                        MatchWeekId = c.Int(),
                        DateStamp = c.DateTime(nullable: false),
                        Weight = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .ForeignKey("dbo.Matches", t => t.MatchId)
                .ForeignKey("dbo.MatchWeeks", t => t.MatchWeekId)
                .Index(t => t.MatchId)
                .Index(t => t.ApplicationUserId)
                .Index(t => t.MatchWeekId);
            
            CreateTable(
                "dbo.Matches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MatchStart = c.DateTime(nullable: false),
                        MatchEnd = c.DateTime(nullable: false),
                        NumberOfWeeks = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MatchWeeks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MatchId = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        WeekNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Matches", t => t.MatchId, cascadeDelete: true)
                .Index(t => t.MatchId);
            
            CreateTable(
                "dbo.MatchApplicationUsers",
                c => new
                    {
                        Match_Id = c.Int(nullable: false),
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Match_Id, t.ApplicationUser_Id })
                .ForeignKey("dbo.Matches", t => t.Match_Id, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id, cascadeDelete: true)
                .Index(t => t.Match_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MatchWeeks", "MatchId", "dbo.Matches");
            DropForeignKey("dbo.CheckIns", "MatchWeekId", "dbo.MatchWeeks");
            DropForeignKey("dbo.CheckIns", "MatchId", "dbo.Matches");
            DropForeignKey("dbo.MatchApplicationUsers", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.MatchApplicationUsers", "Match_Id", "dbo.Matches");
            DropForeignKey("dbo.CheckIns", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.MatchApplicationUsers", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.MatchApplicationUsers", new[] { "Match_Id" });
            DropIndex("dbo.MatchWeeks", new[] { "MatchId" });
            DropIndex("dbo.CheckIns", new[] { "MatchWeekId" });
            DropIndex("dbo.CheckIns", new[] { "ApplicationUserId" });
            DropIndex("dbo.CheckIns", new[] { "MatchId" });
            DropTable("dbo.MatchApplicationUsers");
            DropTable("dbo.MatchWeeks");
            DropTable("dbo.Matches");
            DropTable("dbo.CheckIns");
        }
    }
}
