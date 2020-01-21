using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Szakdolg.Models
{
    public class Konzul
    {
        public int? Id { get; set; }
        public string Nev { get; set; }
        public string Ecim { get; set; }
        public string Szoveg { get; set; }
        public DateTime Datum { get; set; }

    }
}