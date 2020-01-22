using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Szakdolg.Models;

namespace Szakdolg.Controllers
{
    public class IntezoKonzulController : Controller
    {
        readonly ApplicationDbContext _context;
        public IntezoKonzulController() => _context = new ApplicationDbContext();

        public ActionResult Index()
        {
            var konzul = _context.Konzul.ToList().OrderByDescending(f => f.Id);
            return View(konzul);
        }
        public ActionResult Torles(int id)
        {
            var konzul = _context.Konzul.Find(id);
            if (konzul == null) return HttpNotFound();
            _context.Konzul.Remove(konzul);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}