namespace Szakdolg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addMunka : DbMigration
    {
        public override void Up()
        {
            Sql($"INSERT INTO Munkas(Nev, Img ,Elkeszult) VALUES " +
                $"('Kast�ly','tetko1.png','2018-12-10'), " +
                $"('Jel','tetko2.png','2018-07-03'), " +
                $"('K�gy�fej','tetko3.png','2017-10-14'), " +
                $"('Felirat','tetko4.png','2017-08-26'), " +
                $"('Szigony','tetko5.png','2018-11-09'), " +
                $"('R�zsa','tetko6.png','2019-01-10'), " +
                $"('R�zsa','tetko7.png','2019-01-10'), " +
                $"('13','tetko8.png','2019-03-18'), " +
                $"('Korona (p�ros)','tetko9.png','2017-02-21'), " +
                $"('Oroszl�n (p�ros)','tetko10.png','2017-01-16'); ");

            Sql($"INSERT INTO Sablonoks(Megnevezes, Img ,Ar) VALUES " +
               $"('K�gy�','minta1.png','6000'), " +
               $"('Macska','minta2.png','5000'), " +
               $"('Koponya','minta3.png','5000'), " +
               $"('Ichigo','minta4.png','6000'), " +
               $"('Csontv�z','minta5.png','9000'), " +
               $"('Csontv�z','minta6.png','7000'), " +
               $"('Joker','minta7.jpeg','10000'), " + 
               $"('Karakter','minta8.png','15000'), " +
               $"('Koponya','minta10.png','6000'), " +
               $"('Joker','minta11.png','8000'); ");

        }
        
        public override void Down()
        {
        }
    }
}
