namespace GigHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TalaLaptopync : DbMigration
    {
        public override void Up()
        {
            //DropIndex("dbo.UserNotifications", new[] { "UserId" });
            //DropIndex("dbo.UserNotifications", new[] { "ApplicationUser_Id" });
            //DropColumn("dbo.UserNotifications", "UserId");
            RenameColumn(table: "dbo.UserNotifications", name: "ApplicationUser_Id", newName: "UserId");
            //DropPrimaryKey("dbo.UserNotifications");
            AddColumn("dbo.Notifications", "OriginalDateTime", c => c.DateTime());
            AlterColumn("dbo.UserNotifications", "UserId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.UserNotifications", new[] { "UserId", "NotificationId" });
            CreateIndex("dbo.UserNotifications", "UserId");
            DropColumn("dbo.Notifications", "OriginlDateTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Notifications", "OriginlDateTime", c => c.DateTime());
            DropIndex("dbo.UserNotifications", new[] { "UserId" });
            DropPrimaryKey("dbo.UserNotifications");
            AlterColumn("dbo.UserNotifications", "UserId", c => c.String(maxLength: 128));
            DropColumn("dbo.Notifications", "OriginalDateTime");
            AddPrimaryKey("dbo.UserNotifications", new[] { "UserId", "NotificationId" });
            RenameColumn(table: "dbo.UserNotifications", name: "UserId", newName: "ApplicationUser_Id");
            AddColumn("dbo.UserNotifications", "UserId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.UserNotifications", "ApplicationUser_Id");
            CreateIndex("dbo.UserNotifications", "UserId");
        }
    }
}
