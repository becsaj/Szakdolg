namespace Szakdolg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bemutat : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.FeedBacks", "Nev", c => c.String(nullable: false));
            AlterColumn("dbo.FeedBacks", "Velemeny", c => c.String(nullable: false));
            AlterColumn("dbo.Konzuls", "Nev", c => c.String(nullable: false));
            AlterColumn("dbo.Konzuls", "Ecim", c => c.String(nullable: false));
            AlterColumn("dbo.Konzuls", "Szoveg", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Konzuls", "Szoveg", c => c.String());
            AlterColumn("dbo.Konzuls", "Ecim", c => c.String());
            AlterColumn("dbo.Konzuls", "Nev", c => c.String());
            AlterColumn("dbo.FeedBacks", "Velemeny", c => c.String());
            AlterColumn("dbo.FeedBacks", "Nev", c => c.String());
        }
    }
}
