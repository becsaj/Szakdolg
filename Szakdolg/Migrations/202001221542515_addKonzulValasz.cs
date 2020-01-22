namespace Szakdolg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addKonzulValasz : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Konzuls", "Valasz", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Konzuls", "Valasz");
        }
    }
}
