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
                return View("New", vm);
            }

            if (feedback.Id == null || feedback.Id == 0)
            {
                if (feedback.Nev == null) feedback.Nev = "Anonymus";
                feedback.Datum = DateTime.Now;
                feedback.Engedelyezett = false;
                _context.FeedBack.Add(feedback);
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Feedback");
        }
        public ActionResult Delete(int id)
        {
            var feedback = _context.FeedBack.Find(id);
            if (feedback == null) return HttpNotFound();
            _context.FeedBack.Remove(feedback);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }

}