namespace LoseItSharp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveCheckInFromMatches : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CheckIns", "Match_Id", "dbo.Matches");
            DropIndex("dbo.CheckIns", new[] { "Match_Id" });
            DropColumn("dbo.CheckIns", "Match_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CheckIns", "Match_Id", c => c.Int());
            CreateIndex("dbo.CheckIns", "Match_Id");
            AddForeignKey("dbo.CheckIns", "Match_Id", "dbo.Matches", "Id");
        }
    }
}
