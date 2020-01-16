using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Szakdolg.Models
{
    public class Munka
    {
        public int Id { get; set; }
        [Display(Name = "Neve:")]
        public string Nev { get; set; }
        [Display(Name = "Kép:")]
        public string Img { get; set; }
        [Display(Name = "Elkészült:")]
        public DateTime Elkeszult { get; set; }
    }
}