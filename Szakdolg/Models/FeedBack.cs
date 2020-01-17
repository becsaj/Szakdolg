using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Szakdolg.Models
{
    public class FeedBack
    {
        public int? Id { get; set; }
        public string Nev { get; set; }
        public string Velemeny { get; set; }
        public DateTime Datum { get; set; }
        public bool Engedelyezett { get; set; }
        public bool Lattamozott { get; set; }
    }
}