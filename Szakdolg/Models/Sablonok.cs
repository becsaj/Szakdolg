using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Szakdolg.Models
{
    public class Sablonok
    {
        public int Id { get; set; }
        [Display(Name = "Neve:")]
        public string Megnevezes { get; set; }
        [Display(Name = "Kép:")]
        public string Img { get; set; }
        [Display(Name = "Ára(ft):")]
        public int Ar { get; set; }

    }
}