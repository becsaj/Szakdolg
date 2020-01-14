using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Szakdolg.Models
{
    public class Munka
    {
        public int Id { get; set; }
        public string Nev { get; set; }
        public string Img { get; set; }
        public DateTime Elkeszult { get; set; }
    }
}