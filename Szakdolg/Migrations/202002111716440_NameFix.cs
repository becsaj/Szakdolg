namespace Szakdolg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NameFix : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.FeedBacks", "Velemeny", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.FeedBacks", "Velemeny", c => c.String(nullable: false));
        }
    }
}
