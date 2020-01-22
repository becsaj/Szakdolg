namespace Szakdolg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addKonzulLattam : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Konzuls", "Lattamozott", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Konzuls", "Lattamozott");
        }
    }
}
