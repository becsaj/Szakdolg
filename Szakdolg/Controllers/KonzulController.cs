using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Szakdolg.Models;

namespace Szakdolg.Controllers
{
    [Authorize(Roles = "Admin")]
    [AllowAnonymous]
    public class KonzulController : Controller
    {
        readonly ApplicationDbContext _context;
        public KonzulController() => _context = new ApplicationDbContext();

        public ActionResult Index()
        {
            var konzul = _context.Konzul.ToList().OrderByDescending(f => f.Id);
            return View(konzul);
        }
        public ActionResult Uj()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]

        public ActionResult Mentes(Konzul konzul)
        {
            if (!ModelState.IsValid)
            {
                var vm = new KonzulModel
                {
                    Konzul = konzul
                };
                return View("Uj", vm);
            }

            if (konzul.Id == null || konzul.Id == 0)
            {
                konzul.Datum = DateTime.Now;
                konzul.Valasz = false;
                konzul.Lattamozott = false;
                _context.Konzul.Add(konzul);
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Konzul");
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