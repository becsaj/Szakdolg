namespace Szakdolg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Munkas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nev = c.String(),
                        Img = c.String(),
                        Elkeszult = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sablonoks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Megnevezes = c.String(),
                        Img = c.String(),
                        Ar = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Sablonoks");
            DropTable("dbo.Munkas");
        }
    }
}
