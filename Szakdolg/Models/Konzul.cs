using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Szakdolg.Models
{
    public class Konzul
    {
        public int? Id { get; set; }
        [Display(Name = "Neve:")]
        public string Nev { get; set; }
        [Display(Name = "E-mail:")]
        public string Ecim { get; set; }
        [Display(Name = "Konzultációs szöveg:")]
        public string Szoveg { get; set; }
        public DateTime Datum { get; set; }
        public bool Lattamozott { get; set; }
        public bool Valasz { get; set; }

    }
}