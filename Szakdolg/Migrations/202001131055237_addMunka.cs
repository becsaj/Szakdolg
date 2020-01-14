namespace Szakdolg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addMunka : DbMigration
    {
        public override void Up()
        {
            Sql($"INSERT INTO Munkas(Nev, Img ,Elkeszult) VALUES " +
                $"('Tetko1','tatto1.png','2018-12-10'), " +
                $"('Tetko2','tatto1.png','2019-10-03'), " +
                $"('Tetko3','tatto3.png','2018-07-04'), " +
                $"('Tetko4','tatto4.png','2017-01-29'); ");

            Sql($"INSERT INTO Sablonoks(Megnevezes, Img ,Ar) VALUES " +
               $"('Sablon1','sablon1.png','2000'), " +
               $"('Sablon2','sablon2.png','3000'), " +
               $"('Sablon3','sablon3.png','4000'); ");

        }
        
        public override void Down()
        {
        }
    }
}
