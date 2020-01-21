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
            var konzul = _context.FeedBack.ToList().OrderByDescending(f => f.Id);
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
                var vm = new FeedBackModel
                {
                    Konzul = konzul
                };
                return View("Uj", vm);
            }

            if (konzul.Id == null || konzul.Id == 0)
            {
                if (konzul.Nev == null) 
                konzul.Nev = "Anonymus";
                konzul.Datum = DateTime.Now;
                _context.Konzul.Add(konzul);
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "FeedBack");
        }
        public ActionResult Torles(int id)
        {
            var feedback = _context.FeedBack.Find(id);
            if (feedback == null) return HttpNotFound();
            _context.FeedBack.Remove(feedback);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}