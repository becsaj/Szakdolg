namespace Szakdolg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using Szakdolg.Models;

    public partial class Roles : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO[dbo].[AspNetUsers]([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [Datum], [Keresztnev], [Vezeteknev]) VALUES(N'bd544945-4fab-4854-ad02-3687dca56224', N'becsajovszki@gmail.com', 0, N'AFH6uR3UvKbTAmQ7kQRoWIGQ2MxLLu/RsIjSE2ULayJwIhg98a7IaE407MW+dom8KQ==', N'6f036658-1190-48c6-ac0f-2a79794d0bd3', NULL, 0, 0, NULL, 1, 0, N'becsajovszki@gmail.com', N'2000-02-04 00:00:00', N'becsajovszki@gmail.com', N'becsajovszki@gmail.com')");
            Sql($"INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'14b8717d-2197-41bb-b340-7a125d657a08', N'{RoleNevek.Admin}')");
            Sql("INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'bd544945-4fab-4854-ad02-3687dca56224', N'14b8717d-2197-41bb-b340-7a125d657a08')");




        }

        public override void Down()
        {
        }
    }
}
