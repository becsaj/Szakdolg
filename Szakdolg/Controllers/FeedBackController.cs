using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Szakdolg.Models;

namespace Szakdolg.Controllers
{
    [AllowAnonymous]
    public class FeedBackController : Controller
    {
        readonly ApplicationDbContext _context;
        public FeedBackController() => _context = new ApplicationDbContext();

        public ActionResult Index()
        {
            var feedback = _context.FeedBack.ToList().OrderByDescending(f => f.Id);
            return View(feedback);
        }
        public ActionResult Uj()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]

        public ActionResult Mentes(FeedBack feedback)
        {
            if (!ModelState.IsValid)
            {
                var vm = new FeedBackModel
                {
                    FeedBack = feedback
                };
                return View("Uj", vm);
            }

            if (feedback.Id == null || feedback.Id == 0)
            {
                if (feedback.Nev == null) feedback.Nev = "Anonymus";
                feedback.Datum = DateTime.Now;
                feedback.Engedelyezett = false;
                feedback.Lattamozott = false;
                _context.FeedBack.Add(feedback);
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