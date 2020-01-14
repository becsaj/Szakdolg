using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Szakdolg.Models;

namespace Szakdolg.Controllers
{
    public class SablonController : Controller
    {
        readonly ApplicationDbContext _context;

        public SablonController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Sablon
        public ActionResult Index()
        {
            var sabl = _context.Sablonok.ToList();
            return View(sabl);
        }
    }
}