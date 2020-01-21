namespace Szakdolg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Konzul : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Konzuls",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nev = c.String(),
                        Ecim = c.String(),
                        Szoveg = c.String(),
                        Datum = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Konzuls");
        }
    }
}
