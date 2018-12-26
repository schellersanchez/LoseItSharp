namespace LoseItSharp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialSeed : DbMigration
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
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'36bbde77-a960-46fe-b339-d32624a5f1b6', N'AnotherPerson1@AnotherPerson1.com', 0, N'AHOFdRCLYowcl+UC6J1K+de+UMJx//SQ35sQkmj4NGGFpbAumIZOwQMkvGNPQgiXVg==', N'1030b007-dd00-4d79-914b-9ee8870a9b3b', NULL, 0, 0, NULL, 1, 0, N'AnotherPerson1@AnotherPerson1.com')

");

            //Assign role to user
            Sql(@"
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'03161012-0fe4-4eb8-a090-2ec9f9de82be', N'a4ac5b9f-620a-42c1-b6e5-b0c6ca41ae4e')
");

            //Create matches
            Sql(@"
SET IDENTITY_INSERT [dbo].[Matches] ON
INSERT INTO [dbo].[Matches] ([Id], [MatchStart], [MatchEnd], [NumberOfWeeks], [MatchName], [CreatedById]) VALUES (1, N'2018-12-30 00:00:00', N'2019-02-09 23:59:00', 6, N'First Match', N'2ec43abe-8bca-4339-9d51-b55f8bebe8b7')
INSERT INTO [dbo].[Matches] ([Id], [MatchStart], [MatchEnd], [NumberOfWeeks], [MatchName], [CreatedById]) VALUES (2, N'2018-12-30 00:00:00', N'2019-02-23 23:59:00', 8, N'Second Match', N'36bbde77-a960-46fe-b339-d32624a5f1b6')
SET IDENTITY_INSERT [dbo].[Matches] OFF

");

            //Create MatchWeeks
            Sql(@"
SET IDENTITY_INSERT [dbo].[MatchWeeks] ON
INSERT INTO [dbo].[MatchWeeks] ([Id], [StartDate], [EndDate], [WeekNumber], [MatchId]) VALUES (1, N'2018-12-30 00:00:00', N'2019-01-05 23:59:00', 1, 1)
INSERT INTO [dbo].[MatchWeeks] ([Id], [StartDate], [EndDate], [WeekNumber], [MatchId]) VALUES (2, N'2019-01-06 00:00:00', N'2019-01-12 23:59:00', 2, 1)
INSERT INTO [dbo].[MatchWeeks] ([Id], [StartDate], [EndDate], [WeekNumber], [MatchId]) VALUES (3, N'2019-01-13 00:00:00', N'2019-01-19 23:59:00', 3, 1)
INSERT INTO [dbo].[MatchWeeks] ([Id], [StartDate], [EndDate], [WeekNumber], [MatchId]) VALUES (4, N'2019-01-20 00:00:00', N'2019-01-26 23:59:00', 4, 1)
INSERT INTO [dbo].[MatchWeeks] ([Id], [StartDate], [EndDate], [WeekNumber], [MatchId]) VALUES (5, N'2019-01-27 00:00:00', N'2019-02-02 23:59:00', 5, 1)
INSERT INTO [dbo].[MatchWeeks] ([Id], [StartDate], [EndDate], [WeekNumber], [MatchId]) VALUES (6, N'2019-02-03 00:00:00', N'2019-02-09 23:59:00', 6, 1)
INSERT INTO [dbo].[MatchWeeks] ([Id], [StartDate], [EndDate], [WeekNumber], [MatchId]) VALUES (7, N'2018-12-30 00:00:00', N'2019-01-05 23:59:00', 1, 2)
INSERT INTO [dbo].[MatchWeeks] ([Id], [StartDate], [EndDate], [WeekNumber], [MatchId]) VALUES (8, N'2019-01-06 00:00:00', N'2019-01-12 23:59:00', 2, 2)
INSERT INTO [dbo].[MatchWeeks] ([Id], [StartDate], [EndDate], [WeekNumber], [MatchId]) VALUES (9, N'2019-01-13 00:00:00', N'2019-01-19 23:59:00', 3, 2)
INSERT INTO [dbo].[MatchWeeks] ([Id], [StartDate], [EndDate], [WeekNumber], [MatchId]) VALUES (10, N'2019-01-20 00:00:00', N'2019-01-26 23:59:00', 4, 2)
INSERT INTO [dbo].[MatchWeeks] ([Id], [StartDate], [EndDate], [WeekNumber], [MatchId]) VALUES (11, N'2019-01-27 00:00:00', N'2019-02-02 23:59:00', 5, 2)
INSERT INTO [dbo].[MatchWeeks] ([Id], [StartDate], [EndDate], [WeekNumber], [MatchId]) VALUES (12, N'2019-02-03 00:00:00', N'2019-02-09 23:59:00', 6, 2)
INSERT INTO [dbo].[MatchWeeks] ([Id], [StartDate], [EndDate], [WeekNumber], [MatchId]) VALUES (13, N'2019-02-10 00:00:00', N'2019-02-16 23:59:00', 7, 2)
INSERT INTO [dbo].[MatchWeeks] ([Id], [StartDate], [EndDate], [WeekNumber], [MatchId]) VALUES (14, N'2019-02-17 00:00:00', N'2019-02-23 23:59:00', 8, 2)
SET IDENTITY_INSERT [dbo].[MatchWeeks] OFF

");
            //Create Participants
            Sql(@"
SET IDENTITY_INSERT [dbo].[Participants] ON
INSERT INTO [dbo].[Participants] ([Id], [IsMatchAdmin], [MatchId], [ApplicationUserId]) VALUES (1, 1, 1, N'2ec43abe-8bca-4339-9d51-b55f8bebe8b7')
INSERT INTO [dbo].[Participants] ([Id], [IsMatchAdmin], [MatchId], [ApplicationUserId]) VALUES (2, 1, 2, N'36bbde77-a960-46fe-b339-d32624a5f1b6')
INSERT INTO [dbo].[Participants] ([Id], [IsMatchAdmin], [MatchId], [ApplicationUserId]) VALUES (3, 1, 1, N'36bbde77-a960-46fe-b339-d32624a5f1b6')
SET IDENTITY_INSERT [dbo].[Participants] OFF

");

            //Create Checkins
            Sql(@"
SET IDENTITY_INSERT [dbo].[CheckIns] ON
INSERT INTO [dbo].[CheckIns] ([Id], [CreatedDate], [LastModifiedDate], [CreatedById], [Weight], [ApplicationUserId], [MatchWeekId]) VALUES (1, N'2018-12-25 14:27:40', N'2018-12-25 14:27:40', NULL, 0, N'2ec43abe-8bca-4339-9d51-b55f8bebe8b7', 1)
INSERT INTO [dbo].[CheckIns] ([Id], [CreatedDate], [LastModifiedDate], [CreatedById], [Weight], [ApplicationUserId], [MatchWeekId]) VALUES (2, N'2018-12-25 14:27:40', N'2018-12-25 14:27:40', NULL, 0, N'2ec43abe-8bca-4339-9d51-b55f8bebe8b7', 2)
INSERT INTO [dbo].[CheckIns] ([Id], [CreatedDate], [LastModifiedDate], [CreatedById], [Weight], [ApplicationUserId], [MatchWeekId]) VALUES (3, N'2018-12-25 14:27:40', N'2018-12-25 14:27:40', NULL, 0, N'2ec43abe-8bca-4339-9d51-b55f8bebe8b7', 3)
INSERT INTO [dbo].[CheckIns] ([Id], [CreatedDate], [LastModifiedDate], [CreatedById], [Weight], [ApplicationUserId], [MatchWeekId]) VALUES (4, N'2018-12-25 14:27:40', N'2018-12-25 14:27:40', NULL, 0, N'2ec43abe-8bca-4339-9d51-b55f8bebe8b7', 4)
INSERT INTO [dbo].[CheckIns] ([Id], [CreatedDate], [LastModifiedDate], [CreatedById], [Weight], [ApplicationUserId], [MatchWeekId]) VALUES (5, N'2018-12-25 14:27:40', N'2018-12-25 14:27:40', NULL, 0, N'2ec43abe-8bca-4339-9d51-b55f8bebe8b7', 5)
INSERT INTO [dbo].[CheckIns] ([Id], [CreatedDate], [LastModifiedDate], [CreatedById], [Weight], [ApplicationUserId], [MatchWeekId]) VALUES (6, N'2018-12-25 14:27:40', N'2018-12-25 14:27:40', NULL, 0, N'2ec43abe-8bca-4339-9d51-b55f8bebe8b7', 6)
INSERT INTO [dbo].[CheckIns] ([Id], [CreatedDate], [LastModifiedDate], [CreatedById], [Weight], [ApplicationUserId], [MatchWeekId]) VALUES (7, N'2018-12-25 14:29:42', N'2018-12-25 14:29:42', NULL, 0, N'36bbde77-a960-46fe-b339-d32624a5f1b6', 7)
INSERT INTO [dbo].[CheckIns] ([Id], [CreatedDate], [LastModifiedDate], [CreatedById], [Weight], [ApplicationUserId], [MatchWeekId]) VALUES (8, N'2018-12-25 14:29:42', N'2018-12-25 14:29:42', NULL, 0, N'36bbde77-a960-46fe-b339-d32624a5f1b6', 8)
INSERT INTO [dbo].[CheckIns] ([Id], [CreatedDate], [LastModifiedDate], [CreatedById], [Weight], [ApplicationUserId], [MatchWeekId]) VALUES (9, N'2018-12-25 14:29:42', N'2018-12-25 14:29:42', NULL, 0, N'36bbde77-a960-46fe-b339-d32624a5f1b6', 9)
INSERT INTO [dbo].[CheckIns] ([Id], [CreatedDate], [LastModifiedDate], [CreatedById], [Weight], [ApplicationUserId], [MatchWeekId]) VALUES (10, N'2018-12-25 14:29:42', N'2018-12-25 14:29:42', NULL, 0, N'36bbde77-a960-46fe-b339-d32624a5f1b6', 10)
INSERT INTO [dbo].[CheckIns] ([Id], [CreatedDate], [LastModifiedDate], [CreatedById], [Weight], [ApplicationUserId], [MatchWeekId]) VALUES (11, N'2018-12-25 14:29:42', N'2018-12-25 14:29:42', NULL, 0, N'36bbde77-a960-46fe-b339-d32624a5f1b6', 11)
INSERT INTO [dbo].[CheckIns] ([Id], [CreatedDate], [LastModifiedDate], [CreatedById], [Weight], [ApplicationUserId], [MatchWeekId]) VALUES (12, N'2018-12-25 14:29:42', N'2018-12-25 14:29:42', NULL, 0, N'36bbde77-a960-46fe-b339-d32624a5f1b6', 12)
INSERT INTO [dbo].[CheckIns] ([Id], [CreatedDate], [LastModifiedDate], [CreatedById], [Weight], [ApplicationUserId], [MatchWeekId]) VALUES (13, N'2018-12-25 14:29:42', N'2018-12-25 14:29:42', NULL, 0, N'36bbde77-a960-46fe-b339-d32624a5f1b6', 13)
INSERT INTO [dbo].[CheckIns] ([Id], [CreatedDate], [LastModifiedDate], [CreatedById], [Weight], [ApplicationUserId], [MatchWeekId]) VALUES (14, N'2018-12-25 14:29:42', N'2018-12-25 14:29:42', NULL, 0, N'36bbde77-a960-46fe-b339-d32624a5f1b6', 14)
INSERT INTO [dbo].[CheckIns] ([Id], [CreatedDate], [LastModifiedDate], [CreatedById], [Weight], [ApplicationUserId], [MatchWeekId]) VALUES (15, N'2018-12-25 14:29:46', N'2018-12-25 14:29:46', NULL, 0, N'36bbde77-a960-46fe-b339-d32624a5f1b6', 1)
INSERT INTO [dbo].[CheckIns] ([Id], [CreatedDate], [LastModifiedDate], [CreatedById], [Weight], [ApplicationUserId], [MatchWeekId]) VALUES (16, N'2018-12-25 14:29:46', N'2018-12-25 14:29:46', NULL, 0, N'36bbde77-a960-46fe-b339-d32624a5f1b6', 2)
INSERT INTO [dbo].[CheckIns] ([Id], [CreatedDate], [LastModifiedDate], [CreatedById], [Weight], [ApplicationUserId], [MatchWeekId]) VALUES (17, N'2018-12-25 14:29:46', N'2018-12-25 14:29:46', NULL, 0, N'36bbde77-a960-46fe-b339-d32624a5f1b6', 3)
INSERT INTO [dbo].[CheckIns] ([Id], [CreatedDate], [LastModifiedDate], [CreatedById], [Weight], [ApplicationUserId], [MatchWeekId]) VALUES (18, N'2018-12-25 14:29:46', N'2018-12-25 14:29:46', NULL, 0, N'36bbde77-a960-46fe-b339-d32624a5f1b6', 4)
INSERT INTO [dbo].[CheckIns] ([Id], [CreatedDate], [LastModifiedDate], [CreatedById], [Weight], [ApplicationUserId], [MatchWeekId]) VALUES (19, N'2018-12-25 14:29:46', N'2018-12-25 14:29:46', NULL, 0, N'36bbde77-a960-46fe-b339-d32624a5f1b6', 5)
INSERT INTO [dbo].[CheckIns] ([Id], [CreatedDate], [LastModifiedDate], [CreatedById], [Weight], [ApplicationUserId], [MatchWeekId]) VALUES (20, N'2018-12-25 14:29:46', N'2018-12-25 14:29:46', NULL, 0, N'36bbde77-a960-46fe-b339-d32624a5f1b6', 6)
SET IDENTITY_INSERT [dbo].[CheckIns] OFF

");
        }
        
        public override void Down()
        {
        }
    }
}
