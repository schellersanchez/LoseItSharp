namespace LoseItSharp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedAdditionalFieldsToMatch : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Matches", "MatchName", c => c.String());
            AddColumn("dbo.Matches", "CreatedById", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Matches", "CreatedById");
            DropColumn("dbo.Matches", "MatchName");
        }
    }
}
