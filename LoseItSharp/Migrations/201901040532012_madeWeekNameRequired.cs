namespace LoseItSharp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class madeWeekNameRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Matches", "MatchName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Matches", "MatchName", c => c.String());
        }
    }
}
