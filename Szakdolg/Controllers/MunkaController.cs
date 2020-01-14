using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Szakdolg.Models;

namespace Szakdolg.Controllers
{
    public class MunkaController : Controller
    {
        readonly ApplicationDbContext _context;

        public MunkaController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Munka
        public ActionResult Index()
        {
            var munk = _context.Munkaim.ToList().OrderByDescending(s => s.Elkeszult);
            return View(munk);
        }
    }
}