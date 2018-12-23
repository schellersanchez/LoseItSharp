namespace LoseItSharp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDbSet : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.MatchApplicationUsers", newName: "ApplicationUserMatches");
            DropPrimaryKey("dbo.ApplicationUserMatches");
            AddPrimaryKey("dbo.ApplicationUserMatches", new[] { "ApplicationUser_Id", "Match_Id" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.ApplicationUserMatches");
            AddPrimaryKey("dbo.ApplicationUserMatches", new[] { "Match_Id", "ApplicationUser_Id" });
            RenameTable(name: "dbo.ApplicationUserMatches", newName: "MatchApplicationUsers");
        }
    }
}
