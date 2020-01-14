namespace Szakdolg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRegister : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Datum", c => c.DateTime());
            AddColumn("dbo.AspNetUsers", "Keresztnev", c => c.String());
            AddColumn("dbo.AspNetUsers", "Vezeteknev", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Vezeteknev");
            DropColumn("dbo.AspNetUsers", "Keresztnev");
            DropColumn("dbo.AspNetUsers", "Datum");
        }
    }
}
