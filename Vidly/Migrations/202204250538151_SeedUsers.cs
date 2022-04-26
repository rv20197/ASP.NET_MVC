namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'206ad285-aae3-4f51-9997-0d4ade17e77f', N'admin@test.com', 0, N'APNiGUjVwpKABXAyLPCYrgef/SL2x2+4RBzMfV5lxBwLyvf2IKH6yYbbRycOuX8Dlw==', N'0260186e-bf9e-4f3e-91b0-7429f964dfd2', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'5d648357-619f-4924-9a64-f54b5a79ff94', N'CanManageMovies')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'206ad285-aae3-4f51-9997-0d4ade17e77f', N'5d648357-619f-4924-9a64-f54b5a79ff94')");
        }

        public override void Down()
        {
        }
    }
}
