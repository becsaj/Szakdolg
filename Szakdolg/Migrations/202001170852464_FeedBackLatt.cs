namespace Szakdolg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FeedBackLatt : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FeedBacks", "Lattamozott", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.FeedBacks", "Lattamozott");
        }
    }
}
