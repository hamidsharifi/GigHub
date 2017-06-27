namespace GigHub.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class test : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.UserNotifications", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.UserNotifications", "ApplicationUser_Id");
        }
        
        public override void Down()
        {
        }
    }
}
