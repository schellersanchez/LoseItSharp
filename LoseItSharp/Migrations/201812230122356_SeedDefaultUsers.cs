namespace LoseItSharp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedDefaultUsers : DbMigration
    {
        public override void Up()
        {
            //Insert Administrator Role
            Sql(@"
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'a4ac5b9f-620a-42c1-b6e5-b0c6ca41ae4e', N'Administrator')");

            //Insert Users
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'03161012-0fe4-4eb8-a090-2ec9f9de82be', N'Admin1@admin1.com', 0, N'AMn5DXSF5PBsJzny8MZIemZ4rTgn56CqOY8C+bxddNdkAkdWK3DCBveZ6CKxSt1IaQ==', N'12d607a6-cc82-470f-83ad-8f414d1ffc17', NULL, 0, 0, NULL, 1, 0, N'Admin1@admin1.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'2ec43abe-8bca-4339-9d51-b55f8bebe8b7', N'Guest1@guest.com', 0, N'APpRivirJHEpe5DfuZ5dFRdfSgmmvHdphWoNyBr+QuVRr96Lxa5rkYZQ4om++ss+xg==', N'dc8b9dc2-f5d3-48db-99ec-0cfcf324ac72', NULL, 0, 0, NULL, 1, 0, N'Guest1@guest.com')
");

            //Assign role to user
            Sql(@"
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'03161012-0fe4-4eb8-a090-2ec9f9de82be', N'a4ac5b9f-620a-42c1-b6e5-b0c6ca41ae4e')
");

        }
        
        public override void Down()
        {
        }
    }
}
