namespace Szakdolg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFeedBack : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FeedBacks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nev = c.String(),
                        Velemeny = c.String(),
                        Datum = c.DateTime(nullable: false),
                        Engedelyezett = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.FeedBacks");
        }
    }
}
